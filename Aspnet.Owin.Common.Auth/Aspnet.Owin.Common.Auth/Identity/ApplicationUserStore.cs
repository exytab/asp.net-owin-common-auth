using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Aspnet.Owin.Common.Auth.Identity
{
    public class ApplicationUserStore : IUserStore<ApplicationUser>
    {
        static readonly List<ApplicationUser> Users = new List<ApplicationUser>();

        public System.Threading.Tasks.Task CreateAsync(ApplicationUser user)
        {
            return Task.Factory.StartNew(() => Users.Add(user));
        }

        public System.Threading.Tasks.Task DeleteAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<ApplicationUser> FindByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<ApplicationUser> FindByNameAsync(string userName)
        {
            return Task<ApplicationUser>.Factory.StartNew(() => Users.FirstOrDefault(u => u.UserName == userName));
        }

        public System.Threading.Tasks.Task UpdateAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}