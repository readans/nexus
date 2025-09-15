using Application.Professors.Commands.Create;
using Application.Professors.Commands.Update;
using Application.Professors.DTOs;
using AutoMapper;
using Domain.Entities;
using WebApi.Contracts.Professors.Requests;
using WebApi.Contracts.Professors.Responses;

namespace WebApi.Common.Mappings;

public class ProfessorProfile: Profile
{
    public ProfessorProfile()
    {
        // Requests -> Dto
        CreateMap<CreateProfessorRequest, CreateProfessorDto>();
        CreateMap<UpdateProfessorRequest, UpdateProfessorDto>();
        
        // Entities -> Responses
        CreateMap<Professor, ProfessorResponse>();
    }
}