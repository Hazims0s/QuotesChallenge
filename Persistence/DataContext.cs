using Microsoft.EntityFrameworkCore;
using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            AddTimestamps();
            return base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder builder){
            base.OnModelCreating(builder); 
            builder.Entity<Quote>(e=> e.HasOne(k => k.Auther) );
            builder.Entity<Quote>(e=> e.Property(p=>p.Text).HasColumnType("nvarchar(max)")) ; 


                }

        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries()
                .Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added));

            foreach (var entity in entities)
            {
                var now = DateTime.UtcNow; 

                if (entity.State == EntityState.Added)
                {
                    ((BaseEntity)entity.Entity).CreatedAt = now;
                }
            }
        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Auther> Authers { get; set; }
       public DbSet<Quote> Quotes { get; set; }
    }
}