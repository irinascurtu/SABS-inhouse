using System;
using System.Collections.Generic;
using System.Linq;
using Conference.Domain;
using Conference.Domain.Entities;
using Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Conference.Data.Repositories
{
    public interface ISpeakerRepository
    {
        Speaker AddSpeaker(Speaker speaker);
        bool SpeakerExists(int speakerId);
        bool DeleteSpeaker(Speaker speaker);
        Speaker GetSpeaker(int speakerId);
        IQueryable<Speaker> GetSpeakers();
        IQueryable<Speaker> GetSpeakers(IEnumerable<int> speakerIds);
        bool UpdateSpeaker(Speaker speaker);
    }

    public class SpeakerRepository : ISpeakerRepository
    {
        private readonly ConferenceContext context;

        public SpeakerRepository(ConferenceContext context)
        {
            this.context = context;
        }


        public Speaker AddSpeaker(Speaker speaker)
        {
            var added = context.Speakers.Add(speaker);
            context.SaveChanges();
            return added.Entity;
        }

        public bool SpeakerExists(int speakerId)
        {
            return context.Speakers.Any(a => a.Id == speakerId);
        }

        public bool DeleteSpeaker(Speaker speaker)
        {
            if (speaker == null)
            {
                throw new ArgumentNullException(nameof(speaker));
            }

            var deleted = context.Speakers.Remove(speaker);
            context.SaveChanges();
            return deleted.Entity != null;
        }

        public Speaker GetSpeaker(int speakerId)
        {
            if (speakerId == 0)
            {
                throw new ArgumentNullException(nameof(speakerId));
            }

            return context.Speakers.FirstOrDefault(a => a.Id == speakerId);
        }

        public IQueryable<Speaker> GetSpeakers()
        {
            return context.Speakers;
        }

        public IQueryable<Speaker> GetSpeakers(IEnumerable<int> speakerIds)
        {
            if (speakerIds == null)
            {
                throw new ArgumentNullException(nameof(speakerIds));
            }
            //can be a full SQL query
            return context.Speakers.Where(a => speakerIds.Contains(a.Id))
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName);
        }

        public bool UpdateSpeaker(Speaker speaker)
        {
            var updatedSpeaker = context.Speakers.Update(speaker);
            context.SaveChanges();
            return updatedSpeaker != null;
        }

    }
}
