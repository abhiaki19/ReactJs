﻿using ReactJs.Core.Interfaces.IMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace ReactJs.Core.Mapper
{
    public class BaseMapper<TSource, TDestination> : IBaseMapper<TSource, TDestination>
    {
        private readonly IMapper _mapper;

        public BaseMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public TDestination MapModel(TSource source)
        {
            return _mapper.Map<TDestination>(source);
        }

        public TDestination MapModel(TSource source, TDestination destination)
        {
            return _mapper.Map(source, destination);
        }

        public IEnumerable<TDestination> MapList(IEnumerable<TSource> source)
        {
            return _mapper.Map<IEnumerable<TDestination>>(source);
        }
    }
}
