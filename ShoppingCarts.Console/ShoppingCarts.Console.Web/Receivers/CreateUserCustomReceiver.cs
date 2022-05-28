using System;
using System.Globalization;
using ShoppingCarts.Console.Web.Models;
using ShoppingCarts.Shared.Core.Bases;
using ShoppingCarts.Shared.Core.Models;

namespace ShoppingCarts.Console.Web.Receivers
{
    public class CreateUserCustomReceiver : AConsolidatorBase<UserViewModel, UserApiModel>
    {
        public CreateUserCustomReceiver(IServiceProvider service) : base(service) { }

        public override UserApiModel ToData(UserViewModel viewModel)
        {
            var model = ToExternalData(viewModel);
            model.Birth = DateTime.ParseExact(viewModel.Birth, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            return model;
        }
    }
}