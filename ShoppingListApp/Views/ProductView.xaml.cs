using ShoppingListApp.Models;
using System.Collections.ObjectModel;

namespace ShoppingListApp.Views
{
    public partial class ProductView : ContentView
    {
        public ProductView()
        {
            InitializeComponent();
        }

        private async void OnIncreaseQuantityClicked(object sender, EventArgs e)
        {
            var product = BindingContext as Product;
            if (product != null)
            {
                product.Quantity++;
            }
        }

        private async void OnDecreaseQuantityClicked(object sender, EventArgs e)
        {
            var product = BindingContext as Product;
            if (product != null && product.Quantity > 0)
            {
                product.Quantity--;
            }
        }

        private async void OnRemoveProductClicked(object sender, EventArgs e)
        {
            var product = BindingContext as Product;
            if (product != null)
            {
                var parent = this.Parent as ViewCell;
                if (parent != null)
                {
                    var listView = parent.Parent as ListView;
                    if (listView != null)
                    {
                        var products = listView.ItemsSource as ObservableCollection<Product>;
                        if (products != null)
                        {
                            products.Remove(product);
                            await ShoppingListApp.Services.DataService.SaveProductsAsync(products);
                        }
                    }
                }
            }
        }

        private async void OnTogglePurchasedClicked(object sender, EventArgs e)
        {
            var product = BindingContext as Product;
            if (product != null)
            {
                product.IsPurchased = !product.IsPurchased;

                var parent = this.Parent as ViewCell;
                if (parent != null)
                {
                    var listView = parent.Parent as ListView;
                    if (listView != null)
                    {
                        var products = listView.ItemsSource as ObservableCollection<Product>;
                        if (products != null)
                        {
                            products.Remove(product);
                            if (product.IsPurchased)
                            {
                                products.Add(product);
                            }
                            else
                            {
                                products.Insert(0, product);
                            }

                            listView.ItemsSource = null;
                            listView.ItemsSource = products;

                            await ShoppingListApp.Services.DataService.SaveProductsAsync(products);
                        }
                    }
                }
            }
        }

    }
}
