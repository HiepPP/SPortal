using System;
using System.Collections.Generic;

namespace SetPortal.Models
{
    public partial class FAQ
    {
        public int FaqID { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string MaChuDeFAQ { get; set; }
        public string FileName { get; set; }
        public virtual ChuDeFAQ ChuDeFAQ { get; set; }
    }
}
