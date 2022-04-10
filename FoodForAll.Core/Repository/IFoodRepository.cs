using FoodForAll.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodForAll.Core.Repository
{
    public interface IFoodRepository
    {
        public FoodModel CreateFood(FoodModel food);

        public IEnumerable<FoodModel> GetAllFoods();

        public FoodModel DeleteBook(int id);

        public FoodModel ReadById(int id);
    }
}
