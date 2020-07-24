using hotel.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(hotel.Startup))]
namespace hotel
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRoles();
        }
        private void CreateRoles()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManger = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (!roleManger.RoleExists("admin"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "admin";
                roleManger.Create(role);
            }
            if (!roleManger.RoleExists("accounting"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "accounting";
                roleManger.Create(role);
            }
            if (!roleManger.RoleExists("emp"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "emp";
                roleManger.Create(role);
            }
            if (!roleManger.RoleExists("user"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "user";
                roleManger.Create(role);
            }
        }
    }
}
