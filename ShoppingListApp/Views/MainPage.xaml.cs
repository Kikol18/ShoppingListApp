using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingListApp.Models;
using ShoppingListApp.Services;
using System.Collections.ObjectModel;

namespace ShoppingListApp.Views
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Product> Products { get; private set; }

        public MainPage()
        {
            InitializeComponent();
            Products = new ObservableCollection<Product>();
            ProductsListView.ItemsSource = Products;
            LoadProductsFromFile();
        }

        private async void OnAddProductClicked(object sender, EventArgs e)
        {
            string name = ProductNameEntry.Text;
            string unit = ProductUnitEntry.Text;
            bool quantityParsed = int.TryParse(ProductQuantityEntry.Text, out int quantity);

            if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(unit) && quantityParsed)
            {
                var newProduct = new Product { Name = name, Unit = unit, Quantity = quantity, IsPurchased = false };
                Products.Insert(0, newProduct);
                await DataService.SaveProductsAsync(Products);

                ProductNameEntry.Text = string.Empty;
                ProductUnitEntry.Text = string.Empty;
                ProductQuantityEntry.Text = string.Empty;
            }
            else
            {
                await DisplayAlert("Błąd", "Proszę wprowadzić poprawne dane.", "OK");
            }
        }

        private async void LoadProductsFromFile()
        {
            var loadedProducts = await DataService.LoadProductsAsync();
            foreach (var product in loadedProducts)
            {
                Products.Add(product);
            }
        }
    }
}
