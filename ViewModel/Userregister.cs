﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
   public class Userregister
    {
        [Required, StringLength(10, MinimumLength = 3)]
        public string Firstname { get; set; }

        [Required, StringLength(10, MinimumLength = 3)]
        public string Lastname { get; set; }

        [Required, StringLength(10, MinimumLength = 8)]
        public string UserName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, StringLength(10, MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, StringLength(10, MinimumLength = 8)]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public string Role { get; set; }

    }
}
