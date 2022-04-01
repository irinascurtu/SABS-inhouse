using Conference.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Conference.Api.Models.Speakers
{
    public class SpeakerForCreate 
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        public string Bio { get; set; }
        public string JobTitle { get; set; }
        public string Website { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string TwitterHandle { get; set; }
        public string CompanyName { get; set; }
    }
}
