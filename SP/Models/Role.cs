using System;
using System.Collections.Generic;

namespace SetPortal.Models
{
    public partial class Role
    {
        public Role()
        {
            this.Users = new List<User>();
        }

        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public string Detail { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
