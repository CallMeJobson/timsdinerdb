using DataLibrary.Data;
using DataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RPDemoApp.Pages.Orders
{
    public class CreateModel : PageModel
    {
        private readonly IFoodData _foodData;
        private readonly IOrderData _orderData;

        public List<SelectListItem>  FoodItems { get; set; }

        [BindProperty]
        public OrderModel Order { get; set; }
        public CreateModel(IFoodData foodData, IOrderData orderData)
        {
            _foodData = foodData;
            _orderData = orderData;
        }
        public async Task OnGet()
        {
            // this is from the Data library DLL 
            var food = await _foodData.GetFood();
            FoodItems = new List<SelectListItem>();

            food.ForEach(x => {
                //Value is what is going to be saved to the Datavase       Text is what the user sees
                
                FoodItems.Add(new SelectListItem { Value = x.Id.ToString(), Text = x.Title});

            });
        }


        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid == false)
            {
                return Page();
            }
            // Shortcut. Normal you would get the food by the id not get all of the food items 
            var food = await _foodData.GetFood();

            Order.Total = Order.Quantity * food.Where(x => x.Id == Order.FoodId).First().Price;

            int id = await _orderData.CreateOrder(Order);

            return RedirectToPage("./Display", new {Id = id});
        }
    }
}
