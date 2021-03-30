using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using InfoDaruratSystem.Web.Models;
using InfoDaruratSystem.Web.Library.Entities;

using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace InfoDaruratSystem.Web.Models
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
              : base(options)
        {

        }

        // ------------------- SEC MANAGEMENT -------------------
        public DbSet<MenuEntity.Menu> Menus { get; set; }
        public DbSet<RoleEntity.Role> Roles { get; set; }
        public DbSet<UserEntity.User> Users { get; set; }
        public DbSet<UserRolesEntity.UserRoles> UserRoles { get; set; }

        // ------------------- NON - SEC MANAGEMENT -------------------
        public DbSet<AktivitasEntity.Aktivitas> Aktivitas { get; set; }
        public DbSet<DaftarAlatEntity.DaftarAlat> DaftarAlats { get; set; }
        public DbSet<KartuEntity.Kartu> Kartus { get; set; }
        public DbSet<LevelEntity.Level> Levels { get; set; }
        public DbSet<PanggilanEntity.Panggilan> Panggilans { get; set; }
        public DbSet<PersiapanAlatEntity.PersiapanAlat> PersiapanAlats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenuEntity.Menu>().ToTable("Menu");
            modelBuilder.Entity<RoleEntity.Role>().ToTable("Role");
            modelBuilder.Entity<UserEntity.User>().ToTable("Users");
            modelBuilder.Entity<UserRolesEntity.UserRoles>().ToTable("UserRoles");

            modelBuilder.Entity<AktivitasEntity.Aktivitas>().ToTable("Aktivitas");
            modelBuilder.Entity<DaftarAlatEntity.DaftarAlat>().ToTable("DaftarAlat");
            modelBuilder.Entity<KartuEntity.Kartu>().ToTable("Kartu");
            modelBuilder.Entity<LevelEntity.Level>().ToTable("Level");
            modelBuilder.Entity<PanggilanEntity.Panggilan>().ToTable("Panggilan");
            modelBuilder.Entity<PersiapanAlatEntity.PersiapanAlat>().ToTable("PersiapanAlat");

        }

    }
}
