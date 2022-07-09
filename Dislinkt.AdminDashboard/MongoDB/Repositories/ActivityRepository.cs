using Dislinkt.AdminDashboard.Data;
using Dislinkt.AdminDashboard.Domain;
using Dislinkt.AdminDashboard.Interfaces.Repositories;
using Dislinkt.AdminDashboard.MongoDB.Common;
using Dislinkt.AdminDashboard.MongoDB.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dislinkt.AdminDashboard.MongoDB.Repositories
{
    public class ActivityRepository:IActivityRepository
    {
        private readonly IQueryExecutor _queryExecutor;

        public ActivityRepository(IQueryExecutor queryExecutor)
        {
            _queryExecutor = queryExecutor;
        }


        public Task<IReadOnlyList<Activity>> GetAll()
        {
            return Task.FromResult((IReadOnlyList<Activity>)_queryExecutor.GetAll<ActivityEntity>());
        }

        public async Task CreateActivity(NewActivityData activity)
        {
            try
            {
                await _queryExecutor.CreateAsync(ActivityEntity.ToActivityEntity(new Activity(Guid.NewGuid(), activity.UserId, activity.Text, activity.Date, activity.Type)));
            }
            catch (MongoWriteException ex)
            {
                throw ex;
            }

        }

    }
}
