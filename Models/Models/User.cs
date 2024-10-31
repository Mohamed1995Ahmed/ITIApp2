using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class User : IdentityUser
    {
    
    
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public string? NationalID { get; set; }
        public string? Picture { get; set; }
        public virtual Author? Author { get; set; }
        public virtual Publisher? Publisher { get; set; }

    }

}