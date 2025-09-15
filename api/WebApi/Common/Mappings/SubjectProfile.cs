using Application.Subjects.Commands.Create;
using Application.Subjects.DTOs;
using AutoMapper;
using Domain.Entities;
using WebApi.Contracts.Subjects.Requests;
using WebApi.Contracts.Subjects.Responses;

namespace WebApi.Common.Mappings;

public class SubjectProfile: Profile
{
    public SubjectProfile()
    {
        // Requests -> Dto
        CreateMap<CreateSubjectRequest, CreateSubjectDto>();
        
        // Entities -> Responses
        CreateMap<Subject, SubjectResponse>()
            .ForMember(dest => dest.ProfessorName, opt => opt.MapFrom(src => src.Professor.Name));

        CreateMap<SubjectStudentsDto, SubjectStudentsResponse>();
    }
}