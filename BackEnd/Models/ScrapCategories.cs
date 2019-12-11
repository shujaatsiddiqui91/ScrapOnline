using System;
using System.Collections.Generic;

namespace WebApi2.Models
{
    public partial class ScrapCategories
    {
        public ScrapCategories()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int Id { get; set; }
        public int Price { get; set; }
        public string CategoryName { get; set; }
        public string Unit { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
