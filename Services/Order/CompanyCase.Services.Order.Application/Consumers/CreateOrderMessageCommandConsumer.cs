using CompanyCase.Services.Order.Infrastructure;
using CompanyCase.Shared.Messages;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mass = MassTransit;
namespace CompanyCase.Services.Order.Application.Consumers
{
    public class CreateOrderMessageCommandConsumer : IConsumer<CreateOrderMessageCommand>
    {
        private readonly OrderDbContext _orderDbContext;
        private readonly Mass.IPublishEndpoint _publishEndpoint;
        public CreateOrderMessageCommandConsumer(OrderDbContext orderDbContext, Mass.IPublishEndpoint publishEndpoint)
        {
            _orderDbContext = orderDbContext;
            _publishEndpoint = publishEndpoint; 
        }

        public async Task Consume(ConsumeContext<CreateOrderMessageCommand> context)
        {
            var newAddress = new Domain.OrderAggregate.Address(context.Message.Province, context.Message.District, context.Message.Street, context.Message.ZipCode, context.Message.Line);

            Domain.OrderAggregate.Order order = new Domain.OrderAggregate.Order(context.Message.BuyerId, newAddress, context.Message.Status);

            context.Message.OrderItems.ForEach(x =>
            {
                order.AddOrderItem(x.ProductId, x.ProductName, x.Price, x.PictureUrl,x.Quantity,x.Discount,x.Taxes,x.Stock);
            });

            await _orderDbContext.Orders.AddAsync(order);

            await _orderDbContext.SaveChangesAsync();
            //context.Message.OrderItems.ForEach(x =>
            //{
            //    _publishEndpoint.Publish<ProductStokChangedEvent>(new ProductStokChangedEvent { ProductId = x.ProductId, Stock = x.Stock - x.Quantity, Price = x.Price });
            //});

        }
    }
}