using System;
using System.Collections.Generic;

namespace SetPortal.Models
{
    public partial class User
    {
        public int IDCode { get; set; }
        public string UserID { get; set; }
        public string UserPassword { get; set; }
        public Nullable<int> TimesLoginFail { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> DateTimeLogin { get; set; }
        public Nullable<int> IDQuestion1 { get; set; }
        public string Answer1 { get; set; }
        public Nullable<int> IDQuestion2 { get; set; }
        public string Answer2 { get; set; }
        public Nullable<int> IDQuestion3 { get; set; }
        public string Answer3 { get; set; }
        public Nullable<int> RoleID { get; set; }
        public virtual Question1 Question1 { get; set; }
        public virtual Question2 Question2 { get; set; }
        public virtual Question3 Question3 { get; set; }
        public virtual Role Role { get; set; }
    }
}
