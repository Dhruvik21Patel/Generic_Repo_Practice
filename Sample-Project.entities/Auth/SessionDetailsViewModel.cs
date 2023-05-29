using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Project.entities.Auth
{
    public class SessionDetailsViewModel
    {
        public string Email { get; set; } = string.Empty;
        public string Avatar { get; set; } = string.Empty;
        public long UserId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string UserRole { get; set; }
        = string.Empty;
    }
}
