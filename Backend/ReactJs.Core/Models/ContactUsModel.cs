using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactJs.Core.Models
{
    public class ContactUsResponse : BaseModel<int>
    {
        public string LastName { get; set; }
        public string FirstName { get; set; } 
        public string Email { get; set; }
         public string Message { get; set; }
        public bool IsActiveforNewsletter { get; set; }
    }

    public class ContactUsRequest : BaseModel<int>
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public bool IsActiveforNewsletter { get; set; }
    }
}
