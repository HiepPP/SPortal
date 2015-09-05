using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SetPortal.Models.ViewModel
{
    public class SearchViewModel
    {
        public int FaqID { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string MaChuDeFAQ { get; set; }

        public string TenChuDeFAQ { get; set; }
        public string LoaiChuDeFAQ { get; set; }

        public int EGuildID { get; set; }
        public string MaChuDeEguide { get; set; }
        public string Contents { get; set; }

        public string TenChuDeEguide { get; set; }
        public string LoaiChuDeEguide { get; set; }

        public string dropdown { get; set; }
        public string tukhoa { get; set; }
    }
}