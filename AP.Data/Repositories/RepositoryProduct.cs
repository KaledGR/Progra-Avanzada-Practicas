using AP.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.Data.Repositories
{
    public interface IRepositoryProduct
    {
        Task<bool> UpsertAsync(Product entity, bool isUpdating);
        Task<bool> CreateAsync(Product entity);
        Task<bool> DeleteAsync(Product entity);
        Task<IEnumerable<Product>> ReadAsync();
        Task<Product> FindAsync(int id);
        Task<bool> UpdateAsync(Product entity);
        Task<bool> UpdateManyAsync(IEnumerable<Product> entities);
        Task<bool> ExistsAsync(Product entity);
        Task<bool> CheckBeforeSavingAsync(Product entity);
    }

    public class RepositoryProduct : RepositoryBase<Product>, IRepositoryProduct
    {
        public async Task<bool> CheckBeforeSavingAsync(Product entity)
        {
            var exists = await ExistsAsync(entity);
            return await UpsertAsync(entity, exists);
        }

        public async new Task<bool> ExistsAsync(Product entity)
        {
            return await DbContext.Products.AnyAsync(x => x.ProductId == entity.ProductId);
        }
    }
}
