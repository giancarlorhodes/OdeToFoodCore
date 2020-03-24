using OdeToFoodCoreCommon;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFoodCoreData
{
    public class SqlRestaurantData : IRestaurantData
    {

        private readonly OdeToFoodDbContext _dbcontext;

        public SqlRestaurantData(OdeToFoodDbContext context)
        {
            this._dbcontext = context;
        }

        public Restaurant Add(Restaurant addRestaurant)
        {
            _dbcontext.Add(addRestaurant);
            return addRestaurant;
        }

        public int Commit()
        {
           return _dbcontext.SaveChanges();
        }

        public Restaurant Delete(int deleteRestaurantId)
        {
            var _r = GetById(deleteRestaurantId);
            if (_r != null)
            {
                _dbcontext.Restaurants.Remove(_r);           
            }
            return _r;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            throw new NotImplementedException();
        }

        public Restaurant GetById(int id)
        {
            return _dbcontext.Restaurants.Find(id);
        }

        public int GetCountOfRestaurants()
        {
            return _dbcontext.Restaurants.Count();
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string inName)
        {
            var _query = from _r in _dbcontext.Restaurants
                         where _r.Name.StartsWith(inName) || string.IsNullOrEmpty(inName)
                         orderby _r.Name
                         select _r;
            return _query;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var _entity = _dbcontext.Restaurants.Attach(updatedRestaurant);
            _entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return updatedRestaurant;
        }
    }
}
