using Application.Students.DTOs;
using AutoMapper;
using Domain.Entities;
using WebApi.Contracts.Auth.Requests;
using WebApi.Contracts.Students.Requests;
using WebApi.Contracts.Students.Responses;

namespace WebApi.Common.Mappings;

public class StudentProfile: Profile
{
    public StudentProfile()
    {
        // Requests -> Dto
        CreateMap<CreateStudentRequest, CreateStudentDto>();
        CreateMap<UpdateStudentRequest, UpdateStudentDto>();
        CreateMap<LoginRequest, CreateStudentDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => 
                string.IsNullOrEmpty(src.Name) ? "Anonymous" : src.Name));
        
        // Entities -> Responses
        CreateMap<Student, StudentResponse>();
        CreateMap<Enrollment, StudentEnrollmentResponse>()
            .ForMember(dest => dest.SubjectId, opt => opt.MapFrom(src => src.Subject.Id))
            .ForMember(dest => dest.SubjectName, opt => opt.MapFrom(src => src.Subject.Name))
            .ForMember(dest => dest.ProfessorName, opt => opt.MapFrom(src => src.Subject.Professor.Name));

        CreateMap<Student, ClassmateResponse>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
    }
}