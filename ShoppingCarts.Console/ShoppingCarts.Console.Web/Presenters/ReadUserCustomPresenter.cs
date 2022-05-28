using System;
using ShoppingCarts.Console.Web.Models;
using ShoppingCarts.Shared.Core.Bases;
using ShoppingCarts.Shared.Core.Extensions;
using ShoppingCarts.Shared.Core.Models;

namespace ShoppingCarts.Console.Web.Presenters
{
    public class ReadUserCustomPresenter : AConsolidatorBase<UserApiModel, UserViewModel>
    {
        public ReadUserCustomPresenter(IServiceProvider service) : base(service) { }

        public override UserViewModel ToData(UserApiModel model)
        {
            var viewModel = ToExternalData(model);
            viewModel.Birth = model.Birth.ToStandardString();

            return viewModel;
        }
    }
}