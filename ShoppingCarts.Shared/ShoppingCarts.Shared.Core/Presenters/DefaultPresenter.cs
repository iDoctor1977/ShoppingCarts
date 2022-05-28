using System;
using ShoppingCarts.Shared.Core.Bases;

namespace ShoppingCarts.Shared.Core.Presenters
{
    public sealed class DefaultPresenter<TIn, TOut> : AConsolidatorBase<TIn, TOut>
    {
        public DefaultPresenter(IServiceProvider service) : base(service) { }

        public override TOut ToData(TIn model)
        {
            var viewModel = ToExternalData(model);

            return viewModel;
        }
    }
}