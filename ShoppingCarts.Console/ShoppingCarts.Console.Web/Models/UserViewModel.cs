﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCarts.Console.Web.Models
{
    public class UserViewModel
    {
        [ScaffoldColumn(false)]
        public Guid GuId { get; set; }

        [Display(Name = "Nome")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Display(Name = "Cognome")]
        [DataType(DataType.Text)]
        public string Surname { get; set; }

        [Display(Name = "Anno di nascita")]
        [DataType(DataType.Text)]
        public string Birth { get; set; }

        [Display(Name = "Numero di telefono")]
        [DataType(DataType.Text)]
        public string TelNumber { get; set; }
    }
}