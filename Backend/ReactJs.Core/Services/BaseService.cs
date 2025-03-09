using ReactJs.Core.Common;
using ReactJs.Core.Interfaces.IMapper;
using ReactJs.Core.Interfaces.IRepositories;
using ReactJs.Core.Interfaces.IServices;
using ReactJs.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactJs.Core.Services
{
    public class BaseService<T, TModel> : IBaseService<TModel>
        where T : class
        where TModel : class
    {
        private readonly IBaseMapper<T, TModel> _viewModelMapper;
        private readonly IBaseRepository<T> _repository;

        public BaseService(
            IBaseMapper<T, TModel> viewModelMapper,
            IBaseRepository<T> repository)
        {
            _viewModelMapper = viewModelMapper;
            _repository = repository;
        }

        public virtual async Task<IEnumerable<TModel>> GetAll(CancellationToken cancellationToken)
        {
            return _viewModelMapper.MapList(await _repository.GetAll(cancellationToken));
        }

        public virtual async Task<PaginatedDataResponse<TModel>> GetPaginatedData(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            var paginatedData = await _repository.GetPaginatedData(pageNumber, pageSize, cancellationToken);
            var mappedData = _viewModelMapper.MapList(paginatedData.Data);
            var paginatedDataViewModel = new PaginatedDataResponse<TModel>(mappedData.ToList(), paginatedData.TotalCount);
            return paginatedDataViewModel;
        }

        public virtual async Task<PaginatedDataResponse<TModel>> GetPaginatedData(int pageNumber, int pageSize, List<ExpressionFilter> filters, CancellationToken cancellationToken)
        {
            var paginatedData = await _repository.GetPaginatedData(pageNumber, pageSize, filters, cancellationToken);
            var mappedData = _viewModelMapper.MapList(paginatedData.Data);
            var paginatedDataViewModel = new PaginatedDataResponse<TModel>(mappedData.ToList(), paginatedData.TotalCount);
            return paginatedDataViewModel;
        }

        public virtual async Task<PaginatedDataResponse<TModel>> GetPaginatedData(int pageNumber, int pageSize, List<ExpressionFilter> filters, string sortBy, string sortOrder, CancellationToken cancellationToken)
        {
            var paginatedData = await _repository.GetPaginatedData(pageNumber, pageSize, filters, sortBy, sortOrder, cancellationToken);
            var mappedData = _viewModelMapper.MapList(paginatedData.Data);
            var paginatedDataViewModel = new PaginatedDataResponse<TModel>(mappedData.ToList(), paginatedData.TotalCount);
            return paginatedDataViewModel;
        }

        public virtual async Task<TModel> GetById<Tid>(Tid id, CancellationToken cancellationToken)
        {
            return _viewModelMapper.MapModel(await _repository.GetById(id, cancellationToken));
        }

        public virtual async Task<bool> IsExists<Tvalue>(string key, Tvalue value, CancellationToken cancellationToken)
        {
            return await _repository.IsExists(key, value?.ToString(), cancellationToken);
        }

        public virtual async Task<bool> IsExistsForUpdate<Tid>(Tid id, string key, string value, CancellationToken cancellationToken)
        {
            return await _repository.IsExistsForUpdate(id, key, value, cancellationToken);
        }

    }
}
