using System;
using System.Collections.Generic;

namespace ProyectoLaboBackEnd.Models
{
    public partial class Comment
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string MainContent { get; set; } = null!;
        public string? Media { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime? UpdateAt { get; set; }

        public virtual Post Post { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
