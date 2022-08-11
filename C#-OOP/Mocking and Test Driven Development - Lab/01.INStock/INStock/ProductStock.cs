using INStock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INStock
{
    public class ProductStock : IProductStock
    {
        private ICollection<Product> products;
        private Product productAtIndex;

        public ProductStock()
        {
            this.products = new List<Product>();
        }
        public IProduct this[int index]
        {
            get
            {
                return productAtIndex = products.Skip(index).First();
            }
        }

        public int Count => products.Count();

        public void Add(IProduct product)
        {
            if (products.Contains(product))
            {
                throw new InvalidOperationException("Product alredy exist");
            }
            products.Add((Product)product);
        }

        public bool Contains(IProduct product)
        {
            return products.Contains(product);
        }

        public IProduct Find(int index)
        {
            if (this.Count<=index)
            {
                throw new InvalidOperationException("Index don't exist");
            }
            return this[index];
        }

        public IEnumerable<IProduct> FindAllByPrice(double price)
        {
            var productsByprice = new List<Product>();
            foreach (Product product in products)
            {
                if (product.Price == (decimal)price)
                {
                    productsByprice.Add(product);
                }
            }
            return productsByprice;

        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            var productsByQuantity = new List<Product>();
            foreach (Product product in products)
            {
                if (product.Price == (decimal)quantity)
                {
                    productsByQuantity.Add(product);
                }
            }
            return productsByQuantity;
        }

        public IEnumerable<IProduct> FindAllInPriceRange(double lo, double hi)
        {
            var productsInRange = new List<Product>();
            foreach (var product in products)
            {
                if (product.Price>= (decimal)lo &&product.Price<=(decimal)hi)
                {
                    productsInRange.Add(product);
                }
            }
            return productsInRange;

        }

        public IProduct FindByLabel(string label)
        {
            Product product = products.FirstOrDefault(p => p.Label == label);
            if (product == null)
            {
                throw new InvalidOperationException("Label dont exist");
            }
            return product;
            
        }

        public IProduct FindMostExpensiveProduct()
        {
            Product product = products.First();
            foreach (Product p in products)
            {
                if (p.Price>=product.Price)
                {
                    product = p;
                }
            }
            return product;
        }

        public IEnumerator<IProduct> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(IProduct product)
        {
            return products.Remove((Product)product);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
