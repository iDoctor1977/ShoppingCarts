using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using ShoppingCarts.Shared.Core.Interfaces.IConsolidators;
using ShoppingCarts.Shared.Core.Interfaces.ICustomMappers;

namespace ShoppingCarts.Shared.Core.Bases
{
    public abstract class AConsolidatorBase<TIn, TOut> : IConsolidators<TIn, TOut>
    {
        private readonly ICustomMapper _customMapper;

        protected AConsolidatorBase(IServiceProvider service)
        {
            _customMapper = service.GetRequiredService<ICustomMapper>();
        }

        protected TOut ToExternalData(TIn model)
        {
            var valueMap = _customMapper.Map<TIn, TOut>(model);

            return valueMap;
        }

        public IEnumerable<TOut> ToData(IEnumerable<TIn> model)
        {
            var viewModels = new List<TOut>();

            foreach (var apiModel in model)
            {
                viewModels.Add(ToData(apiModel));
            }

            return viewModels;
        }

        public abstract TOut ToData(TIn model);
    }
}