using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactJs.Core.Interfaces.IMapper
{
    public interface IBaseMapper<TSource, TDestination>
    {
        TDestination MapModel(TSource source);
        TDestination MapModel(TSource source, TDestination destination);
        IEnumerable<TDestination> MapList(IEnumerable<TSource> source);
    }
}
