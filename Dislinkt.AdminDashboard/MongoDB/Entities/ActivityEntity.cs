using Dislinkt.AdminDashboard.Domain;
using Dislinkt.AdminDashboard.MongoDB.Attributes;
using System;

namespace Dislinkt.AdminDashboard.MongoDB.Entities
{
    [CollectionName("Activities")]
    public class ActivityEntity : BaseEntity
    {
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public Domain.Type Type { get; set; }

        public static ActivityEntity ToActivityEntity(Activity activity)
        {
            return new ActivityEntity
            {
                Id = activity.Id,
                UserId = activity.UserId,
                Text = activity.Text,
                Date = activity.Date,
                Type = activity.Type,
            };
        }

        public Activity ToActivity()
            => new Activity(this.Id, this.UserId, this.Text, this.Date, this.Type);

    }
}
