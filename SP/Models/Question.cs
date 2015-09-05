using System;
using System.Collections.Generic;

namespace SetPortal.Models
{
    public partial class Question
    {
        public Question()
        {
            this.Users = new List<User>();
        }

        public int IDQuestion { get; set; }
        public string Question1 { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
