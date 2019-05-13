using System;
using System.Threading.Tasks;
using EasyStore.Application.Interfaces;
using EasyStore.Application.Notifications.Models;

namespace EasyStore.Infrastructure.Notification
{
    public class NotificationService : INotificationService
    {
        public Task SendAsync(Message message)
        {
            return Task.CompletedTask;
        }
    }
}
