using HouseEase.Interfaces;
using HouseEase.Models;
using HouseEase.Data;
using HouseEase.Services;

namespace HouseEase.Repository
{
    public class UnitOfWork : IUnityOfWork
    {
        private readonly ApplicationDbContext context;
        public IBaseRepository<Comment> Comment {get; private set; }
        public IBaseRepository<Fuclty> Fuclty {get; private set; }
        public IBaseRepository<Laundry> Laundry {get; private set; }
        public IBaseRepository<Leese> Leese {get; private set; }
        public IBaseRepository<Maintenance> Maintenance {get; private set; }
        public IBaseRepository<Post> Post {get; private set; }
        public IBaseRepository<Unit> Unit {get; private set; }
        public IBaseRepository<UnitType> UnitType {get; private set; }
        public IBaseRepository<University> University {get; private set; }
        public IBaseRepository<UsersLundries> UsersLundries {get; private set; }
        public IBaseRepository<UsersMaintenance> UsersMaintenance {get; private set; }
        public IBaseRepository<UserUnits> UserUnits {get; private set; }
        public IBaseRepository<Governurate> Governurate {get; private set; }
        public IBaseRepository<City> City {get; private set; }

        public UnitOfWork(ApplicationDbContext _context)
        {
            context = _context;
            Comment = new BaseRepository<Comment>(context);
            Fuclty = new BaseRepository<Fuclty>(context);
            Laundry = new BaseRepository<Laundry>(context);
            Leese = new BaseRepository<Leese>(context);
            Maintenance = new BaseRepository<Maintenance>(context);
            Post = new BaseRepository<Post>(context);
            Unit = new BaseRepository<Unit>(context);
            UnitType = new BaseRepository<UnitType>(context);
            University = new BaseRepository<University>(context);
            UsersLundries = new BaseRepository<UsersLundries>(context);
            UsersMaintenance = new BaseRepository<UsersMaintenance>(context);
            UserUnits = new BaseRepository<UserUnits>(context);
            Governurate = new BaseRepository<Governurate>(context);
            City = new BaseRepository<City>(context);
        }
        
        public int Complete()
        {
            return context.SaveChanges();
        }

        public async Task<int> CompleteAsync()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
