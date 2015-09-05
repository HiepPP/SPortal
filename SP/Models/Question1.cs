using System;
using System.Collections.Generic;

namespace SetPortal.Models
{
    public partial class Question1
    {
        public Question1()
        {
            this.Users = new List<User>();
        }

        public int IDQuestion1 { get; set; }
        public string Question11 { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
