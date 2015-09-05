using System;
using System.Collections.Generic;

namespace SetPortal.Models
{
    public partial class Question2
    {
        public Question2()
        {
            this.Users = new List<User>();
        }

        public int IDQuestion2 { get; set; }
        public string Question21 { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
