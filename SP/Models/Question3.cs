using System;
using System.Collections.Generic;

namespace SetPortal.Models
{
    public partial class Question3
    {
        public Question3()
        {
            this.Users = new List<User>();
        }

        public int IDQuestion3 { get; set; }
        public string Question31 { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
