using CompanyCase.Services.Order.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyCase.Services.Order.Domain.OrderAggregate
{
    public class Order : Entity, IAggregateRoot
    {
        public DateTime CreatedDate { get; private set; }

        public Address Address { get; private set; }

        public string BuyerId { get; private set; }
        public string Status { get; private set; }

        private readonly List<OrderItem> _orderItems;

        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

        public Order()
        {
        }

        public Order(string buyerId, Address address, string status)
        {
            _orderItems = new List<OrderItem>();
            CreatedDate = DateTime.Now;
            BuyerId = buyerId;
            Address = address;
            Status = status;
        }

        public void AddOrderItem(string productId, string productName, decimal price, string pictureUrl, int quantity, decimal discount, decimal taxed, int stock)
        {
            var existProduct = _orderItems.Any(x => x.ProductId == productId);

            if (!existProduct)
            {
                var newOrderItem = new OrderItem(productId, productName, pictureUrl, price , quantity, discount, taxed, stock);

                _orderItems.Add(newOrderItem);
            }
        }

        public decimal GetTotalPrice()
        {
            decimal total = 0;
            foreach (var item in _orderItems)
            {
                total += (item.Price * item.Quantity) - item.Discount;
            }
            return total;

        }
    }
}