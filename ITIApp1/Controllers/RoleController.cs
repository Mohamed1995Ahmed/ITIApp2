using Manager;
using Microsoft.AspNetCore.Mvc;
using ViewModel;

namespace ITIApp1.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager roleManager;

        public RoleController(RoleManager roleManager)
        {
            this.roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task <IActionResult> add(RoleViewModel roleViewModel)
        {
          var result=await  roleManager.Add(roleViewModel.Name);
            return View("role");
        }
    }
}
