using Dislinkt.AdminDashboard.Data;
using Dislinkt.AdminDashboard.Domain;
using Dislinkt.AdminDashboard.Interfaces.Repositories;
using Dislinkt.AdminDashboard.MongoDB.Common;
using Dislinkt.AdminDashboard.MongoDB.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
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


        public async Task<IReadOnlyCollection<Activity>> GetAllAsync()
        {
            var result = await _queryExecutor.GetAll<ActivityEntity>();

            return result?.AsEnumerable().Select(s => s.ToActivity()).ToArray() ?? Array.Empty<Activity>();
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

        public async Task DeleteByUserId(Guid userId)
        {
            var filter = Builders<ActivityEntity>.Filter.Eq(u => u.UserId, userId);
            await _queryExecutor.DeleteByIdAsync<ActivityEntity>(filter);
        }


    }
}
