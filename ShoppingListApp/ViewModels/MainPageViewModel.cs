using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Input;
using System.Xml.Serialization;
using ShoppingListApp.Models;

namespace ShoppingListApp.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private static readonly string FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ShoppingListData.xml");

        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<Product> Products { get; set; }

        public string NewCategoryName { get; set; }
        public string NewProductName { get; set; }
        public int NewProductQuantity { get; set; }
        public string NewProductUnit { get; set; }
        public Category SelectedCategory { get; set; }

        public ICommand AddCategoryCommand { get; }
        public ICommand AddProductCommand { get; }
        public ICommand RemoveProductCommand { get; }
        public ICommand IncreaseQuantityCommand { get; }
        public ICommand DecreaseQuantityCommand { get; }

        public MainPageViewModel()
        {
            Categories = new ObservableCollection<Category>();
            Products = new ObservableCollection<Product>();

            AddCategoryCommand = new Command(AddCategory);
            AddProductCommand = new Command(AddProduct);
            RemoveProductCommand = new Command<Product>(RemoveProduct);
            IncreaseQuantityCommand = new Command<Product>(IncreaseQuantity);
            DecreaseQuantityCommand = new Command<Product>(DecreaseQuantity);

            LoadFromXml();

            Products.CollectionChanged += (_, __) => SaveToXml();
            Categories.CollectionChanged += (_, __) => SaveToXml();
        }

        private void AddCategory()
        {
            if (!string.IsNullOrWhiteSpace(NewCategoryName))
            {
                Categories.Add(new Category { Name = NewCategoryName });
                NewCategoryName = string.Empty;
                OnPropertyChanged(nameof(NewCategoryName));
                SaveToXml(); // Save after adding a new category
            }
        }

        private void AddProduct()
        {
            if (SelectedCategory != null && !string.IsNullOrWhiteSpace(NewProductName))
            {
                Products.Add(new Product
                {
                    Name = NewProductName,
                    Quantity = NewProductQuantity,
                    Unit = NewProductUnit,
                    IsPurchased = false,
                    CategoryName = SelectedCategory.Name
                });

                NewProductName = string.Empty;
                NewProductQuantity = 0;
                NewProductUnit = string.Empty;
                OnPropertyChanged(nameof(NewProductName));
                OnPropertyChanged(nameof(NewProductQuantity));
                OnPropertyChanged(nameof(NewProductUnit));
                SaveToXml(); // Save after adding a new product
            }
        }

        private void RemoveProduct(Product product)
        {
            if (Products.Contains(product))
            {
                Products.Remove(product);
                SaveToXml(); // Save after removing a product
            }
        }

        private void IncreaseQuantity(Product product)
        {
            if (product != null)
            {
                product.Quantity++;
                SortProducts();
                OnPropertyChanged(nameof(Products));
                SaveToXml(); // Save after changing quantity
            }
        }

        private void DecreaseQuantity(Product product)
        {
            if (product != null && product.Quantity > 0)
            {
                product.Quantity--;
                SortProducts();
                OnPropertyChanged(nameof(Products));
                SaveToXml(); // Save after changing quantity
            }
        }

        private void SortProducts()
        {
            var sortedProducts = Products.OrderBy(p => p.IsPurchased).ThenByDescending(p => p.Quantity).ToList();
            Products.Clear();
            foreach (var product in sortedProducts)
            {
                Products.Add(product);
            }
        }

        private void SaveToXml()
        {
            try
            {
                var data = new ShoppingListData
                {
                    Categories = Categories.ToList(),
                    Products = Products.ToList()
                };

                using var writer = new StreamWriter(FilePath);
                var serializer = new XmlSerializer(typeof(ShoppingListData));
                serializer.Serialize(writer, data);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving data: {ex.Message}");
            }
        }

        private void LoadFromXml()
        {
            if (!File.Exists(FilePath)) return;

            try
            {
                using var reader = new StreamReader(FilePath);
                var serializer = new XmlSerializer(typeof(ShoppingListData));
                var data = (ShoppingListData)serializer.Deserialize(reader);

                Categories = new ObservableCollection<Category>(data.Categories);
                Products = new ObservableCollection<Product>(data.Products);

                OnPropertyChanged(nameof(Categories));
                OnPropertyChanged(nameof(Products));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading data: {ex.Message}");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    [Serializable]
    public class ShoppingListData
    {
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
    }
}
