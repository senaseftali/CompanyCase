using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyCase.Services.Order.Application.Dtos
{
    public class CreatedOrderDto
    {
        public int OrderId { get; set; }
        public int Stock { get; set; }
        public decimal TotalAmount { get; set; }
    }
}