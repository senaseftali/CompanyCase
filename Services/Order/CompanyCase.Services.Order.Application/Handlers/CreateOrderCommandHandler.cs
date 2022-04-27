using CompanyCase.Services.Order.Application.Commands;
using CompanyCase.Services.Order.Application.Dtos;
using CompanyCase.Services.Order.Domain.OrderAggregate;
using CompanyCase.Services.Order.Infrastructure;
using CompanyCase.Shared.Dtos;
using CompanyCase.Shared.Messages;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mass = MassTransit;
namespace CompanyCase.Services.Order.Application.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Response<CreatedOrderDto>>
    {
        private readonly OrderDbContext _context;
        private readonly Mass.IPublishEndpoint _publishEndpoint;
        public CreateOrderCommandHandler(OrderDbContext context, Mass.IPublishEndpoint publishEndpoint)
        {
            _context = context;
            _publishEndpoint= publishEndpoint;
        }

        public async Task<Response<CreatedOrderDto>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        { int stock = 0;
            var newAddress = new Address(request.Address.Province, request.Address.District, request.Address.Street, request.Address.ZipCode, request.Address.Line);

            Domain.OrderAggregate.Order newOrder = new Domain.OrderAggregate.Order(request.BuyerId, newAddress,request.Status);

            request.OrderItems.ForEach(x =>
            {
                newOrder.AddOrderItem(x.ProductId, x.ProductName, x.Price, x.PictureUrl,x.Quantity,x.Discount,x.Taxes,x.Stock);
            });

            await _context.Orders.AddAsync(newOrder);

            await _context.SaveChangesAsync();
            request.OrderItems.ForEach(x =>
            {
                stock = x.Stock - x.Quantity;
                _publishEndpoint.Publish<ProductStokChangedEvent>(new ProductStokChangedEvent { ProductId = x.ProductId, Stock = stock, Price = x.Price });
            });
            return Response<CreatedOrderDto>.Success(new CreatedOrderDto { OrderId = newOrder.Id,TotalAmount=newOrder.GetTotalPrice(), Stock= stock }, 200);
        }
    }
}