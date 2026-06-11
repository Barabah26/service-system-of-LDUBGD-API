using AutoMapper;
using service_system_of_LDUBGD_API.Application.DTOs.Statement;
using service_system_of_LDUBGD_API.Domain;
using System.Diagnostics.Metrics;

namespace service_system_of_LDUBGD_API.Application.MappingProfiles;

public class StatementMappingProfile : Profile
{
    public StatementMappingProfile()
    {
        CreateMap<Statement, GetStatementDto>()
            .ForMember(d => d.StatementId, opt => opt.MapFrom(s => s.StatementId))
            .ForMember(d => d.FullName, opt => opt.MapFrom(s => s.FullName))
            .ForMember(d => d.DateOfBirth, opt => opt.MapFrom(s => s.YearBirthday))
            .ForMember(d => d.Group, opt => opt.MapFrom(s => s.Group))
            .ForMember(d => d.PhoneNumber, opt => opt.MapFrom(s => s.PhoneNumber))
            .ForMember(d => d.Faculty, opt => opt.MapFrom(s => s.Faculty))
            .ForMember(d => d.TypeOfStatement, opt => opt.MapFrom(s => s.TypeOfStatement))
            .ForMember(d => d.UserId, opt => opt.MapFrom(s => s.UserId));
        CreateMap<Statement, GetStatementListItemDto>()
            .ForMember(d => d.StatementId, opt => opt.MapFrom(s => s.StatementId));
        CreateMap<CreateStatementDto, Statement>()
            .ForMember(d => d.FullName, opt => opt.MapFrom(s => s.FullName))
            .ForMember(d => d.YearBirthday, opt => opt.MapFrom(s => s.DateOfBirth))
            .ForMember(d => d.Group, opt => opt.MapFrom(s => s.Group))
            .ForMember(d => d.PhoneNumber, opt => opt.MapFrom(s => s.PhoneNumber))
            .ForMember(d => d.Faculty, opt => opt.MapFrom(s => s.Faculty))
            .ForMember(d => d.TypeOfStatement, opt => opt.MapFrom(s => s.TypeOfStatement))
            .ForMember(d => d.UserId, opt => opt.MapFrom(s => s.UserId));
        CreateMap<UpdateStatementDto, Statement>()
            .ForMember(dest => dest.StatementId, opt => opt.Ignore())
            .ForMember(dest => dest.YearBirthday,
                opt => opt.MapFrom(src => src.DateOfBirth))
            .ForMember(dest => dest.UserId, opt => opt.Ignore())
            .ForAllMembers(opt =>
                opt.Condition((src, dest, srcMember) => srcMember != null));

    }
}
