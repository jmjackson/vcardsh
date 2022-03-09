using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vcardsh.web.Models;

namespace vcardsh.web.Clase
{
    public class Utilities
    {
        readonly static ApplicationDbContext db = new ApplicationDbContext();
        public static void CheckRoles(string roleName)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            if (!roleManager.RoleExists(roleName))
            {
                roleManager.Create(new IdentityRole(roleName));
            }
        }

        internal static void CheckSuperUser()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var userAsp = userManager.FindByName("support@servicioshm.com");
            

            if (userAsp == null)
            {
                CreateUserASP("support@servicioshm.com", "admin2030", UserRoles.Administrador);
            }
           
        }

        public static void CreateUserASP(string mail, string password, string role)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var userASP = new ApplicationUser()
            {
                UserName = mail,
                Email = mail,
            };

            userManager.UserValidator = new UserValidator<ApplicationUser>(userManager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            var check = userManager.Create(userASP, password);

            if (check.Succeeded)
            {
                userManager.AddToRole(userASP.Id, role);

            }

        }

        public static void AddRoles(string id, string role)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = userManager.FindById(id);
            var rol = userManager.GetRoles(user.Id);
            if (rol.Count > 0)
            {
                userManager.RemoveFromRoles(user.Id, rol.ToArray());
                userManager.AddToRole(id, role);
            }
            else
            {
                userManager.AddToRole(id, role);
            }
            //Asignamos muchos roles
            // var rol= userManager.AddToRole(id, role);

        }
        public void Dispose()
        {
            db.Dispose();
        }

    }
}