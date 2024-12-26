using App.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using UserManagerApp.Services.Uitls;
using UserManagerApp.Services.User.DTO;
using UserModel = UserManagerApp.Domain.Model.User;

namespace UserManagerApp.Services.User
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<UserModel> userManager;
        private readonly SignInManager<UserModel> signInManager;
        private readonly IConfiguration configuration;
        private readonly IUserSession userSession;
        private readonly IJwtGenerator jwtGenerator;
        public AccountService(UserManager<UserModel> userManager, SignInManager<UserModel> signInManager, IConfiguration configuration, IUserSession userSession, IJwtGenerator jwtGenerator)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
            this.userSession = userSession;
            this.jwtGenerator = jwtGenerator;
        }


        public async Task<OperationResult> Authenticate(LoginDto loginDto)
        {
            var findUser = await userManager.FindByNameAsync(loginDto.UserName);

            if (findUser == null)
                return new OperationResult { IsSuccess = false, ErrorMessage = "Invalid username or password." };

          
            try
            {
                var result = await signInManager.PasswordSignInAsync(findUser, loginDto.Password, false, false);
                if (!result.Succeeded)
                    return new OperationResult { IsSuccess = false, ErrorMessage = "Invalid username or password." };

                var token = jwtGenerator.GenerateJwtTokenAsync(findUser);

                return new OperationResult
                {
                    IsSuccess = true,
                    Token = token
                };

            }
            catch (Exception ex)
            {

                return new OperationResult { IsSuccess = false, ErrorMessage = ex.Message };
            }

            
        }


        public async Task<OperationResult> GetCurrentUserAsync()
        {
            try
            {
                var user = await userManager.FindByNameAsync(userSession.GetUserSession());
                if (user == null)
                    return new OperationResult { IsSuccess = false, ErrorMessage = "User not found." };


                var token = jwtGenerator.GenerateJwtTokenAsync(user);

                return new OperationResult
                {
                    IsSuccess = true,
                    Token = token,
                };
            }
            catch (Exception ex)
            {
                return new OperationResult { IsSuccess = false, ErrorMessage = ex.Message };
            }
        }


    }
}
