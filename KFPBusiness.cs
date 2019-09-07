using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using KFP.DATA;
using KFP.MODELS;
using Microsoft.Owin.Security;

namespace KFP.BUSINESS
{
    class KFPBusiness : IdentityDbContext
    {
        public UserManager<ApplicationUser> UserManager { get; set; }
        public KFPBusiness()
        {
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new KFG_Db()));
        }
        //public List<UserView> GetAllUsers()
        //{
        //    using (var Userrepo = new ClientInFo())
        //    {
        //        return Userrepo.GetAll().Select(x => new UserView() { UserId = x.ClinicId, UserName = x.ClinicName }).ToList();
        //    }
        //}
        public void AddUser(RegisterModel objUser, IAuthenticationManager authenticationManager)
        {

            using (var Irepo = new KFG_Db())
            {
                KFG_Db unitofwork = new KFG_Db();

                var newuser = new ApplicationUser()
                {
                    Id = objUser.UserName,
                    UserName = objUser.UserName,
                    Email = objUser.Email,
                    FullName = objUser.IdNo,
                    PhoneNumber = objUser.ContactNO,
                    PasswordHash = UserManager.PasswordHasher.HashPassword(objUser.Password),
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                var user = new User
                {
                    UserName = objUser.UserName,
                    Surname = objUser.Surname,
                    ContactNO = objUser.ContactNO,
                    Address = objUser.Address,
                    DOB = objUser.DOB,
                    IdNo = objUser.IdNo,


                };
                //Irepo.(user);
                //unitofwork.Save();
            }
        }

        public System.Data.Entity.DbSet<KFP.DATA.Eventsdates> Eventsdates { get; set; }
    }
}
