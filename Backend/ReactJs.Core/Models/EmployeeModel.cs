using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactJs.Core.Models
{
    public class EmployeeRequest : BaseModel<int>
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }

    public class EmployeeResponse : BaseModel<int>
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}
