using CoreAngular.API.DAL.Models;
using System;
using System.Collections.Generic;

namespace CoreAngular.API.DAL.Models
{
    public partial class Message : Entity
    {
        public int Id { get; set; }
        public int SendingUserId { get; set; }
        public int ReceivingUserId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public bool IsRead { get; set; }
        public bool IsSenderDeleted { get; set; }
        public bool IsReceiverDeleted { get; set; }
        public DateTime? DateRead { get; set; }
        public DateTime DateSent { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
    }
}
