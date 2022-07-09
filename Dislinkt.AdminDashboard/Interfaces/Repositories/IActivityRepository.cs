using Dislinkt.AdminDashboard.Data;
using Dislinkt.AdminDashboard.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dislinkt.AdminDashboard.Interfaces.Repositories
{
    public interface IActivityRepository
    {
        Task CreateActivity(NewActivityData activity);

        Task<IReadOnlyList<Activity>> GetAll();

    }
}