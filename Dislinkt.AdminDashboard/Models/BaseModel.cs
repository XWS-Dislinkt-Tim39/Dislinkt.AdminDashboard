using System;
using System.ComponentModel.DataAnnotations;

namespace Dislinkt.AdminDashboard.Models
{
    public class BaseModel
    {
        [Key]
        public Guid Id { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
