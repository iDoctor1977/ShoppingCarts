using System;
using Microsoft.Extensions.DependencyInjection;
using ShoppingCarts.Console.Web.Models;
using ShoppingCarts.Shared.Core.Bases;
using ShoppingCarts.Shared.Core.Interfaces.IConsolidators;
using ShoppingCarts.Shared.Core.Models;

namespace ShoppingCarts.Console.Web.Presenters
{
    public class ReadUsersCustomPresenter : AConsolidatorBase<UsersApiModel, UsersViewModel>
    {
        private readonly IConsolidators<UserApiModel, UserViewModel> _readUserCustomPresenter;

        public ReadUsersCustomPresenter(IServiceProvider service) : base(service)
        {
            _readUserCustomPresenter = service.GetRequiredService<IConsolidators<UserApiModel, UserViewModel>>();
        }

        public override UsersViewModel ToData(UsersApiModel model)
        {
            var viewModel = ToExternalData(model);
            viewModel.UsersViewModelList = _readUserCustomPresenter.ToData(model.UsersApiModelList);

            return viewModel;
        }
    }
}