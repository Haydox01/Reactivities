using Application.Activities;
using Application.Profiles;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Domain.Activity, Domain.Activity>();
            CreateMap<Domain.Activity, ActivityDto>().ForMember(d => d.HostUserName, o=> o.MapFrom(s=> s.Attendees
            .FirstOrDefault(x=> x.IsHost).AppUser.UserName));

            CreateMap<ActivityAttendee, Profiles.AttendeesProfile>()
                .ForMember(d => d.DisplayName, o => o.MapFrom(s => s.AppUser.DisplayName))
                .ForMember(d => d.UserName, o => o.MapFrom(s => s.AppUser.UserName))
                .ForMember(d => d.Bio, o => o.MapFrom(s => s.AppUser.Bio));
                
        }
    }
}
