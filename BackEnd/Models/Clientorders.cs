using System;
using System.Collections.Generic;
using WebApi2.Data;

namespace WebApi2.Models
{
    public partial class Clientorders
    {
        public Clientorders()
        {
            OrderDetails = new List<OrderDetails>();
        }

        public int Id { get; set; }
        public long? Userid { get; set; }
        public string Orderid { get; set; }
        public DateTime? Createdate { get; set; }
        public int? Status { get; set; }

        public ApplicationUser User {get;set;}
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
