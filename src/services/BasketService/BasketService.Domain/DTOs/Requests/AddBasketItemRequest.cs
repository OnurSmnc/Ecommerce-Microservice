using System;
using System.Collections.Generic;
using System.Text;

namespace BasketService.Domain.DTOs.Requests
{
    public class AddBasketItemRequest
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
