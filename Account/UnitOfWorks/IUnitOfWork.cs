using Account.Models;
using Account.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace Account.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<ApplicationUser> Users { get; }
        IRepository<IdentityRole> Roles { get; }
        IRepository<Activity> Activies { get; }
        IRepository<ActivityUser> ActivityUsers { get; }

        UserManager<ApplicationUser> UserManager { get; }
        RoleManager<IdentityRole> RoleManager { get; }

        int Complete();
    }
}