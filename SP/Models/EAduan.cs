using System;
using System.Collections.Generic;

namespace SetPortal.Models
{
    public partial class EAduan
    {
        public int IDEAduan { get; set; }
        public string ComplaintName { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public string Address { get; set; }
        public string Postcode { get; set; }
        public string Town { get; set; }
        public Nullable<int> IDState { get; set; }
        public string Company { get; set; }
        public string LocationCompany { get; set; }
        public string Subject { get; set; }
        public string Complaint { get; set; }
        public string Image { get; set; }
        public string FileName { get; set; }
        public virtual NameState NameState { get; set; }
    }
}
