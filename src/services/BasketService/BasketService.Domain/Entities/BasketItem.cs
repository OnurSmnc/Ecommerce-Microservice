using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketService.Domain.Entities
{
    public class BasketItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public BasketItem()
        {
            
        }
        public BasketItem(int productId, string productName, decimal price, int quantity)
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.Price = price;
            this.Quantity = quantity;
        }
    }
}
