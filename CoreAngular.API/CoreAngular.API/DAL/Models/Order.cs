﻿using CoreAngular.API.DAL.Models;
using System;
using System.Collections.Generic;

namespace CoreAngular.API.DAL.Models
{
    public partial class Order : Entity
    {
        public int RequestingUserId { get; set; }
        public int OfferingUserId { get; set; }
        public int PriceId { get; set; }
    }
}