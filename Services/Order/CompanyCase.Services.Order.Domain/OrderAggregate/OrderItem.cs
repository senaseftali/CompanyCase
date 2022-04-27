using CompanyCase.Services.Order.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyCase.Services.Order.Domain.OrderAggregate
{
    public class OrderItem : Entity
    {
        public string ProductId { get; private set; }
        public string ProductName { get; private set; }
        public string PictureUrl { get; private set; }
        public Decimal Price { get; private set; }
        public int Quantity { get; private set; }
        public int Stock { get; private set; }
        public Decimal Discount { get; private set; }
        public Decimal Taxes { get; private set; }
        public OrderItem()
        {
        }

        public OrderItem(string productId, string productName, string pictureUrl, decimal price, int quantity, decimal discount,decimal taxes, int stock)
        {
            ProductId = productId;
            ProductName = productName;
            PictureUrl = pictureUrl;
            Price = price;
            Quantity= quantity;
            Discount=discount;
            Taxes= taxes;
            Stock = stock;
        }

        public void UpdateOrderItem(int stock, decimal price, string pictureUrl)
        {
            Stock  = stock;
            Price = price;
            PictureUrl = pictureUrl;
        }
    }
}