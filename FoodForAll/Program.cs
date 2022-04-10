using FoodForAll.Core.Repository;
using FoodForAll.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace FoodForAll.UI
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IFoodRepository, FoodRepository>();
            serviceCollection.AddScoped<IView, View>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var view = serviceProvider.GetRequiredService<IView>();

            view.StartView();
        }
    }
}