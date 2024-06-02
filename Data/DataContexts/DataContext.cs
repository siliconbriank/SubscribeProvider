using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.DataContexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<NotificationEntity> NotificationsEntities { get; set; }
    }
}
