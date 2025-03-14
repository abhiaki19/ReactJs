﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactJs.Core.Entities
{
    public class ContactUs : BaseEntity<int>
    {
        [StringLength(maximumLength: 100, MinimumLength = 3)]
        public required string LastName { get; set; }
        [StringLength(maximumLength: 100, MinimumLength = 3)]
        public required string FirstName { get; set; } 
        public required string Email { get; set; } 
        public required string Message { get; set; }
        public bool IsActiveforNewsletter { get; set; }
    }
}
