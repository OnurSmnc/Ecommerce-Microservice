using BasketService.Domain.DTOs.Resonses;
using BasketService.Domain.Entities;
using Shared.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketService.Application.Services
{
    public interface IBasketItemService
    {

        Task<ApiResponse<CostumerBasket>> GetBasketAsync(string buyerId);

        Task<ApiResponse<CostumerBasket>> SaveBasketAsync(CostumerBasket basket);

        Task<bool> DeleteBasketAsync(string buyerId);
    }
}
