using CoreAngular.API.DAL.Models;
using System;
using System.Collections.Generic;

namespace CoreAngular.API.Models
{
    public partial class Price : Entity
    {
        public int Id { get; set; }
        public decimal Price1 { get; set; }
    }
}
