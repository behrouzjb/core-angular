using CoreAngular.API.DAL.Models;
using System;
using System.Collections.Generic;

namespace CoreAngular.API.Models
{
    public partial class Package : Entity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal PriceTotal { get; set; }
    }
}
