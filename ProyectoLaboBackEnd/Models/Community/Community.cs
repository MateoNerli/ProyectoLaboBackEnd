using System;
using System.Collections.Generic;
using ProyectoLaboBackEnd.Models.Post;

namespace ProyectoLaboBackEnd.Models.Community
{
    public partial class Community
    {
        public Community()
        {
            Posts = new HashSet<Post.Post>();
        }

        public int CommunityId { get; set; }
        public string Name { get; set; } = null!;
        public bool State { get; set; }

        public virtual ICollection<Post.Post> Posts { get; set; }
    }
}
