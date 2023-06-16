using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using Avondspel.Infrastructure.Data;

namespace Avondspel.Tests
{
    public abstract class TestDatabase : IDisposable
    {
        private readonly SqliteConnection connection;
        protected TestDatabase()
        {
            connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
        }
        public void Dispose() => connection.Dispose();
        public AvondspelDbContext CreateContext()
        {
            var result = new AvondspelDbContext(new DbContextOptionsBuilder<AvondspelDbContext>()
            .UseSqlite(connection).Options);
            result.Database.EnsureCreated();
            return result;
        }
    }
}
