using System;
using System.Collections.Generic;
using ProyectoLaboBackEnd.Models.User;
using ProyectoLaboBackEnd.Models.Community;

namespace ProyectoLaboBackEnd.Models.Post
{
    public class Post
    {
        public Post()
        {
            Users = new HashSet<User.User>();
            UsersNavigation = new HashSet<User.User>();
        }

        public int PostId { get; set; }
        public int UserId { get; set; }
        public DateTime DateTime { get; set; }
        public string Title { get; set; } = null!;
        public string MainContent { get; set; } = null!;
        public string? Media { get; set; }
        public int CommunityId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime? UpdateAt { get; set; }

        public virtual Community.Community Community { get; set; } = null!;
        public virtual User.User User { get; set; } = null!;

        public virtual ICollection<User.User> Users { get; set; }
        public virtual ICollection<User.User> UsersNavigation { get; set; }
    }
}
