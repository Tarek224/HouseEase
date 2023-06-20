using HouseEase.Models;

namespace HouseEase.Interfaces
{
    public interface IUnityOfWork : IDisposable
    {
        public IBaseRepository<Comment> Comment { get; }
        public IBaseRepository<Fuclty> Fuclty { get; }
        public IBaseRepository<Laundry> Laundry { get; }
        public IBaseRepository<Leese> Leese { get; }
        public IBaseRepository<Maintenance> Maintenance { get; }
        public IBaseRepository<Post> Post { get; }
        public IBaseRepository<Unit> Unit { get; }
        public IBaseRepository<UnitType> UnitType { get; }
        public IBaseRepository<University> University { get; }
        public IBaseRepository<UsersLundries> UsersLundries { get; }
        public IBaseRepository<UsersMaintenance> UsersMaintenance { get; }
        public IBaseRepository<UserUnits> UserUnits { get; }
        public IBaseRepository<Governurate> Governurate { get; }
        public IBaseRepository<City> City { get; }

        int Complete();
        Task<int> CompleteAsync();
    }
}
