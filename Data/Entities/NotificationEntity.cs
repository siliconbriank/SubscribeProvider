using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class NotificationEntity
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public bool Newsletter { get; set; }
        public bool Theme { get; set; }
    }
}
