﻿using System;
using ShoppingCarts.Shared.Core.Bases;

namespace ShoppingCarts.Shared.Core.Receivers
{
    public sealed class DefaultReceiver<TIn, TOut> : AConsolidatorBase<TIn, TOut>
    {
        public DefaultReceiver(IServiceProvider service) : base(service) { }

        public override TOut ToData(TIn viewModel)
        {
            var model = ToExternalData(viewModel);

            return model;
        }
    }
}