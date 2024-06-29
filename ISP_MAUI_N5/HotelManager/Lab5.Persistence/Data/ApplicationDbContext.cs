using Lab5.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Lab5.Persistence.Data
{
    public sealed class ApplicationDbContext: DbContext
    {
        DbSet<Room> Rooms { get; }
        DbSet<Category> Categories { get; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            Database.EnsureCreated();
        }
    }
}