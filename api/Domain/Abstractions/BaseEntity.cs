using Domain.Common;

namespace Domain.Abstractions;

public abstract class BaseEntity<TKey> where TKey : IEquatable<TKey>
{
   public TKey Id { get; protected set; }
   private readonly List<DomainEvent> _domainEvents = new();
   public IReadOnlyCollection<DomainEvent> GetDomainEvents() => _domainEvents.ToList();

   public void Raise(DomainEvent domainEvent)
   {
      _domainEvents.Add(domainEvent);
   }

   public void ClearDomainEvents()
   {
      _domainEvents.Clear();
   }
}
