using CoreAngular.API.DAL.Models;
using System;
using System.Collections.Generic;

namespace CoreAngular.API.DAL.Models
{
    public partial class Product : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
