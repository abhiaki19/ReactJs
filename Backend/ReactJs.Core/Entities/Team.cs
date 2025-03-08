using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactJs.Core.Entities
{
    public class Team : BaseEntity<int>
    {
        [StringLength(maximumLength: 100, MinimumLength = 3)]
        public required string TeamName { get; set; }
        [StringLength(maximumLength: 1000)]
        public string Description { get; set; }
        public required bool IsActive { get; set; }
    }
}
