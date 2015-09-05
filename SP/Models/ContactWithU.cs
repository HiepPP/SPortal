using System;
using System.Collections.Generic;

namespace SetPortal.Models
{
    public partial class ContactWithU
    {
        public int ID { get; set; }
        public string HinhAnh { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string SubjectEmail { get; set; }
        public string ContentEmail { get; set; }
    }
}
