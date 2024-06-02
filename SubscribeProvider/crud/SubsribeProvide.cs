using Data.DataContexts;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class SubscribeProvide
{
    private readonly DataContext _context;

    public SubscribeProvide(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<NotificationEntity>> GetAllSubscribersAsync()
    {
        return await _context.NotificationsEntities.ToListAsync();
    }

    public async Task<NotificationEntity?> GetSubscriberByEmailAsync(string email)
    {
        return await _context.NotificationsEntities.FindAsync(email);
    }

    public async Task AddSubscriberAsync(NotificationEntity subscriber)
    {
        _context.NotificationsEntities.Add(subscriber);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateSubscriberAsync(NotificationEntity subscriber)
    {
        _context.NotificationsEntities.Update(subscriber);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteSubscriberAsync(string email)
    {
        var subscriber = await _context.NotificationsEntities.FindAsync(email);
        if (subscriber != null)
        {
            _context.NotificationsEntities.Remove(subscriber);
            await _context.SaveChangesAsync();
        }
    }
}
