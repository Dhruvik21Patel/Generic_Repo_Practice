using Microsoft.EntityFrameworkCore;
using Sample_Project.entities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Project.entities.Models
{
    public class User : AuditableEntity<long>
    {
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        public double PhoneNumber { get; set; } = 0!;
        public string Avatar { get; set; } = "/Assets/defaultUser.png";
        public string UserRole { get; set; } = "User";
        public string? WhyIVolunteer { get; set; }
        public string? EmployeeId { get; set; }
        public string? Department { get; set; }
        public long? CityId { get; set; }
        public int? CountryId { get; set; }
        public string? Availability { get; set; }
        public string? ProfileText { get; set; }
        public string? LinkedInUrl { get; set; }
        public string? Title { get; set; }

        [ForeignKey("CountryId")]
        public Country Countries { get; set; }

        [ForeignKey("CityId")]
        public City Cities { get; set; }


    }
}
