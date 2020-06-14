using Microsoft.EntityFrameworkCore;
using Qualify.Service;
using Qualify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qualify.Service
{
    public class QualifyContext : DbContext
    {
        public QualifyContext(DbContextOptions<QualifyContext> options) : base(options)
        {

        }

        public DbSet<Claim> Claims { get; set; }
        public DbSet<Models.Action> Actions { get; set; }
        public DbSet<ClaimExpence> ClaimExpences {get; set;}
        public DbSet<ClaimHistory> ClaimHistories {get; set;}
        public DbSet<Client> Clients {get; set;}
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees {get; set;}
        public DbSet<Tool> Tools {get; set;}
        public DbSet<ToolType> ToolTypes {get; set;}
    }
}