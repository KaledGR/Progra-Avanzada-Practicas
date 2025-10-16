using AP.Data.Models;
using AP.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.Core.BusinessLogic
{
    public interface INotificationBusiness
    {
        Task<IEnumerable<Notification>> GetNotification(int? id);
        Task<bool> SaveNotificationAsync(Notification notification);
        Task<bool> DeleteNotificationAsync(int id);
    }

    public class NotificationBusiness(IRepositoryNotification repositoryNotification) : INotificationBusiness
    {
        public async Task<IEnumerable<Notification>> GetNotification(int? id)
        {
            return id == null
                ? await repositoryNotification.ReadAsync()
                : [await repositoryNotification.FindAsync((int)id)];
        }

        public async Task<bool> SaveNotificationAsync(Notification notification)
        {
            
            return await repositoryNotification.UpdateAsync(notification);
        }

        public async Task<bool> DeleteNotificationAsync(int id)
        {
            var notif = await repositoryNotification.FindAsync(id);
            return await repositoryNotification.DeleteAsync(notif);
        }
    }
}
