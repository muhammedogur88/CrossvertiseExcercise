using AutoMapper;
using CrossvertiseExcercise.Models;
using CrossvertiseExcercise.ViewModels;
using System.Globalization;

namespace CrossvertiseExcercise.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Appointment, AppointmentListViewModel>()
                .ForMember(dest => dest.Date,
                            opt => opt.MapFrom(src => src.Date.ToString("MM/dd/yyyy h:mm tt", CultureInfo.GetCultureInfo("en-US"))))
                .ForMember(dest => dest.Description,
                            opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Id,
                            opt => opt.MapFrom(src => src.Id));

            CreateMap<Appointment, AppointmentDetailViewModel>()
                .ForMember(dest => dest.Organizer,
                            opt => opt.MapFrom(src => src.User.FullName))
                .ForMember(dest => dest.Subject,
                            opt => opt.MapFrom(src => src.Subject))
                .ForMember(dest => dest.Date,
                            opt => opt.MapFrom(src => src.Date.ToString("MM/dd/yyyy h:mm tt", CultureInfo.GetCultureInfo("en-US"))))
                .ForMember(dest => dest.AppointmentAttendeesName,
                            opt => opt.MapFrom(src => src.AppointmentAttendees.Select(a => a.User.FullName)));
        }
    }
}
