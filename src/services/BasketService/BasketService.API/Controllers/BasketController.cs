using BasketService.Application.Services;
using BasketService.Application.Services.Concrete;
using BasketService.Domain.DTOs.Requests;
using BasketService.Domain.DTOs.Resonses;
using BasketService.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BasketService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasketController : Controller
    {
        private readonly IBasketItemService _basketItemService;
        private readonly ICostumerBasketService _costumerBasketService;
        public BasketController(IBasketItemService basketItemService, ICostumerBasketService costumerBasketService)
        {
            _basketItemService = basketItemService;
            _costumerBasketService = costumerBasketService;
        }

        [HttpGet("{buyerId}")]
        public async Task<ActionResult<CostumerBasket>> GetBasketByIdAsync(string buyerId)
        {
            var response = await _costumerBasketService.GetBasketAsync(buyerId);

            if (response == null || response.Data == null)
            {
                return NotFound(response?.Message ?? "Sepet bulunamadı.");
            }
            return Ok(response.Data);
        }

        [HttpPost("{buyerId}/items")]
        public async Task<IActionResult> AddItem(string buyerId, AddBasketItemRequest request)
        {
            var item = new BasketItem(  
                request.ProductId,
                request.ProductName,
                request.Price,
                request.Quantity
            );

            var result = await _costumerBasketService.AddItemAsync(buyerId, item);
            if (result == null) return BadRequest();
            return Ok(result);
        }

        [HttpDelete("{buyerId}")]
        public async Task<IActionResult> DeleteBasketByIdAsync(string buyerId)
        {
            var result = await _basketItemService.DeleteBasketAsync(buyerId);
            if (!result)
            {
                return BadRequest("Sepet silinirken bir hata oluştu veya sepet bulunamadı.");
            }
            return Ok();
        }
    }
}
