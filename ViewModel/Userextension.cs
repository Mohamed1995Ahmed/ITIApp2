using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public static class Userextension
    {
        public static User ToModel(this Userregister userregister)
        {
            return new User()
            {
                Firstname = userregister.Firstname,
                Lastname = userregister.Lastname,
                
                
                Email = userregister.Email,
               UserName = userregister.UserName,
               
            };
        }
    }
}
