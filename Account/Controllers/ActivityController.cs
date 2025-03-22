using Account.Manager;
using Account.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Account.Controllers
{
    public class ActivityController : Controller
    {
        [AllowAnonymous]
        public ActionResult AddActivity()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddActivity(AddActivityViewModel addActivity)
        {
            var activityManager = new ActivityManager();

            var addActivityBo = new AddActivityBo
            {
                Name = addActivity.Name,
                StartDate = addActivity.StartDate,
                EndDate = addActivity.EndDate,
                Address = addActivity.Address,
                Price = addActivity.Price
            };

            activityManager.AddActivity(addActivityBo);
            return View();
        }

        [AllowAnonymous]
        public async Task<ActionResult> GetActivities()
        {
            var activityManager = new ActivityManager();

            var activities = activityManager.GetActivity();
            var result = new List<GetActivityViewModel>();

            foreach (var activity in activities)
            {
                var getActivity = new GetActivityViewModel()
                {
                    Id = activity.Id,
                    Name = activity.Name,
                    StartDate = activity.StartDate,
                    EndDate = activity.EndDate,
                    Address = activity.Address,
                    Price = activity.Price,
                    Enrolments = string.Join(",", activity.ActivityUsers.Select(x => x.User.Email))
                };
                result.Add(getActivity);
            }

            return View(result);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult> Registration(Guid activityId)
        {
            var userId = User.Identity.GetUserId();
            var activityManager = new ActivityManager();

            activityManager.Registration(userId, activityId);

            return RedirectToAction("GetActivities", "Activity");
        }
    }
}