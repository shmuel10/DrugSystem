using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.BE;

namespace DAL
{
    public class DrugSystemContext : DbContext
    {
        public DrugSystemContext() : base("name=constr")
        {

        }
        public DbSet<User> UsersTable { get; set; }
        public DbSet<Administrator> AdminsTable { get; set; }
        public DbSet<testSql> testSqls { get; set; }
    }
}
