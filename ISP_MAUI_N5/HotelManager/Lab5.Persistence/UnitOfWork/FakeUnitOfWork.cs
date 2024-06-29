using Lab5.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Persistence.UnitOfWork
{
    public class FakeUnitOfWork : IUnitOfWork
    {
        private readonly FakeCategoryRepository _categoryRepository;
        private readonly FakeRoomRepository _roomRepository;
        public FakeUnitOfWork()
        {
            _categoryRepository = new();
            _roomRepository = new();
    }
        public IRepository<Category> CategoryRepository => _categoryRepository;
        public IRepository<Room> RoomRepository => _roomRepository;

        public Task CreateDataBaseAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteDataBaseAsync()
        {
            throw new NotImplementedException();
        }

        public Task SaveAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
