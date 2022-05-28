﻿using System;

namespace ShoppingCarts.StorageRoom.Data.Entities
{
    public class User : EntityBase
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birth { get; set; }
    }
}