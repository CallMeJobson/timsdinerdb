using DataLibrary.Data;
using DataLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodData _foodData;
        private readonly IOrderData _orderData;

        public FoodController(IFoodData foodData, IOrderData orderData)
        {
            _foodData = foodData;
          _orderData = orderData;
        }

        [HttpGet]
        public async Task<List<FoodModel>> Get()
        {
            return await _foodData.GetFood();
        }
    }
}
