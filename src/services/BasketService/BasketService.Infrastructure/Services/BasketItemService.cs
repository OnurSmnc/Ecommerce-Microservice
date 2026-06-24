using BasketService.Application.Services;
using BasketService.Domain.DTOs.Resonses;
using BasketService.Domain.Entities;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Shared.Common.Models;


namespace BasketService.Infrastructure.Services 
{
    public class BasketItemService : IBasketItemService
    {
        private readonly IDatabase _database;
        public BasketItemService(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }
        public async Task<ApiResponse<DeleteItemResponse>> DeleteBasketAsync(string buyerId)
        {
            bool isDeleted = await _database.KeyDeleteAsync(GetRedisKey(buyerId));
            var returnResponse = isDeleted == true ? ApiResponse<DeleteItemResponse>.SuccessResponse(data: null, message: "Customer basket deleted succesfully")
                : ApiResponse<DeleteItemResponse>.FailureResponse(statusCode: 404, message: "Customer basket not found");
            return returnResponse;
        }

        public async Task<ApiResponse<CostumerBasket>> GetBasketAsync(string buyerId)
        {
            var data = await _database.StringGetAsync(GetRedisKey(buyerId));
            if (data.IsNullOrEmpty) return null;
            var response = JsonSerializer.Deserialize<CostumerBasket>((string)data);
            return ApiResponse<CostumerBasket>.SuccessResponse(response);

        }

        public async Task<ApiResponse<CostumerBasket>> SaveBasketAsync(CostumerBasket basket)
        {
            var jsonBasket = JsonSerializer.Serialize(basket);

            var saved = await _database.StringSetAsync(GetRedisKey(basket.BuyerId), jsonBasket);
            if (!saved) return null;

            return await GetBasketAsync(basket.BuyerId);
        }

        private string GetRedisKey(string buyerId) => $"basket:{buyerId}";
    }
}
