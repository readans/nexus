using Application.Enrollments.DTOs;
using Application.Professors.Commands.Create;
using Application.Professors.DTOs;
using Application.Students.Commands.Create;
using Application.Students.DTOs;
using Application.Subjects.Commands.Create;
using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        services.AddAutoMapper(cfg =>
        {
            // Dto -> Entities
            cfg.CreateMap<CreateStudentDto, Student>();
            cfg.CreateMap<CreateProfessorDto, Professor>();
            cfg.CreateMap<CreateSubjectDto, Subject>();
            cfg.CreateMap<CreateEnrollmentDto, Enrollment>();
            
            // Entities -> Entities
            cfg.CreateMap<Enrollment, Student>()
                .ConvertUsing(src => src.Student!);
        });
        
        return services;
    }
    
}
