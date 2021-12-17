using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhamVanNhan441.Models;

    public class PhamVanNhan441DbContext : DbContext
    {
        public PhamVanNhan441DbContext (DbContextOptions<PhamVanNhan441DbContext> options)
            : base(options)
        {
        }

        public DbSet<PhamVanNhan441.Models.CompanyPVN441> CompanyPVN441 { get; set; }

        public DbSet<PhamVanNhan441.Models.PVN0441> PVN0441 { get; set; }
    }
