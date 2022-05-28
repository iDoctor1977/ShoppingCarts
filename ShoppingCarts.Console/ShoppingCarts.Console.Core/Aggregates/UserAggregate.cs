﻿using System;
using ShoppingCarts.Shared.Core.Bases;
using ShoppingCarts.Shared.Core.Models;

namespace ShoppingCarts.Console.Core.Aggregates
{
    public class UserAggregate : AAggregateBase<UserApiModel>
    {
        public UserAggregate(UserApiModel model) : base(model) { }

        public void SetGuid(Guid guid)
        {
            Model.Guid = guid;
        }

        public void SetName (string name)
        {
            Model.Name = name;
        }
        public void SetSurame (string surname)
        {
            Model.Surname = surname;
        }
        public void SetBirth (DateTime birth)
        {
            Model.Birth = birth;
        }

        public override UserApiModel ToModel()
        {
            return Model;
        }

        protected override bool IsModelValid()
        {
            var value = !string.IsNullOrWhiteSpace(Model.Name);
            value = !string.IsNullOrWhiteSpace(Model.Surname);

            return value;
        }
    }
}