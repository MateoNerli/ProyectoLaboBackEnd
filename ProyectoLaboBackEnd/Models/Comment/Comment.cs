using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectoLaboBackEnd.Models.Comment
{
    public partial class Comment
    {
        
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string MainContent { get; set; } = null!;
        public string? Media { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime? UpdateAt { get; set; }

        public virtual Post.Post Post { get; set; } = null!;
        public virtual User.User User { get; set; } = null!;
    }
}
