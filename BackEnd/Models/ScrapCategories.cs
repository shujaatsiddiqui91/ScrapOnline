using System;
using System.Collections.Generic;

namespace WebApi2.Models
{
    public partial class ScrapCategories
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public string CategoryName { get; set; }
        public string Unit { get; set; }
    }
}
