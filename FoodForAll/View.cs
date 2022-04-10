using FoodForAll.Core.Entity;
using FoodForAll.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodForAll.UI
{
    public class View : IView
    {
        private readonly IFoodRepository _foodRepository;
        int id = 3;

        public View(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public void StartView()
        {
            string[] menuItems =
{
                "Показать все продукты",
                "Добавить продукт",
                "Удалить продукт"
            };

            var choice = ShowMenu(menuItems);

            while (choice != 4)
            {
                switch (choice)
                {
                    case 1:
                        GetAllFood();
                        break;
                    case 2:
                        AddFood();
                        break;
                    case 3:
                        DeleteFood();
                        break;
                }
                choice = ShowMenu(menuItems);
            }
        }

        private void DeleteFood()
        {
            Console.WriteLine("Введите ID продукта: ");
            var idDelete = int.Parse(Console.ReadLine());
            _foodRepository.DeleteBook(idDelete);
        }

        private void AddFood()
        {
            Console.WriteLine("Название: ");
            var name = Console.ReadLine();
            Console.WriteLine("Тип: ");
            var type = Console.ReadLine();
            Console.WriteLine("Цена: ");
            var price = Console.ReadLine();

            var newFood = new FoodModel()
            {
                id = id,
                name = name,
                type = type,
                price = price
            }; 
            id++;

            _foodRepository.CreateFood(newFood);
        }

        private void GetAllFood()
        {
            var food = _foodRepository.GetAllFoods();
            Console.WriteLine("Весь список продуктов:");
            foreach (var foodItem in food)
            {
                Console.WriteLine($"ID: {foodItem.id}\n Название: {foodItem.name}\n Тип: {foodItem.type}\n Цена: {foodItem.price}");
            }
        }

        private int ShowMenu(string[] menuItems)
        {
            Console.WriteLine("Выберите действие:");
            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine($"{i + 1}: {menuItems[i]}");
            }

            int choice;

            while (!int.TryParse(Console.ReadLine(), out choice)
                || choice < 1
                || choice > 4)
            {
                Console.WriteLine("Пожалуйста, введите число от 1-3");
            }

            return choice;
        }
    }
}
