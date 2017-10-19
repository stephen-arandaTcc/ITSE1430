using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile.Stores
{
    /// <summary>Base class for product database.</summary>
    public class MemoryProductDatabase : ProductDatabase 
    {
        public MemoryProductDatabase ()
        {
            //Long way
            //var product = new Product();
            //product.Name = "Samsung Note 7";
            //product.Price = 150;
            //product.IsDiscontinued = true;
            //Add(product);

            //Object initializer syntax
            //_products.Add(new Product() { Id = 1, Name = "Galaxy S7", Price = 650 });
            //_products.Add(new Product() { Id = 2, Name = "Galaxy Note 7", Price = 150, IsDiscontinued = true });
            //_products.Add(new Product() { Id = 3, Name = "Windows Phone", Price = 100 });
            //_products.Add(new Product() { Id = 4, Name = "iPhone X", Price = 1900, IsDiscontinued = true });

            //Collection initializer syntax
            //_products = new List<Product>() { 
            //    new Product() { Id = 1, Name = "Galaxy S7", Price = 650 },
            //    new Product() { Id = 2, Name = "Galaxy Note 7", Price = 150, IsDiscontinued = true },
            //    new Product() { Id = 3, Name = "Windows Phone", Price = 100 },
            //    new Product() { Id = 4, Name = "iPhone X", Price = 1900, IsDiscontinued = true },
            //};

            //Collection initializer syntax with array
            _products.AddRange(new [] {
                new Product() { Id = 1, Name = "Galaxy S7", Price = 650 },
                new Product() { Id = 2, Name = "Galaxy Note 7", Price = 150, IsDiscontinued = true },
                new Product() { Id = 3, Name = "Windows Phone", Price = 100 },
                new Product() { Id = 4, Name = "iPhone X", Price = 1900, IsDiscontinued = true },
            });            

            _nextId = _products.Count + 1;
        }

        /// <summary>Adds a product.</summary>
        /// <param name="product">The product to add.</param>
        /// <returns>The added product.</returns>
        protected override Product AddCore ( Product product )
        {
            var newProduct = CopyProduct(product);
            _products.Add(newProduct);

            if (newProduct.Id <= 0)
                newProduct.Id = _nextId++;
            else if (newProduct.Id >= _nextId)
                _nextId = newProduct.Id + 1;

            return CopyProduct(newProduct);
        }

        /// <summary>Get a specific product.</summary>
        /// <returns>The product, if it exists.</returns>
       protected override Product GetCore ( int id )
        {            

            var product = FindProduct(id);

            return (product != null) ? CopyProduct(product) : null;
        }

        /// <summary>Gets all products.</summary>
        /// <returns>The products.</returns>
        protected override IEnumerable<Product> GetAllCore ()
        {
            
            foreach (var product in _products)
               yield return  CopyProduct(product);
           
            //How many products?
            //var count = 0;
            //foreach (var product in _products)
            //{
            //    if (product != null)
            //        ++count;
            //};

            //var items = new Product[count];
            //var index = 0;

            //foreach (var product in _products)
            //{
            //    if (product != null)
            //        //product = new Product();
            //        items[index++] = CopyProduct(product);
            //};

            //return items;
        }

        /// <summary>Removes the product.</summary>
        /// <param name="product">The product to remove.</param>
        protected override void RemoveCore ( int id )
        {
           

            var product = FindProduct(id);
            if (product != null)
                _products.Remove(product);

            //if (_list[index].Name == product.Name)
            //{
            //    _list.RemoveAt(index);
            //    break;
            //};        
        }

        /// <summary>Updates a product.</summary>
        /// <param name="product">The product to update.</param>
        /// <returns>The updated product.</returns>
        protected override Product UpdateCore ( Product existing, Product product )
        {           
            //Replace 
            _products.Remove(existing);
            
            var newProduct = CopyProduct(product);
            _products.Add(newProduct);

            return CopyProduct(newProduct);
        }

       
        private Product CopyProduct ( Product product )
        {
            if (product == null)
                return null;

            var newProduct = new Product();
            newProduct.Id = product.Id;
            newProduct.Name = product.Name;
            newProduct.Price = product.Price;
            newProduct.IsDiscontinued = product.IsDiscontinued;

            return newProduct;
        }

        //Find a product by ID
        private Product FindProduct ( int id )
        {
            foreach (var product in _products)
            {
                if (product.Id == id)
                    return product;
            };

            return null;
        }

        //private Product[] _products = new Product[100];
        private List<Product> _products = new List<Product>();
        private int _nextId = 1;
        //private List<int> _ints;
    }
}
