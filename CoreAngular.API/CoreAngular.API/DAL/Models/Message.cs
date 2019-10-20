using CoreAngular.API.DAL.Models;
using System;
using System.Collections.Generic;

namespace CoreAngular.API.Models
{
    public partial class Message : Entity
    {
        public int Id { get; set; }
        public int SendingUserId { get; set; }
        public int ReceivingUserId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
