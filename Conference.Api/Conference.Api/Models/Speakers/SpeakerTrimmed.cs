using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conference.Api.Models.Speakers
{
    public class SpeakerTrimmed
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public string FullName =>
                FirstName + " " + LastName;

    }
}
