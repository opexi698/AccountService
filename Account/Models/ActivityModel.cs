using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;

namespace Account.Models
{
    public class Activity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<ActivityUser> ActivityUsers { get; set; }
        public Activity()
        {
            ActivityUsers = new HashSet<ActivityUser>();
        }
    }

    public class ActivityUser
    {
        public Guid ActivityId { get; set; }
        public virtual Activity Activity { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}