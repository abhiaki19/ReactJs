using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactJs.Core.Models
{
    public class TeamRequest : BaseModel<int>
    {
        public string TeamName { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
    }

    public class TeamResponse : BaseModel<int>
    {
        public string TeamName { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
    }
}
