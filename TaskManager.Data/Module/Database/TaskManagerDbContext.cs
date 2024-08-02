using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using TaskManager.Data.Module.Task.Entity;
using TaskManager.Data.Module.User.Entity;

namespace TaskManager.Data.Module.Database
{
    public class TaskManagerDbContext : DbContext
    {
        public TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options) : base(options) { }
        public DbSet<UserEntity> User { get; set; }
        public DbSet<TaskEntity> Task { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<UserEntity>()
                    .HasMany(u => u.Tasks)
                    .WithOne(t => t.User)
                    .HasForeignKey(t => t.UserId)
                    .IsRequired(false);
            base.OnModelCreating(modelBuilder);
        }
    }
}
