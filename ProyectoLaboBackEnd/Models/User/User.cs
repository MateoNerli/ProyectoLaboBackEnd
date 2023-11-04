using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        [MaxLength(40)]
        public string Name { get; set; } = null!;
        [Required]
        [MaxLength(40)]
        public string LastName { get; set; } = null!;
        [Required]
        public string UserName { get; set; } = null!;
        [Required]
        [MinLength(6)]
        public string Password { get; set; } = null!;
        [EmailAddress]
        public string Email { get; set; } = null!;
        public string Pfp { get; set; } = null!;
        public string? Phone { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime? UpdateAt { get; set; }

        public virtual ICollection<Post.Post> PostsNavigation { get; set; }

        public virtual ICollection<Post.Post> Posts { get; set; }
        public virtual ICollection<Post.Post> Posts1 { get; set; }
        [JsonIgnore]
        public virtual ICollection<Role.Role> Roles { get; set; }

    }
}