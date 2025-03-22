using Account.Models;
using Account.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Account.Manager
{
    public class ActivityManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public ActivityManager()
        {
            _unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }

        public void AddActivity(AddActivityBo addActivity)
        {
            var activity = new Activity
            {
                Id = Guid.NewGuid(),
                Name = addActivity.Name,
                StartDate = addActivity.StartDate.Date,
                EndDate = addActivity.EndDate.Date,
                Address = addActivity.Address,
                Price = addActivity.Price
            };
            _unitOfWork.Activies.Add(activity);
            _unitOfWork.Complete();
        }

        public List<Activity> GetActivity()
        {
            return _unitOfWork.Activies.Get().ToList();
        }

        public void Registration(string userId, Guid activityId)
        {
            var activityUser = new ActivityUser
            {
                ActivityId = activityId,
                UserId = userId
            };
            _unitOfWork.ActivityUsers.Add(activityUser);
            _unitOfWork.Complete();
        }
    }

    public class AddActivityBo
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
    }
}