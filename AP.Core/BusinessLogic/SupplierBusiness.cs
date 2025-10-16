using AP.Data.Models;
using AP.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.Core.BusinessLogic
{
    public interface ISupplierBusiness
    {
        Task<IEnumerable<Supplier>> GetSupplier(int? id);
        Task<bool> SaveSupplierAsync(Supplier supplier);
        Task<bool> DeleteSupplierAsync(int id);
    }

    public class SupplierBusiness(IRepositorySupplier repositorySupplier) : ISupplierBusiness
    {
        public async Task<IEnumerable<Supplier>> GetSupplier(int? id)
        {
            return id == null
                ? await repositorySupplier.ReadAsync()
                : [await repositorySupplier.FindAsync((int)id)];
        }

        public async Task<bool> SaveSupplierAsync(Supplier supplier)
        {
            supplier.LastModified = DateTime.Now;
            return await repositorySupplier.UpdateAsync(supplier);
        }

        public async Task<bool> DeleteSupplierAsync(int id)
        {
            var item = await repositorySupplier.FindAsync(id);
            return await repositorySupplier.DeleteAsync(item);
        }
    }
}
