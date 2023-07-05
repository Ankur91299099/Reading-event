using Microsoft.AspNetCore.Identity;
using Nagarro.BookReading.Core.Entities;
using Nagarro.BookReading.Core.IRepositories;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Nagarro.BookReading.Infrastructure.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountRepository(UserManager<IdentityUser> userManager, SignInManager<IdentityUser>  signInManager) 
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }
        [AllowAnonymous]
        public async Task<IdentityResult> CreateUser(SignUp userSignUp)
        {
            var user = new IdentityUser()
            {

                UserName = userSignUp.userName,
                Email = userSignUp.email
            };

            
            var res = _userManager.Users.Where(x => x.Email == userSignUp.email).FirstOrDefault();
            var errorMessage = new IdentityError
            {
                Description = "Email already exist"
            };
            if (res == null)
            {
                var result = await _userManager.CreateAsync(user, userSignUp.password);
                return result;
            }
            else
            {
                return IdentityResult.Failed(errorMessage);
               
            }
        }

        public async Task<SignInResult> LoginUser(Login user)
        {
            var result = await _signInManager.PasswordSignInAsync(user.userName, user.password, true, false);
            return result;
        }

        public async Task SignOut()
        {
           await _signInManager.SignOutAsync();
        }

        public string GetEmail(string organiser)
        {
            var result =  _userManager.Users.FirstOrDefault(x => x.UserName == organiser).Email;
            return result;

        }

        

    }
}
