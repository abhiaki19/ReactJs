﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactJs.Core.Common
{
    public class ExpressionFilter
    {
        public string? PropertyName { get; set; }
        public object? Value { get; set; }
        public Comparison Comparison { get; set; }
    }

    public enum Comparison
    {
        [Display(Name = "==")]
        Equal,

        [Display(Name = "<")]
        LessThan,

        [Display(Name = "<=")]
        LessThanOrEqual,

        [Display(Name = ">")]
        GreaterThan,

        [Display(Name = ">=")]
        GreaterThanOrEqual,

        [Display(Name = "!=")]
        NotEqual,

        [Display(Name = "Contains")]
        Contains, //for strings  

        [Display(Name = "StartsWith")]
        StartsWith, //for strings  

        [Display(Name = "EndsWith")]
        EndsWith, //for strings  
    }
}
