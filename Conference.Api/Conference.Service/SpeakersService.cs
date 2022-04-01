using Conference.Data.Repositories;
using Conference.Domain;
using Conference.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conference.Service
{
    public class SpeakersService : ISpeakerService
    {
        private readonly ISpeakerRepository speakerRepository;

        public SpeakersService(ISpeakerRepository speakerRepository)
        {
            this.speakerRepository = speakerRepository;
        }

        public Speaker AddSpeaker(Speaker speaker)
        {
            return speakerRepository.AddSpeaker(speaker);
        }

        public bool DeleteSpeaker(Speaker speaker)
        {
           return speakerRepository.DeleteSpeaker(speaker);
        }

        public Speaker GetSpeaker(int speakerId)
        {
            return speakerRepository.GetSpeaker(speakerId);
        }

        public IEnumerable<Speaker> GetSpeakers()
        {
            return speakerRepository.GetSpeakers();
        }

        public IEnumerable<Speaker> GetSpeakers(IEnumerable<int> speakerIds)
        {
            return speakerRepository.GetSpeakers(speakerIds);
        }

        public bool SpeakerExists(int speakerId)
        {
            return speakerRepository.SpeakerExists(speakerId);
        }

        public bool UpdateSpeaker(Speaker speaker)
        {
            return speakerRepository.UpdateSpeaker(speaker);
        }
    }

    public interface ISpeakerService
    {
        Speaker AddSpeaker(Speaker speaker);
        bool SpeakerExists(int speakerId);
        bool DeleteSpeaker(Speaker speaker);
        Speaker GetSpeaker(int speakerId);
        IEnumerable<Speaker> GetSpeakers();
        IEnumerable<Speaker> GetSpeakers(IEnumerable<int> speakerIds);
        bool UpdateSpeaker(Speaker speaker);
    }
}
