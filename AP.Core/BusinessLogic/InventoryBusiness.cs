using AP.Data.Models;
using AP.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.Core.BusinessLogic
{
    public interface IInventoryBusiness
    {
        Task<IEnumerable<Inventory>> GetInventory(int? id);
        Task<bool> SaveInventoryAsync(Inventory inventory);
        Task<bool> DeleteInventoryAsync(int id);
    }

    public class InventoryBusiness(IRepositoryInventory repositoryInventory) : IInventoryBusiness
    {
        public async Task<IEnumerable<Inventory>> GetInventory(int? id)
        {
            return id == null
                ? await repositoryInventory.ReadAsync()
                : [await repositoryInventory.FindAsync((int)id)];
        }

        public async Task<bool> SaveInventoryAsync(Inventory inventory)
        {
            inventory.LastUpdated = DateTime.Now;
            return await repositoryInventory.UpdateAsync(inventory);
        }

        public async Task<bool> DeleteInventoryAsync(int id)
        {
            var inv = await repositoryInventory.FindAsync(id);
            return await repositoryInventory.DeleteAsync(inv);
        }
    }
}
