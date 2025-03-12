using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactJs.Core.Models
{
    public class LoginRequest 
    {
        public string Password { get; set; }
        public string Username { get; set; }
    }

    public class LoginResponse 
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public string Token { get; set; } = string.Empty;
    }
}
