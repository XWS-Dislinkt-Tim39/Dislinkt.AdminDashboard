using System;

namespace Dislinkt.AdminDashboard.Domain
{
    public class Activity
    {
        public Guid Id { get; }

        public Guid UserId { get; }

        public string Text { get; }

        public DateTime Date { get; }

        public Type Type { get; }

        public Activity(Guid id, Guid userId, string text, DateTime date, Type type)
        {
            Id = id;
            UserId = userId;
            Text = text;
            Date = date;
            Type = type;
        }
    }
}
