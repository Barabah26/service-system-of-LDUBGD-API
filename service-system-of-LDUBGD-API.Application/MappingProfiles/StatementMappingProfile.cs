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
            .ForMember(d => d.StatementId, opt => opt.MapFrom(s => s.StatementId));
        CreateMap<Statement, GetStatementListItemDto>()
            .ForMember(d => d.StatementId, opt => opt.MapFrom(s => s.StatementId));
        CreateMap<CreateStatementDto, Statement>();
        CreateMap<UpdateStatementDto, Statement>()
            .ForMember(dest => dest.StatementId, opt => opt.Ignore())
            .ForMember(dest => dest.YearBirthday,
                opt => opt.MapFrom(src => src.DateOfBirth))
            .ForMember(dest => dest.UserId, opt => opt.Ignore())
            .ForAllMembers(opt =>
                opt.Condition((src, dest, srcMember) => srcMember != null));

    }
}
