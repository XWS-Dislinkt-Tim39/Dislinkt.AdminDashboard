using Dislinkt.AdminDashboard.Data;
using Dislinkt.AdminDashboard.Domain;
using Dislinkt.AdminDashboard.Interfaces.Repositories;
using Grpc.Core;
using GrpcAddActivityService;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Type = Dislinkt.AdminDashboard.Domain.Type;

namespace GrpcService.Services
{
    public class AddActivityService : addActivityGreeter.addActivityGreeterBase
    {
        private IActivityRepository _activityRepository;

        public AddActivityService(IActivityRepository activityRepository)
        {

            _activityRepository = activityRepository;
        }

        public override async Task<ActivityReply> addActivity(ActivityRequest request, ServerCallContext context)
        {
            bool result;
            Type t = Type.Post;
            if (request.Type == "Post")
            {
                t = Dislinkt.AdminDashboard.Domain.Type.Post;
            }
            else if (request.Type == "Job")
            {
                t = Type.Job;
            }
            else if (request.Type == "Connection")
            {
                t =Type.Connection;
            }
            else if (request.Type == "Registration")
            {
                t =Type.Registration;
            }
            try
            {
                var activity = new NewActivityData
                {
                    UserId = System.Guid.Parse(request.UserId),
                    Text = request.Text,
                    Date = DateTime.Parse(request.Date),
                Type = t
                };

                await _activityRepository.CreateActivity(activity);
                result = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return await Task.FromResult(new ActivityReply
                {
                    Successful = false,
                    Message = $"{ex}"
                });
            }
            return await Task.FromResult(new ActivityReply
            {
                Successful = result,
                Message = $"Notifikacija: {request.UserId} | {request.Text} | {request.Type} | {request.Date}"
            });
        }
           
        
    }
}
