using System.ComponentModel;
using System.Windows.Input;
using ShoppingListApp.ViewModels;
using System;

namespace ShoppingListApp.Models
{
    [Serializable]
    public class Product
    {
        public required string Name { get; set; }
        public int Quantity { get; set; }
        public required string Unit { get; set; }
        public required string CategoryName { get; set; }
        public bool IsPurchased { get; set; }
    }

}
