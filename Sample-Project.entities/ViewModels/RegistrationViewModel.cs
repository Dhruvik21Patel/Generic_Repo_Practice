using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Project.entities.ViewModels
{
    public class RegistrationViewModel
    {
        [Required]
        public string FirstName { get; set; } = null!;
    }
}
