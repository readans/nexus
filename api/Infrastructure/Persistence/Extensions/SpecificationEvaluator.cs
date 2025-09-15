using Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Extensions;

public class SpecificationEvaluator
{
    public static SpecificationEvaluator Default { get; } = new();

    public IQueryable<T> GetQuery<T>(IQueryable<T> inputQuery, ISpecification<T> specification, bool forCount = false) 
        where T : class
    {
        var query = inputQuery;

        // Filtro WHERE
        query = query.Where(specification.Criteria);

        // Si es para count, no aplicamos includes ni ordenación
        if (forCount) return query;
        // INCLUDES
        query = specification.Includes
            .Aggregate(query, (current, include) => current.Include(include));

        query = specification.IncludeStrings
            .Aggregate(query, (current, include) => current.Include(include));

        // ORDER BY
        if (specification.OrderBy != null)
        {
            query = query.OrderBy(specification.OrderBy);
        }
        else if (specification.OrderByDescending != null)
        {
            query = query.OrderByDescending(specification.OrderByDescending);
        }

        // PAGINACIÓN
        if (specification.IsPagingEnabled)
        {
            query = query.Skip(specification.Skip).Take(specification.Take);
        }

        return query;
    }
}