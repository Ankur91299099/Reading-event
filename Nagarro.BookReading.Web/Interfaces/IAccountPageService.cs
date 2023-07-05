using Microsoft.AspNetCore.Identity;
using Nagarro.BookReading.Core.Entities;
using Nagarro.BookReading.Web.Models;
using System.Threading.Tasks;

namespace Nagarro.BookReading.Web.Interfaces
{
    public interface IAccountPageService
    {
        Task<IdentityResult> CreateUser(SignUpViewModel signUpViewModel);

        Task<SignInResult> LoginUser(LoginViewModel loginViewModel);

        Task SignOut();
        string GetEmail(string organiser);
    }
}
