using BasketService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketService.Domain.DTOs.Resonses
{
    public class BasketItemResponseDTO
    {
        public string BuyerId { get; set; }
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();
        public string CouponCode { get; set; } = string.Empty;
        public decimal RawTotalPrice { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal FinalTotalPrice { get; set; }
    }
}
