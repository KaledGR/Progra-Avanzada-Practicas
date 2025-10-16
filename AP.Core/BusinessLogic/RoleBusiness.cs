using AP.Data.Models;
using AP.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.Core.BusinessLogic
{
    public interface IRoleBusiness
    {
        Task<IEnumerable<Role>> GetRole(int? id);
        Task<bool> SaveRoleAsync(Role role);
        Task<bool> DeleteRoleAsync(int id);
    }

    public class RoleBusiness(IRepositoryRole repositoryRole) : IRoleBusiness
    {
        public async Task<IEnumerable<Role>> GetRole(int? id)
        {
            return id == null
                ? await repositoryRole.ReadAsync()
                : [await repositoryRole.FindAsync((int)id)];
        }

        public async Task<bool> SaveRoleAsync(Role role)
        {
            return await repositoryRole.UpdateAsync(role);
        }

        public async Task<bool> DeleteRoleAsync(int id)
        {
            var role = await repositoryRole.FindAsync(id);
            return await repositoryRole.DeleteAsync(role);
        }
    }
}
