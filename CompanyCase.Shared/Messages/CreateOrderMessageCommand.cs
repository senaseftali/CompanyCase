using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyCase.Shared.Messages
{
    public class CreateOrderMessageCommand
    {
        public CreateOrderMessageCommand()
        {
            OrderItems = new List<OrderItem>();
        }

        public string BuyerId { get; set; }
        public string Status { get; set; }

        public List<OrderItem> OrderItems { get; set; }

        public string Province { get; set; }

        public string District { get; set; }

        public string Street { get; set; }

        public string ZipCode { get; set; }

        public string Line { get; set; }
    }

    public class OrderItem
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string PictureUrl { get; set; }
        public Decimal Price { get; set; }
        public int Quantity { get; set; }
        public Decimal Discount { get; set; }
        public Decimal Taxes { get; set; }
        public int Stock { get; set; }


    }
}