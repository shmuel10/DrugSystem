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

        public DbSet<Administrator> AdminsTable { get; set; }

        public DbSet<Person> PersonsTable { get; set; }
        public DbSet<Prescription> PrescriptionsTable { get; set; }
        public DbSet<Medicine> MedicinesTable { get; set; }
        public DbSet<Visit> VisitsTable { get; set; }
    }
}
