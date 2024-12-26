using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagerApp.Services.PersonaUser.DTO;
using UserManagerApp.Services.Uitls;

namespace UserManagerApp.Services.PersonaUser
{
    public interface IPersonUser
    {
        Task<OperationResult> RegisterPersonUser(RegisterPersonUserDto data);
    }
}
