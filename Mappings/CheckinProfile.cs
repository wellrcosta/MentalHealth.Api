using AutoMapper;
using MentalHealth.Api.DTOs;
using MentalHealth.Api.Models;

namespace MentalHealth.Api.Mappings;

public class CheckinProfile : Profile
{
    public CheckinProfile()
    {
        CreateMap<Checkin, CheckinResponseDto>()
            .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => src.Employee!.Name))
            .ForMember(dest => dest.EmployeeEmail, opt => opt.MapFrom(src => src.Employee!.Email));
    }
}
