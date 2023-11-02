using System;
using System.Collections.Generic;

namespace ProyectoLaboBackEnd.Models
{
    public partial class Community
    {
        public Community()
        {
            Posts = new HashSet<Post>();
        }

        public int CommunityId { get; set; }
        public string Name { get; set; } = null!;
        public bool State { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
