using CompanyCase.Services.Order.Infrastructure;
using CompanyCase.Shared.Messages;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyCase.Services.Order.Application.Consumers
{
    public class ProductStokChangedEventConsumer : IConsumer<ProductStokChangedEvent>
    {
        private readonly OrderDbContext _orderDbContext;

        public ProductStokChangedEventConsumer(OrderDbContext orderDbContext)
        {
            _orderDbContext = orderDbContext;
        }

        public async Task Consume(ConsumeContext<ProductStokChangedEvent> context)
        {
            var orderItems = await _orderDbContext.OrderItems.Where(x => x.ProductId == context.Message.ProductId).ToListAsync();

            orderItems.ForEach(x =>
            {
                x.UpdateOrderItem(context.Message.Stock,  x.Price ,x.PictureUrl);
            });

            await _orderDbContext.SaveChangesAsync();
        }
    }
}
