using System;
using System.Collections.Generic;

namespace SetPortal.Models
{
    public partial class ChuDeEGuide
    {
        public ChuDeEGuide()
        {
            this.EGuides = new List<EGuide>();
        }

        public string MaChuDeEguide { get; set; }
        public string TenChuDeEguide { get; set; }
        public string LoaiChuDeEguide { get; set; }
        public virtual ICollection<EGuide> EGuides { get; set; }
    }
}
