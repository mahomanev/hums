using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KFP.DATA
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity>GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here => this.OrganizationId is a value stored in database against the user
            userIdentity.AddClaim(new Claim("id", this.Id.ToString()));
            return userIdentity;
        }
        public string FullName { get; set; }
    }
    
}