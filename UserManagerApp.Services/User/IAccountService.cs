using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagerApp.Services.Uitls;
using UserManagerApp.Services.User.DTO;

namespace UserManagerApp.Services.User
{
    public interface IAccountService
    {
        Task<OperationResult> Authenticate(LoginDto loginDto);
        Task<OperationResult> GetCurrentUserAsync();
    }
}
