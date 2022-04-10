using FoodForAll.Core.Entity;
using FoodForAll.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodForAll.Infrastructure.Repository
{
    public class FoodRepository : IFoodRepository
    {
        private static List<FoodModel> _foods = new List<FoodModel>();

        public FoodRepository()
        {
            InitData();
        }

        private void InitData()
        {
            var food1 = new FoodModel()
            {
                id = 0,
                name = "Колбаса",
                price = "250",
                type = "Мясо"
            };
            CreateFood(food1);

            var food2 = new FoodModel()
            {
                id = 1,
                name = "Молоко",
                price = "75",
                type = "Молочное"
            };
            CreateFood(food2);

            var food3 = new FoodModel()
            {
                id=2,
                name = "Батон",
                price = "35",
                type = "Хлеб"
            };
            CreateFood(food3);
        }

        public FoodModel CreateFood(FoodModel food)
        {
            _foods.Add(food);
            return food;
        }

        public FoodModel DeleteBook(int id)
        {
            var deleteFood = this.ReadById(id);
            if (deleteFood != null)
            {
                _foods.Remove(deleteFood);
                return deleteFood;
            }
            return null;
        }

        public IEnumerable<FoodModel> GetAllFoods()
        {
            return _foods;
        }

        public FoodModel ReadById(int id)
        {
            foreach (var food in _foods)
            {
                if (food.id == id)
                {
                    return food;
                }
            }
            return null;
        }
    }
}
