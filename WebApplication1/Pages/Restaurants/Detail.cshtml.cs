using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace WebApplication1.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        public Restaurant restaurant { get; set; }
        public IActionResult OnGet(int restaurantId)
        {
            restaurant = restaurantData.GetById(restaurantId);
            if(restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
            
        }
        public DetailModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }
    }
}