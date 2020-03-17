using OdeToFoodCoreCommon;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFoodCoreData
{
    public class InMemoryRestaurantData : IRestaurantData
    {

        private List<Restaurant> _restaurants;

        public InMemoryRestaurantData() 
        {
            _restaurants = new List<Restaurant>()
            {
                new Restaurant(){ Cuisine = CuisineType.Italian, Id = 1, Location="St. Louis, MO", Name="Giancarlo's Spegetti" },
                new Restaurant(){ Cuisine = CuisineType.Japanese, Id = 2, Location="Oak Brook, IL", Name="Kai Sushi" },
                new Restaurant(){ Cuisine = CuisineType.Mexican, Id = 3, Location="New York, New York", Name = "Scott's Tacos"}
                
            };
        
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants.OrderBy(r => r.Name);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string inName = null)
        {
            return from r in _restaurants
                   where string.IsNullOrEmpty(inName) || r.Name.StartsWith(inName)
                   orderby r.Name
                   select r;
                
        }


        public Restaurant GetById(int id) 
        {

            return _restaurants.SingleOrDefault(r => r.Id == id);

        }

        public Restaurant Update(Restaurant inUpdatedRestaurant)         
        {
            // located the right one to update
            var _r = _restaurants.SingleOrDefault(r => r.Id == inUpdatedRestaurant.Id);

            // mapping
            if (_r != null)
            {
                _r.Name = inUpdatedRestaurant.Name;
                _r.Location = inUpdatedRestaurant.Location;
                _r.Cuisine = inUpdatedRestaurant.Cuisine;                
            }

            return _r;
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant Add(Restaurant addRestaurant)
        {

           
            addRestaurant.Id = _restaurants.Max(r => r.Id + 1);
            _restaurants.Add(addRestaurant);
            return addRestaurant;

        }

    }


}
