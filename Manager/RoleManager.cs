using Microsoft.AspNetCore.Identity;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public class RoleManager:MainManager<IdentityRole>
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleManager(ProjectContext context, Microsoft.AspNetCore.Identity.RoleManager<IdentityRole>  roleManager) :base(context)
        {
            this.roleManager = roleManager;
        }
        public async Task<IdentityResult> Add(string rolename)
        {
            var role = new IdentityRole() { Name = rolename };
           return await roleManager.CreateAsync(role);
        }
    }
}
