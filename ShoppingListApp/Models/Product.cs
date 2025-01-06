using System.ComponentModel;
using System.Windows.Input;
using ShoppingListApp.ViewModels;
using System;

namespace ShoppingListApp.Models
{
    [Serializable]
    public class Product
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public bool IsPurchased { get; set; }
        public string CategoryName { get; set; } // Używamy nazwy kategorii jako odwołania
    }
}
