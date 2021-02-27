using MvcStructure.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcStructure.Repository
{
    public class DataContext : DbContext
    {
        public DataContext() : base("name=MySqlConnection")
        {
        }
        public DbSet<Employee> employees { get; set; }
    }
}
