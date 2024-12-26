using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagerApp.Services.PersonaUser.DTO
{
    public class RegisterPersonUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Identification { get; set; }
        public string Email { get; set; }
        public string IdentificationType { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
