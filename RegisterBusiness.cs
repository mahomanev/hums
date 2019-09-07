using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KFP.DATA;
using Microsoft.AspNet.Identity;
using System.Net;
using KFP.MODELS;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.EntityFramework;


namespace KFP.BUSINESS
{
    public class RegisterBusiness
    {
        public UserManager<ApplicationUser> UserManager { get; set; }

        public RegisterBusiness()
        {
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new KFG_Db()));
        }

        public bool FindUser(string userName, IAuthenticationManager authenticationManager)
        {
            var user = UserManager.FindByName(userName);
            if (user != null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> RegisterUser(RegisterModel objRegisterModel, IAuthenticationManager authenticationManager)
        {
            var newuser = new ApplicationUser()
            {
                Id = objRegisterModel.Email,
                UserName = objRegisterModel.Email,
                Email = objRegisterModel.Email,
                PasswordHash = UserManager.PasswordHasher.HashPassword(objRegisterModel.Password)
            };

            var result = await UserManager.CreateAsync(
               newuser, objRegisterModel.Password);

            if (result.Succeeded)
            {
                await SignInAsync(newuser, false, authenticationManager);
                return true;
            }
            return false;
        }

        private async Task SignInAsync(ApplicationUser user, bool isPersistent, IAuthenticationManager authenticationManager)
        {
            authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }

        public bool AddUserToRole(string user, string role)
        {
            var result = UserManager.AddToRole(user, role);

            return result.Succeeded;
        }
    }
}
