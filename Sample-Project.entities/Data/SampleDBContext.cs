using Microsoft.EntityFrameworkCore;
using Sample_Project.entities.IEntities;
using Sample_Project.entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Project.entities.Data
{
    public class SampleDBContext : DbContext
    {
        public SampleDBContext()
        {
        }
        public SampleDBContext(DbContextOptions<SampleDBContext> options)
            : base(options)
        {
        }

        public DbSet<Skill> Skills { get; set; } = null!;

        public DbSet<Country> Countries { get; set; } = null!;
        public DbSet<City> Cities { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

        public DbSet<UserSkill> UserSkills { get; set; } = null!;
        //public override int SaveChanges()
        //{
        //    var modifiedEntries = ChangeTracker.Entries()
        //        .Where(x => x.Entity is IAuditableEntity
        //            && (x.State == EntityState.Added || x.State == EntityState.Modified));

        //    foreach (var entry in modifiedEntries)
        //    {
        //        IAuditableEntity entity = entry.Entity as IAuditableEntity;
        //        if (entity != null)
        //        {
        //            string identityName = Thread.CurrentPrincipal.Identity.Name;
        //            DateTime now = DateTime.UtcNow;

        //            if (entry.State == EntityState.Added)
        //            {
        //                entity.CreatedBy = identityName;
        //                entity.CreatedDate = now;
        //            }
        //            else
        //            {
        //                base.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
        //                base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
        //            }

        //            entity.UpdatedBy = identityName;
        //            entity.UpdatedDate = now;
        //        }
        //    }

        //    return base.SaveChanges();
        //}
    }
}
