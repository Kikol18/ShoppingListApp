using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Input;
using System.Xml.Serialization;
using ShoppingListApp.Models;

namespace ShoppingListApp.ViewModels;

public class MainPageViewModel : BaseViewModel
{
    private const string FilePath = "ShoppingList.xml";

    public ObservableCollection<Category> Categories { get; set; } = new ObservableCollection<Category>();
    public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();

    public string NewCategoryName { get; set; } = string.Empty;
    public string NewProductName { get; set; } = string.Empty;
    public string NewProductUnit { get; set; } = string.Empty;
    public Category? SelectedCategory { get; set; }

    public ICommand AddCategoryCommand { get; }
    public ICommand AddProductCommand { get; }
    public ICommand IncreaseQuantityCommand { get; }
    public ICommand DecreaseQuantityCommand { get; }
    public ICommand DeleteProductCommand { get; }

    public MainPageViewModel()
    {
        AddCategoryCommand = new Command(AddCategory);
        AddProductCommand = new Command(AddProduct);
        IncreaseQuantityCommand = new Command<Product>(IncreaseQuantity);
        DecreaseQuantityCommand = new Command<Product>(DecreaseQuantity);
        DeleteProductCommand = new Command<Product>(DeleteProduct);

        LoadData();
        InitializeDefaultCategories();
    }

    private void InitializeDefaultCategories()
    {
        if (Categories.Count == 0)
        {
            Categories.Add(new Category { Name = "Fruits" });
            Categories.Add(new Category { Name = "Vegetables" });
            Categories.Add(new Category { Name = "Dairy" });
        }
    }

    private void AddCategory()
    {
        if (!string.IsNullOrWhiteSpace(NewCategoryName))
        {
            Categories.Add(new Category { Name = NewCategoryName });
            NewCategoryName = string.Empty;
            OnPropertyChanged(nameof(NewCategoryName));
        }
    }

    private void AddProduct()
    {
        if (SelectedCategory != null && !string.IsNullOrWhiteSpace(NewProductName))
        {
            Products.Add(new Product
            {
                Name = NewProductName,
                Quantity = 1,
                Unit = NewProductUnit,
                CategoryName = SelectedCategory.Name,
                IsPurchased = false
            });
            NewProductName = string.Empty;
            NewProductUnit = string.Empty;
            OnPropertyChanged(nameof(NewProductName));
            OnPropertyChanged(nameof(NewProductUnit));
            SaveData();
        }
    }

    private void IncreaseQuantity(Product? product)
    {
        if (product != null)
        {
            product.Quantity++;
            SortProducts();
            OnPropertyChanged(nameof(Products));
            SaveData();
        }
    }

    private void DecreaseQuantity(Product? product)
    {
        if (product != null && product.Quantity > 0)
        {
            product.Quantity--;
            SortProducts();
            OnPropertyChanged(nameof(Products));
            SaveData();
        }
    }

    private void DeleteProduct(Product? product)
    {
        if (product != null)
        {
            Products.Remove(product);
            SaveData();
        }
    }

    private void SortProducts()
    {
        var sortedProducts = Products
            .OrderBy(p => p.IsPurchased)
            .ThenBy(p => p.Quantity == 0)
            .ThenBy(p => p.Name)
            .ToList();

        Products.Clear();
        foreach (var product in sortedProducts)
        {
            Products.Add(product);
        }
    }

    private void SaveData()
    {
        try
        {
            using var writer = new StreamWriter(FilePath);
            var serializer = new XmlSerializer(typeof(ObservableCollection<Product>));
            serializer.Serialize(writer, Products);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving data: {ex.Message}");
        }
    }

    private void LoadData()
    {
        try
        {
            if (File.Exists(FilePath))
            {
                using var reader = new StreamReader(FilePath);
                var serializer = new XmlSerializer(typeof(ObservableCollection<Product>));
                var loadedProducts = serializer.Deserialize(reader) as ObservableCollection<Product>;
                Products = loadedProducts ?? new ObservableCollection<Product>();
                OnPropertyChanged(nameof(Products));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading data: {ex.Message}");
        }
    }

}

