using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using ShoppingListApp.Models;

namespace ShoppingListApp.Services
{
    public static class DataService
    {
        private static readonly string filePath = Path.Combine(FileSystem.AppDataDirectory, "products.json");

        public static async Task SaveProductsAsync(ObservableCollection<Product> products)
        {
            var json = JsonSerializer.Serialize(products);
            await File.WriteAllTextAsync(filePath, json);
        }

        public static async Task<ObservableCollection<Product>> LoadProductsAsync()
        {
            if (File.Exists(filePath))
            {
                var json = await File.ReadAllTextAsync(filePath);
                var products = JsonSerializer.Deserialize<ObservableCollection<Product>>(json);
                return products ?? new ObservableCollection<Product>();
            }
            return new ObservableCollection<Product>();
        }
    }
}