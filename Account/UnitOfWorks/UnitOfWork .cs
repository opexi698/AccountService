using Account.Models;
using Account.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Account.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IRepository<ApplicationUser> Users { get; private set; }
        public IRepository<IdentityRole> Roles { get; private set; }
        public IRepository<Activity> Activies { get; private set; }
        public IRepository<ActivityUser> ActivityUsers { get; private set; }

        public UserManager<ApplicationUser> UserManager { get; private set; }
        public RoleManager<IdentityRole> RoleManager { get; private set; }


        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Users = new Repository<ApplicationUser>(_context);
            Roles = new Repository<IdentityRole>(_context);

            Activies = new Repository<Activity>(_context);
            ActivityUsers = new Repository<ActivityUser>(_context);


            var userStore = new UserStore<ApplicationUser>(_context);
            var roleStore = new RoleStore<IdentityRole>(_context);

            UserManager = new UserManager<ApplicationUser>(userStore);
            RoleManager = new RoleManager<IdentityRole>(roleStore);
        }

        public int Complete() => _context.SaveChanges();

        public void Dispose() => _context.Dispose();
    }
}