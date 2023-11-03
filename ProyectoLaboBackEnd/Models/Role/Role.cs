using System;
using System.Collections.Generic;

namespace ProyectoLaboBackEnd.Models.Role
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User.User>();
        }

        public int RoleId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<User.User> Users { get; set; }
    }
}
