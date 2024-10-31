using Microsoft.AspNetCore.Identity;
using Models;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Manager
{
    public class AccountManager:MainManager<User>
    {
        private UserManager<User> _userManager; 
        private  SignInManager<User> signInManager;
        public AccountManager(ProjectContext context,UserManager<User> userManager,SignInManager<User> _signInManager) : base(context) {
           _userManager = userManager;
            signInManager = _signInManager;
        
        }
        //User user = viewModel.ToModel();
        //var result = await userManager.CreateAsync(user, viewModel.Password);
        //result =  await userManager.AddToRoleAsync(user, viewModel.Role);
        //    //based ion role Add TO Table (Publicher or Auther)
        //    return result;
        public async Task<IdentityResult> Register(Userregister userregister) {
            User user = userregister.ToModel();

           var resulit=await _userManager.CreateAsync(user, userregister.Password);
            resulit = await _userManager.AddToRoleAsync(user, userregister.Role);
            return resulit;
        
        }
        public async Task<SignInResult> Login(LoginViewModel login)
        {
            var user = await _userManager.FindByEmailAsync(login.loginmethod);
            if (user == null)
            {
                user= await _userManager.FindByNameAsync(login.loginmethod);
                if(user == null)
                {
                  return  SignInResult.Failed;
                }
            }
           return await signInManager.PasswordSignInAsync(user, login.Password, login.RememberMe,true);
        }
        public void Logout()
        {
            signInManager.SignOutAsync();
        }

    }
}
