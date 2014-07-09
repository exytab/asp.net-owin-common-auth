using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aspnet.Owin.Common.Auth.Identity
{
    public class ApplicationUser : IUser
    {
        public ApplicationUser(string name)
        {
            Id = Guid.NewGuid().ToString();
            UserName = name;
        }

        public string Id { get; private set; }
        public string UserName { get; set; }
    }
}