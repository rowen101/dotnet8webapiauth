using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class RegisterModel
    {
      
        public string UserName { get; set; } = string.Empty;

     
        public string Email { get; set; } = string.Empty;

     
        public string Password { get; set; } = string.Empty;
    }
}