﻿using CoreAngular.API.DAL.Models;
using System;
using System.Collections.Generic;

namespace CoreAngular.API.DAL.Models
{
    public partial class Transaction : Entity
    {
        public int PackageId { get; set; }
    }
}