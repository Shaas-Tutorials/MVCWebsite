using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace UI.Security
{
    public class CustomPrincipal : IPrincipal
    {       
        public CustomPrincipal(string Username)
        {
            this.Identity = new GenericIdentity(Username);
        }

        //Authenticity
        public IIdentity Identity { get; private set; }


        //Authorization
        public bool IsInRole(string role)
        {
            if (Roles.Any(r => role.Contains(r)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public string ContactNo { get; set; }
        public string[] Roles { get; set; }
    }
}