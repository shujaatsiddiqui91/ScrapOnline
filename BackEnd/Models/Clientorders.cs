using System;
using System.Collections.Generic;
using WebApi2.Data;

namespace WebApi2.Models
{
    public partial class Clientorders
    {
        public int Id { get; set; }
        public long? Userid { get; set; }
        public string Orderid { get; set; }
        public DateTime? Createdate { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
