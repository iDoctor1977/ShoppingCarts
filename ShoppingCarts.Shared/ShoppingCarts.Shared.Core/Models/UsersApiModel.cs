using System.Collections.Generic;

namespace ShoppingCarts.Shared.Core.Models
{
    public class UsersApiModel : ABaseModel
    {
        public IEnumerable<UserApiModel> UsersApiModelList { get; set; }
    }
}