using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Persistence.Repository
{
    public class FakeRoomRepository : IRepository<Room>
    {
        private readonly List<Room> _rooms;

        public FakeRoomRepository()
        {
            _rooms = new List<Room>()
            {
                new Room()
                {
                    Id = 1,
                    Name = "101",
                    ServiceCost = 150,
                    CategoryId = 1,
                    CheckInDate = new DateTime(2024, 4, 3),
                    CheckOutDate = new DateTime(2024, 5, 6)
                },

                new Room()
                {
                    Id = 2,
                    Name = "201",
                    ServiceCost = 200,
                    CategoryId = 2,
                    CheckInDate = new DateTime(2024, 2, 3),
                    CheckOutDate = new DateTime(2024, 3, 6)
                },

                new Room()
                {
                    Id = 3,
                    Name = "202",
                    ServiceCost = 250,
                    CategoryId = 2,
                    CheckInDate = new DateTime(2024, 1, 3),
                    CheckOutDate = new DateTime(2024, 2, 6)
                }
            };
        }

        public Task AddAsync(Room entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Room entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Room> FirstOrDefaultAsync(Expression<Func<Room, bool>> filter, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Room> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<Room, object>>[]? includesProperties)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Room>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return Task.Run(() => _rooms as IReadOnlyList<Room>);
        }

        public Task<IReadOnlyList<Room>> ListAsync(Expression<Func<Room, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<Room, object>>[]? includesProperties)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Room entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
