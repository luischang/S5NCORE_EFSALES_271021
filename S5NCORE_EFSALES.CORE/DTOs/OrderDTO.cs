using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S5NCORE_EFSALES.CORE.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public int CustomerId { get; set; }
        public decimal? TotalAmount { get; set; }
    }

    public class OrderNumberDTO
    {      
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }
      
    }
}
