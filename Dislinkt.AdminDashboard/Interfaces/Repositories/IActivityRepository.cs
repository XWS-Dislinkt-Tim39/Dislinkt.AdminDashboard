using Dislinkt.AdminDashboard.Data;
using Dislinkt.AdminDashboard.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dislinkt.AdminDashboard.Interfaces.Repositories
{
    public interface IActivityRepository
    {
        Task<bool> CreateActivity(NewActivityData activity);

        Task<IReadOnlyCollection<Activity>> GetAllAsync();

        Task DeleteByUserId(Guid userId);

    }
}