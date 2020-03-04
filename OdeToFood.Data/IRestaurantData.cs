using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);

    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id =1, Name = "Vanila Pizza", Location="Vietnam", Cuisine = CuisineType.Mexican},
                new Restaurant { Id =2, Name = "BoolRealCool", Location="Vietnam", Cuisine = CuisineType.Italian},
                new Restaurant { Id =3, Name = "Four", Location="Vietnam", Cuisine = CuisineType.Indian }
            };
        }
        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            return from r in restaurants 
                   where string.IsNullOrEmpty(name) 
                   || r.Name.StartsWith(name) 
                   orderby r.Name 
                   select r;
        }
    }
}

