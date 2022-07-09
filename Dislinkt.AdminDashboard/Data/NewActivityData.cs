

using Dislinkt.AdminDashboard.Domain;
using System;

namespace Dislinkt.AdminDashboard.Data
{
    public class NewActivityData
    {
        public Guid UserId { get; set; }
        public string Text { get; set; }

        public DateTime Date { get; set; }
        public Domain.Type Type { get; set; }
    }
}
