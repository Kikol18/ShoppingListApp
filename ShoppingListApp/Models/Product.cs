using System.ComponentModel;

namespace ShoppingListApp.Models
{
    public class Product : INotifyPropertyChanged
    {
        private string name;
        private string unit;
        private int quantity;
        private bool isPurchased;

        public string Name
        {
            get => name;
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public string Unit
        {
            get => unit;
            set
            {
                if (unit != value)
                {
                    unit = value;
                    OnPropertyChanged(nameof(Unit));
                }
            }
        }

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

        public bool IsPurchased
        {
            get => isPurchased;
            set
            {
                if (isPurchased != value)
                {
                    isPurchased = value;
                    OnPropertyChanged(nameof(IsPurchased));
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}