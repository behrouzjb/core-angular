using CoreAngular.API.DAL.Models;
using System;
using System.Collections.Generic;

namespace CoreAngular.API.DAL.Models
{
    public partial class Price : Entity
    {
        public decimal PriceInitial { get; set; }
        public decimal PriceTax { get; set; }
        public decimal PriceServices { get; set; }
        public decimal PriceTransaction { get; set; }
        public decimal PriceTotal { get; set; }
    }
}
