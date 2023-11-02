using Microsoft.EntityFrameworkCore;
//using ProyectoLaboBackEnd.Models;


//namespace ProyectoLaboBackEnd.Services
//{
//    public class ProyectoLaboBackEndContext : DbContext
//    {
//        public ProyectoLaboBackEndContext(DbContextOptions<ProyectoLaboBackEndContext> options) : base(options) { }
//        public DbSet<User> Users { get; set; }
//        public DbSet<Post> Posts { get; set; }
//        public DbSet<Role> Roles { get; set; }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<User>().HasIndex(u => u.UserName).IsUnique(unique: true);
//            modelBuilder.Entity<Role>().HasData(
//                new Role { RoleId = 1, Name = "Admin" },
//                new Role { RoleId = 2, Name = "User" },
//                new Role { RoleId = 3, Name = "Moderator" }
//            );

//            modelBuilder.Entity<User>().HasMany(e => e.Roles).WithMany().UsingEntity<Role>(
//                l => l.HasOne<Role>().WithMany().HasForeignKey(e => e.RoleId),
//                r => r.HasOne<User>().WithMany().HasForeignKey(e => e.UserId)
//            );
//        }
//    }
//}
