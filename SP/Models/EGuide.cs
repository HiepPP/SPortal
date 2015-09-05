using System;
using System.Collections.Generic;

namespace SetPortal.Models
{
    public partial class EGuide
    {
        public int EGuildID { get; set; }
        public string MaChuDeEguide { get; set; }
        public string FileName { get; set; }
        public string Contents { get; set; }
        public virtual ChuDeEGuide ChuDeEGuide { get; set; }
    }
}
