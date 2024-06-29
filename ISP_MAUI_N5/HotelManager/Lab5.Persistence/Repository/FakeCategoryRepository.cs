using System.Linq.Expressions;

namespace Lab5.Persistence.Repository
{
    public class FakeCategoryRepository : IRepository<Category>
    {
        private readonly List<Category> _categories;

        public FakeCategoryRepository()
        {
            _categories = new List<Category>()
            {
                new Category()
                {
                    Id = 1,
                    Name = "Standard",
                    Description = "Ну, норм)",
                    Rooms = new List<Room>()
                },
                new Category()
                {
                    Id = 2,
                    Name = "Luxury",
                    Description = "Покатит",
                    Rooms = new List<Room>()
                },
            };
        }

        public Task AddAsync(Category entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Category entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Category> FirstOrDefaultAsync(Expression<Func<Category, bool>> filter, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<Category, object>>[]? includesProperties)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Category>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return Task.Run(() => _categories as IReadOnlyList<Category>);
        }

        public Task<IReadOnlyList<Category>> ListAsync(Expression<Func<Category, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<Category, object>>[]? includesProperties)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Category entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}