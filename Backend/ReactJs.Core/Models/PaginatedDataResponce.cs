using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactJs.Core.Models
{
    public class PaginatedDataResponse<T>
    {
        public IEnumerable<T> Data { get; set; }
        public int TotalCount { get; set; }

        public PaginatedDataResponse(IEnumerable<T> data, int totalCount)
        {
            Data = data;
            TotalCount = totalCount;
        }
    }
}
