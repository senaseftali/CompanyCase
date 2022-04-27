using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyCase.Services.Order.Application.Dtos
{
    public class OrderItemDto
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        
        public string PictureUrl { get; set; }
        public int Quantity { get; set; }
        public Decimal Price { get; set; }
        public Decimal Discount { get; set; }
        public Decimal Taxes { get; set; }
        public int Stock { get; set; }
    }
}