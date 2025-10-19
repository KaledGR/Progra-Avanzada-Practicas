using AP.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.Data.Repositories
{
    public interface IProductRepository
    {

        IEnumerable<Product> GetAllProducts();
        Product getById(int id);
        void InsertProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);

        void save();

    }


    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;
        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }
        public Product getById(int id)
        {
            return _context.Products.Find(id);
        }
        public void InsertProduct(Product product)
        {
            _context.Products.Add(product);
        }
        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
        }
        public void DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
        }
        public void save()
        {
            _context.SaveChanges();
        }
    }

}
