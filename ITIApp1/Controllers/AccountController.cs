using ITIApp1.Models;
using Manager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ViewModel;

namespace ITIApp1.Controllers
{
    public class AccountController : Controller
    {
        AccountManager _accountManager;
        public AccountController(AccountManager accountManager)
        {
            this._accountManager = accountManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();  
        }
        [HttpPost]
        public async Task <IActionResult>Register(Userregister userregister)
        {
            if (ModelState.IsValid)
            {
                
                var result= await _accountManager.Register(userregister);
                if(result.Succeeded)
                return RedirectToAction("Login","Account");
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("",item.Description);
                    }
                    return View(userregister);
                }
            }
            else
            {
                return View(userregister);
            }
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            LoginViewModel vm = new LoginViewModel { returnurl = returnUrl };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountManager.Login(model);
                if (result.Succeeded)
                {
                    return Redirect(model.returnurl ?? "/"); // Default to root if returnUrl is null
                }
                else if (result.IsLockedOut)
                {
                    ModelState.AddModelError("", "Sorry, can't login ,try againafter minute.");
                    return View(model);

                }
                else
                {
                    ModelState.AddModelError("", "Sorry, can't login.");
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }
        public IActionResult logout()
        {
             _accountManager.Logout();
            return RedirectToAction("index", "home");
        }
    }
}
