﻿using AvtoMigBussines.Models;

namespace AvtoMigBussines.Repositories.Interfaces
{
    public interface INotificationCenterRepository
    {
        Task<NotificationCenter> GetByIdAsync(int id);
        Task<IEnumerable<NotificationCenter>> GetAllAsync();
        Task AddAsync(NotificationCenter notificationCenter);
        Task UpdateAsync(NotificationCenter notificationCenter);
        Task DeleteAsync(int id);
        Task<bool> ExistsWithName(string name);
    }
}