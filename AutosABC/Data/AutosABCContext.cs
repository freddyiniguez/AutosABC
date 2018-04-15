using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutosABC.Models;

namespace AutosABC.Models
{
    public class AutosABCContext : DbContext
    {
        public AutosABCContext (DbContextOptions<AutosABCContext> options)
            : base(options)
        {
        }

        public DbSet<AutosABC.Models.Solicitud> Solicitud { get; set; }

        public DbSet<AutosABC.Models.Auto> Auto { get; set; }
    }
}
