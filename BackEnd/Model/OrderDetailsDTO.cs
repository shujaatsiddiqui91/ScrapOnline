using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi2.Models
{
    public class OrderDetailDTO
    {
        public int orderid { get; set; }
        public int categoryid { get; set; }
        public int quantity { get; set; }
    }

    public class OrderDetailsDTO
    {
        public int id { get; set; }
        public int userid { get; set; }
        public int orderid { get; set; }
        public DateTime createdate { get; set; }
        public int status { get; set; }
        public List<OrderDetailDTO> orderDetails { get; set; }
    }

}