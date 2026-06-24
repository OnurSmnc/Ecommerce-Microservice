using BasketService.Domain.Entities;
using Shared.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketService.Application.Services
{
    public interface ICostumerBasketService
    {
        Task<ApiResponse<CostumerBasket>> GetBasketAsync(string buyerId);
        Task<ApiResponse<CostumerBasket>> AddItemAsync(string buyerId, BasketItem item);
        Task<ApiResponse<CostumerBasket>> RemoveItemAsync(string buyerId, int productId);
        Task<ApiResponse<CostumerBasket>> UpdateItemQuantityAsync(string buyerId, int productId, int quantity);
        Task<ApiResponse<CostumerBasket>> ApplyCouponAsync(string buyerId, string couponCode, decimal discountRate);
        Task<ApiResponse<CostumerBasket>> RemoveCouponAsync(string buyerId);
        //Task<ApiResponse<BasketSummary>> GetBasketSummaryAsync(string buyerId);
        Task<ApiResponse<bool>> ValidateBasketAsync(string buyerId);
    }
}
