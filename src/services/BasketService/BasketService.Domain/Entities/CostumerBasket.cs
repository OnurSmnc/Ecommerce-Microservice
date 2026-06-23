using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketService.Domain.Entities
{
    public class CostumerBasket
    {
        public string BuyerId { get; set; }
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();
        public string CouponCode { get; set; } = string.Empty;

        public decimal DiscountRate { get; set; }
        public decimal RawTotalPrice => Items.Sum(x => x.Price * x.Quantity);
        public decimal TotalDiscount => RawTotalPrice * DiscountRate;
        public decimal FinalTotalPrice => RawTotalPrice - TotalDiscount;

        public CostumerBasket()
        {
            
        }

        public CostumerBasket(string buyerId, List<BasketItem> basketItems, decimal discountRate, string couponCode = null)
        {
            
            this.BuyerId = buyerId;
            this.Items = basketItems;
            this.CouponCode = couponCode;
            this.DiscountRate = discountRate;
        }

    }
}
