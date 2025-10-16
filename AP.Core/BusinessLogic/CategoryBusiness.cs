using AP.Data.Models;
using AP.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.Core.BusinessLogic
{
    public interface ICategoryBusiness
    {
        Task<IEnumerable<Category>> GetCategory(int? id);
        Task<bool> SaveCategoryAsync(Category category);
        Task<bool> DeleteCategoryAsync(int id);
    }

    public class CategoryBusiness(IRepositoryCategory repositoryCategory) : ICategoryBusiness
    {
        public async Task<IEnumerable<Category>> GetCategory(int? id)
        {
            return id == null
                ? await repositoryCategory.ReadAsync()
                : [await repositoryCategory.FindAsync((int)id)];
        }

        public async Task<bool> SaveCategoryAsync(Category category)
        {
            
            category.LastModified = DateTime.Now;
            return await repositoryCategory.UpdateAsync(category);
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var item = await repositoryCategory.FindAsync(id);
            return await repositoryCategory.DeleteAsync(item);
        }
    }
}
