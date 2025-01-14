using System.ComponentModel;
using System.Windows.Input;
using ShoppingListApp.ViewModels;
using System;

namespace ShoppingListApp.Models
{
    [Serializable]
    public class Product : INotifyPropertyChanged
    {
        private int quantity;
        public event PropertyChangedEventHandler PropertyChanged;
        public string Name { get; set; } = string.Empty;
        public int Quantity
        {
            get => quantity;
            set
            {
                if (quantity != value)
                {
                    quantity = value;
                    OnPropertyChanged(nameof(Quantity));
                }
            }
        }
        public string Unit { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public bool IsPurchased { get; set; }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
