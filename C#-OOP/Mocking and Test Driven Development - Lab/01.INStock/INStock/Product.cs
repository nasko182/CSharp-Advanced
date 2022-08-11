using INStock.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace INStock
{
    public class Product : IProduct
    {
        private string label;
        private int quantity;
        private decimal price;

        public Product(string label, int quantity, decimal price)
        {
            this.Label = label;
            this.Quantity = quantity;
            this.Price = price;
        }

        public string Label
        {
            get => label;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Label cannot be null or whitespace");
                }
                label = value;
            }
        }

        public decimal Price
        {
            get => price;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price must be bigger than zero");
                }
                price = value;
            }
        }
        public int Quantity
        {
            get => quantity;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Quantity must be positive number");
                }
                quantity = value;
            }
        }

        public int CompareTo([AllowNull] IProduct other)
        {
            if (this.Price == other.Price)
            {
                return 0;
            }
            else if (this.Price < other.Price)
            {
                return -1;
            }
            return 1;
        }
    }
}
