using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Aspnet.Owin.Common.Auth.Identity
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(ApplicationUserStore store)
            : base(store)
        {
            this.PasswordHasher = new ApplicationPasswordHasher();
        }

        public override Task<ApplicationUser> FindAsync(string userName, string password)
        {
            Task<ApplicationUser> taskInvoke = Task<ApplicationUser>.Factory.StartNew(() =>
            {
                PasswordVerificationResult result = this.PasswordHasher.VerifyHashedPassword(userName, password);
                if (result == PasswordVerificationResult.SuccessRehashNeeded)
                {
                    return Store.FindByNameAsync(userName).Result;
                }
                return null;
            });
            return taskInvoke;
        }

        internal static ApplicationUserManager Create()
        {
            return new ApplicationUserManager(new ApplicationUserStore());
        }
    }
}