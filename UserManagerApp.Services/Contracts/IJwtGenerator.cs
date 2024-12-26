using System.Collections.Generic;
using UserManagerApp.Domain.Model;

namespace App.Services.Contracts
{
    public interface IJwtGenerator
    {
        string GenerateJwtTokenAsync(User user);
    }
}