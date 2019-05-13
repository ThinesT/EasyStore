using System;
using System.Threading.Tasks;
using EasyStore.Application.Notifications.Models;

namespace EasyStore.Application.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(Message message);
    }
}
