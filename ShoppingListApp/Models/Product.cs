using System.ComponentModel;
using System.Windows.Input;
using ShoppingListApp.ViewModels;
using System;

namespace ShoppingListApp.Models
{
    [Serializable]
    public class Product
    {
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public string Unit { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public bool IsPurchased { get; set; }
    }

}
