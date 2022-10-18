using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWeb_Mvc.Models;

namespace SalesWeb_Mvc.Data
{
    public class SalesWeb_MvcContext : DbContext
    {
        public SalesWeb_MvcContext (DbContextOptions<SalesWeb_MvcContext> options)
            : base(options)
        {
        }

        public DbSet<Departament> Departament { get; set; } = default!;
        public DbSet<Seller> Seller { get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; }
    }
}
