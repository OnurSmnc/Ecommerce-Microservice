using System;
using System.Collections.Generic;
using System.Text;

namespace BasketService.Domain.DTOs.Requests
{
    public class ApplyCouponRequest
    {
        public string CouponCode { get; set; }
        public decimal DiscountRate { get; set; }
    }
}
