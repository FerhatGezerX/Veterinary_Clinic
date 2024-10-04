using Microsoft.EntityFrameworkCore;

namespace VeterinaryClinic.Models
{
    public class VeterinaryDbContext : DbContext
    {
        public VeterinaryDbContext()
        {

        }

        public VeterinaryDbContext(DbContextOptions<VeterinaryDbContext> options) : base(options)
        {


        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Owner> Owneries { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<Home> Homeies { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Pages> Pageies { get; set; }
        public DbSet<Services> Servicess { get; set; }
        public DbSet<Franchise> Franchises { get; set; }





        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                        "Server=.\\sqlexpress;"
                        + "Database=VeterinaryDb;Trusted_Connection=true;Encrypt=false;"
                        ); 
            }
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Animal>()
                .HasKey(c => new { c.Id, c.FullName });

            modelBuilder.Entity<Employee>()
              .HasKey(c => new { c.Id, c.UpdatedBy });

            base.OnModelCreating(modelBuilder);
        }
}   }
