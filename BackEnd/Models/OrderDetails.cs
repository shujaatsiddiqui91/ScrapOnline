using System;
using System.Collections.Generic;

namespace WebApi2.Models
{
    public partial class OrderDetails
    {
        public int Orderdetailid { get; set; }
        public int? Categoryid { get; set; }
        public int? Quantity { get; set; }
        public string OrderId { get; set; }

        public virtual ScrapCategories Category { get; set; }
    }
}
