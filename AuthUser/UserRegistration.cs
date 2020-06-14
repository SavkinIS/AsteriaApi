using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsteriaApi.AuthUser
{
    public class UserRegistration 
    {
        
        public string LoginProp { get; set; }

        
        public string Password { get; set; }

        
        public string ConfirmPassword { get; set; }
    }
}
