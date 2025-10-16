using AP.Data.Models;
using AP.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.Core.BusinessLogic
{
    public interface IUserBusiness
    {
        Task<IEnumerable<User>> GetUser(int? id);
        Task<bool> SaveUserAsync(User user);
        Task<bool> DeleteUserAsync(int id);
    }

    public class UserBusiness(IRepositoryUser repositoryUser) : IUserBusiness
    {
        public async Task<IEnumerable<User>> GetUser(int? id)
        {
            return id == null
                ? await repositoryUser.ReadAsync()
                : [await repositoryUser.FindAsync((int)id)];
        }

        public async Task<bool> SaveUserAsync(User user)
        {
            user.LastModified = DateTime.Now;
            return await repositoryUser.UpdateAsync(user);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await repositoryUser.FindAsync(id);
            return await repositoryUser.DeleteAsync(user);
        }
    }
}
