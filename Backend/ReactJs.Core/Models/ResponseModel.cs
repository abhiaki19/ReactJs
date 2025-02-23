using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactJs.Core.Models
{
    public class ResponseModel<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
        public ErrorModel? Error { get; set; }
    }

    public class ResponseModel
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public ErrorModel? Error { get; set; }
    }
    public class ErrorModel
    {
        public string? Code { get; set; }
        public string? Message { get; set; }
    }
}
