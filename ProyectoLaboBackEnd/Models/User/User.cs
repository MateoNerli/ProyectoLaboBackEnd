using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using ProyectoLaboBackEnd.Models.Post;

namespace ProyectoLaboBackEnd.Models.User
{

    public partial class User
    {
        public User()
        {
            PostsNavigation = new HashSet<Post.Post>();
            Posts = new HashSet<Post.Post>();
            Posts1 = new HashSet<Post.Post>();
            Roles = new HashSet<Role.Role>();
        }

        public int UserId { get; set; }
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime RegistrationDate { get; set; }
        public string Pfp { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public string? Phone { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime? UpdateAt { get; set; }

        public virtual ICollection<Post.Post> PostsNavigation { get; set; }

        public virtual ICollection<Post.Post> Posts { get; set; }
        public virtual ICollection<Post.Post> Posts1 { get; set; }
        public virtual ICollection<Role.Role> Roles { get; set; }
    }
}