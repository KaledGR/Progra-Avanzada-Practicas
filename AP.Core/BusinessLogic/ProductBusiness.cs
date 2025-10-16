using AP.Data.Models;
using AP.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.Core.BusinessLogic
{
    public interface IProductBusiness
    {
        Task<IEnumerable<Product>> GetProduct(int? id);
        Task<bool> SaveProductAsync(Product product);
        Task<bool> DeleteProductAsync(int id);
    }

    public class ProductBusiness(IRepositoryProduct repositoryProduct) : IProductBusiness
    {
        public async Task<IEnumerable<Product>> GetProduct(int? id)
        {
            return id == null
                ? await repositoryProduct.ReadAsync()
                : [await repositoryProduct.FindAsync((int)id)];
        }

        public async Task<bool> SaveProductAsync(Product product)
        {
            product.LastModified = DateTime.Now;
            return await repositoryProduct.UpdateAsync(product);
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await repositoryProduct.FindAsync(id);
            return await repositoryProduct.DeleteAsync(product);
        }
    }
}
