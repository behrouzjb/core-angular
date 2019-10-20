using CoreAngular.API.DAL.Models;
using System;
using System.Collections.Generic;

namespace CoreAngular.API.DAL.Models
{
    public partial class OrderPackage : Entity
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int PackageId { get; set; }
    }
}
