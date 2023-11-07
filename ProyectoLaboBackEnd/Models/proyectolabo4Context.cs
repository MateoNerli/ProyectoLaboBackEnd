using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProyectoLaboBackEnd.Models
{
    public partial class proyectolabo4Context : DbContext
    {

        public proyectolabo4Context(DbContextOptions<proyectolabo4Context> options) : base(options)
        {
        }

        public virtual DbSet<Comment.Comment> Comments { get; set; } = null!;
        public virtual DbSet<Community.Community> Communities { get; set; } = null!;
        public virtual DbSet<Post.Post> Posts { get; set; } = null!;
        public virtual DbSet<Role.Role> Roles { get; set; } = null!;
        public virtual DbSet<User.User> Users { get; set; } = null!;



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Comment.Comment>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("comments");

                entity.HasIndex(e => e.PostId, "PostId");

                entity.HasIndex(e => e.UserId, "UserId");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.MainContent).HasMaxLength(600);

                entity.Property(e => e.Media).HasMaxLength(300);

                entity.Property(e => e.UpdateAt).HasColumnType("datetime");

                entity.HasOne(d => d.Post)
                    .WithMany()
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("comments_ibfk_1");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("comments_ibfk_2");
            });

            modelBuilder.Entity<Community.Community>(entity =>
            {
                entity.ToTable("communities");

                entity.Property(e => e.Name).HasMaxLength(30);
            });

            modelBuilder.Entity<Post.Post>(entity =>
            {
                entity.ToTable("posts");

                entity.HasIndex(e => e.CommunityId, "CommunityId");

                entity.HasIndex(e => e.UserId, "UserId");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.MainContent).HasMaxLength(600);

                entity.Property(e => e.Media).HasMaxLength(255);

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.Property(e => e.UpdateAt).HasColumnType("datetime");

                entity.HasOne(d => d.Community)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.CommunityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("posts_ibfk_2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PostsNavigation)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("posts_ibfk_1");
            });

            modelBuilder.Entity<Role.Role>(entity =>
            {
                entity.ToTable("roles");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Comment.Comment>()
        .HasKey(c => c.CommentId);

            modelBuilder.Entity<User.User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Email, "Email")
                    .IsUnique();

                entity.HasIndex(e => e.UserName, "UserName")
                    .IsUnique();

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.LastName).HasMaxLength(30);

                entity.Property(e => e.Name).HasMaxLength(30);

                entity.Property(e => e.Password).HasMaxLength(60);

                entity.Property(e => e.Pfp).HasMaxLength(255);

                entity.Property(e => e.Phone).HasMaxLength(100);

                entity.Property(e => e.UpdateAt).HasColumnType("datetime");

                entity.Property(e => e.UserName).HasMaxLength(30);

                entity.HasMany(d => d.Posts)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "Like",
                        l => l.HasOne<Post.Post>().WithMany().HasForeignKey("PostId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("likes_ibfk_1"),
                        r => r.HasOne<User.User>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("likes_ibfk_2"),
                        j =>
                        {
                            j.HasKey("UserId", "PostId").HasName("PRIMARY").HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                            j.ToTable("likes");

                            j.HasIndex(new[] { "PostId" }, "PostId");
                        });

                entity.HasMany(d => d.Posts1)
                    .WithMany(p => p.UsersNavigation)
                    .UsingEntity<Dictionary<string, object>>(
                        "Saved",
                        l => l.HasOne<Post.Post>().WithMany().HasForeignKey("PostId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("saved_ibfk_1"),
                        r => r.HasOne<User.User>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("saved_ibfk_2"),
                        j =>
                        {
                            j.HasKey("UserId", "PostId").HasName("PRIMARY").HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                            j.ToTable("saved");

                            j.HasIndex(new[] { "PostId" }, "PostId");
                        });

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "Userrole",
                        l => l.HasOne<Role.Role>().WithMany().HasForeignKey("RoleId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("userroles_ibfk_2"),
                        r => r.HasOne<User.User>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("userroles_ibfk_1"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId").HasName("PRIMARY").HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                            j.ToTable("userroles");

                            j.HasIndex(new[] { "RoleId" }, "roleId");

                            j.IndexerProperty<int>("UserId").HasColumnName("userId");

                            j.IndexerProperty<int>("RoleId").HasColumnName("roleId");
                        });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
