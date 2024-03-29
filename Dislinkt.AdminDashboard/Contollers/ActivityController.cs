﻿
using Dislinkt.AdminDashboard.Data;
using Dislinkt.AdminDashboard.Domain;
using Dislinkt.AdminDashboard.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dislinkt.AdminDashboard.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : Controller
    {
        private readonly IActivityRepository _activityRepository;
        public ActivityController(IActivityRepository activityRepository)
        {

            _activityRepository = activityRepository;
        }

        [HttpPost]
        [Route("/create-activity")]
        public async Task<bool> CreateActivity([FromBody] NewActivityData activity)
        {
            return  await _activityRepository.CreateActivity(activity);
            //return false;
        }

        [HttpGet]
        [Route("/get-all")]
        public async Task<IReadOnlyCollection<Activity>> GetAllInterestsAsync()
        {
            return await _activityRepository.GetAllAsync();
        }

        [HttpDelete]
        [Route("/delete-by-userId")]
        public async Task DeleteByUserId(Guid userId)
        {
            await _activityRepository.DeleteByUserId(userId);


        }
    }
}
