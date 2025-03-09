using ReactJs.Core.Common;
using ReactJs.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactJs.Core.Interfaces.IServices
{
    public interface IBaseService<T>
       where T : class
    {
        Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken);
        Task<PaginatedDataResponse<T>> GetPaginatedData(int pageNumber, int pageSize, CancellationToken cancellationToken);
        Task<PaginatedDataResponse<T>> GetPaginatedData(int pageNumber, int pageSize, List<ExpressionFilter> filters, CancellationToken cancellationToken);
        Task<PaginatedDataResponse<T>> GetPaginatedData(int pageNumber, int pageSize, List<ExpressionFilter> filters, string sortBy, string sortOrder, CancellationToken cancellationToken);
        Task<T> GetById<Tid>(Tid id, CancellationToken cancellationToken);
        Task<bool> IsExists<Tvalue>(string key, Tvalue value, CancellationToken cancellationToken);
        Task<bool> IsExistsForUpdate<Tid>(Tid id, string key, string value, CancellationToken cancellationToken);
    }
}
