using System;

namespace ShoppingCarts.Shared.Core.Models
{
    public class UserApiModel : ABaseModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birth { get; set; }
    }
}