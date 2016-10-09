using manage.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace manage.Context
{
    public class EventContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Events> Events { get; set; }
    }
}