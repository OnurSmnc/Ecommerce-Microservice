using BasketService.Application.Services;
using BasketService.Domain.Entities;
using Shared.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketService.Application.Services.Concrete
{
    public class CostumerBasketService : ICostumerBasketService
    {
        private readonly IBasketItemService _basketService;
        public CostumerBasketService(IBasketItemService basketService)
        {
            _basketService = basketService;
        }
        public async Task<ApiResponse<CostumerBasket>> AddItemAsync(string buyerId, BasketItem item)
        {
            var response = await _basketService.GetBasketAsync(buyerId);

            var basket = (response != null && response.Data != null)
                ? response.Data
                : new CostumerBasket { BuyerId = buyerId, Items = new List<BasketItem>() };

            if (basket.Items == null)
            {
                basket.Items = new List<BasketItem>();
            }

            var existingItem = basket.Items.FirstOrDefault(x => x.ProductId == item.ProductId);
            if (existingItem != null)
            {
                existingItem.Quantity += item.Quantity;
            }
            else
            {
                basket.Items.Add(item);
            }

            return await _basketService.SaveBasketAsync(basket);
        }

        public Task<ApiResponse<CostumerBasket>> ApplyCouponAsync(string buyerId, string couponCode)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<CostumerBasket>> GetBasketAsync(string buyerId)
        {
            var basket = await _basketService.GetBasketAsync(buyerId);
            if (basket == null) return ApiResponse<CostumerBasket>.FailureResponse(404 ,"Sepet bulunamadı.");
            return basket;
        }

        public Task<ApiResponse<CostumerBasket>> RemoveCouponAsync(string buyerId)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<CostumerBasket>> RemoveItemAsync(string buyerId, int productId)
        {

            //basket.Items.Remove(item);
            throw new NotImplementedException();
            //return await _basketService.SaveBasketAsync(basket);
        }

        public async Task<ApiResponse<CostumerBasket>> UpdateItemQuantityAsync(string buyerId, int productId, int quantity)
        {
            var response = await _basketService.GetBasketAsync(buyerId);
            if (response == null) return ApiResponse<CostumerBasket>.FailureResponse(404, "Sepet bulunamadı.");

            var basket = response.Data;
            var item = basket.Items.FirstOrDefault(x => x.ProductId == productId);
            if (item == null) return ApiResponse<CostumerBasket>.FailureResponse(404, "Ürün sepette bulunamadı.");

            if (quantity <= 0)
            {
                //RemoveItemAsync(buyerId, productId, basket, item);
                basket.Items.Remove(item);
            }
            else
            {
                item.Quantity = quantity;
            }

            if (basket.Items.Count == 0) await _basketService.DeleteBasketAsync(buyerId);
            
            return await _basketService.SaveBasketAsync(basket);
        }

        public Task<ApiResponse<bool>> ValidateBasketAsync(string buyerId)
        {
            throw new NotImplementedException();
        }
    }
}
