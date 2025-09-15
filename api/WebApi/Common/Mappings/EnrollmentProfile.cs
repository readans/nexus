using Application.Enrollments.DTOs;
using AutoMapper;
using Domain.Entities;
using WebApi.Contracts.Enrollments.Requests;
using WebApi.Contracts.Enrollments.Responses;

namespace WebApi.Common.Mappings;

public class EnrollmentProfile: Profile
{
    public EnrollmentProfile()
    {
        // Entities -> Responses
        CreateMap<Enrollment, EnrollmentResponse>()
            .ForMember(dest => dest.StudentName, opt => opt.MapFrom(src => src.Student.Name))
            .ForMember(dest => dest.SubjectName, opt => opt.MapFrom(src => src.Subject.Name))
            .ForMember(dest => dest.ProfessorName, opt => opt.MapFrom(src => src.Subject.Professor.Name));
        
        // Requests -> Dto
        CreateMap<CreateEnrollmentRequest, CreateEnrollmentDto>();
    }
}
