using BillStudio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillStudio.Infrastructure
{
    public class StudioBillDbContext : DbContext
    {

        public StudioBillDbContext(DbContextOptions<StudioBillDbContext> options) : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Studio> Studios { get; set; }

    }
}
