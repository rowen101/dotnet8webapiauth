using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class LoginModel
    {
         public string Username { get; set; }= string.Empty;
        public string Password  { get; set; }= string.Empty;
    }
}