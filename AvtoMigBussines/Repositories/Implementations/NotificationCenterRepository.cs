﻿using AvtoMigBussines.Data;
using AvtoMigBussines.Models;
using AvtoMigBussines.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AvtoMigBussines.Repositories.Implementations
{
    public class NotificationCenterRepository : INotificationCenterRepository
    {
        private readonly ApplicationDbContext context;
        public NotificationCenterRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task AddAsync(NotificationCenter notificationCenter)
        {
            await context.NotificationCenters.AddAsync(notificationCenter);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistsWithName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<NotificationCenter>> GetAllAsync()
        {
            return await context.NotificationCenters.Where(p => p.IsDeleted == false).ToListAsync();
        }

        public async Task<NotificationCenter> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(NotificationCenter notificationCenter)
        {
            throw new NotImplementedException();
        }
    }
}