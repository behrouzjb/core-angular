using CoreAngular.API.DAL.Models;
using System;
using System.Collections.Generic;

namespace CoreAngular.API.DAL.Models
{
    public partial class Timeline : Entity
    {
        public DateTime? DateInitiated { get; set; }
        public DateTime? DateCompleted { get; set; }
    }
}
