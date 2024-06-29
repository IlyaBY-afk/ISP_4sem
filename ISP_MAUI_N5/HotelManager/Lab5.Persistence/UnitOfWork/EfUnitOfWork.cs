using Lab5.Persistence.Data;
using Lab5.Persistence.Repository;

namespace Lab5.Persistence.UnitOfWork
{
    public class EfUnitOfWork: IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly Lazy<IRepository<Category>> _categoryRepository;
        private readonly Lazy<IRepository<Room>> _roomRepository;

        public EfUnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            _categoryRepository = new Lazy<IRepository<Category>>(() => new EfRepository<Category>(context));
            _roomRepository = new Lazy<IRepository<Room>>(() => new EfRepository<Room>(context));
        }

        public IRepository<Category> CategoryRepository => _categoryRepository.Value;
        public IRepository<Room> RoomRepository => _roomRepository.Value;
        public async Task CreateDataBaseAsync() => await _context.Database.EnsureCreatedAsync();
        public async Task DeleteDataBaseAsync() => await _context.Database.EnsureDeletedAsync();
        public async Task SaveAllAsync() => await _context.SaveChangesAsync();
    }
}
