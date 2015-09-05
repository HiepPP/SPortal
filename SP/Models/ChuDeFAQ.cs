using System;
using System.Collections.Generic;

namespace SetPortal.Models
{
    public partial class ChuDeFAQ
    {
        public ChuDeFAQ()
        {
            this.FAQs = new List<FAQ>();
        }

        public string MaChuDeFAQ { get; set; }
        public string TenChuDeFAQ { get; set; }
        public string LoaiChuDeFAQ { get; set; }
        public virtual ICollection<FAQ> FAQs { get; set; }
    }
}
