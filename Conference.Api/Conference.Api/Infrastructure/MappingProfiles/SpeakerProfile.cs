using AutoMapper;
using Conference.Api.Models.Speakers;
using Conference.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conference.Api.Infrastructure.MappingProfiles
{
    public class SpeakerProfile : Profile
    {
        public SpeakerProfile()
        {
            CreateMap<SpeakerForCreate, Speaker>();
            CreateMap<Speaker, SpeakerTrimmed>();

        }
    }
}
