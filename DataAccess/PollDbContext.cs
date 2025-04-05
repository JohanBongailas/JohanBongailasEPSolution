using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
namespace DataAccess
{
    public class PollDbContext(DbContextOptions<PollDbContext> options) : DbContext(options)
    {
        public DbSet<Poll> Polls { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ConfigurePollEntity(modelBuilder);
        }

        private void ConfigurePollEntity(ModelBuilder modelBuilder)
        {
            var pollEntity = modelBuilder.Entity<Poll>();

            // Ensure title is required
            pollEntity.Property(p => p.Title).IsRequired();

            // Ensure option texts are required
            pollEntity.Property(p => p.Option1Text).IsRequired();
            pollEntity.Property(p => p.Option2Text).IsRequired();
            pollEntity.Property(p => p.Option3Text).IsRequired();

            // Vote counts are defaulted to 0 and required
            pollEntity.Property(p => p.Option1VotesCount).IsRequired(true).HasDefaultValue(0);
            pollEntity.Property(p => p.Option3VotesCount).IsRequired(true).HasDefaultValue(0);
            pollEntity.Property(p => p.Option2VotesCount).IsRequired(true).HasDefaultValue(0);

            // Set default value for DateCreated
            pollEntity.Property(p => p.DateCreated)
                .HasDefaultValueSql("GETUTCDATE()")
                .ValueGeneratedOnAdd();
        }
    }
}
