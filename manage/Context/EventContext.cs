using manage.Models;
using System.Data.Entity;

namespace manage.Context
{
    public class EventContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Events> Events { get; set; }
    }
}