using System;
using System.Collections.Generic;

namespace SetPortal.Models
{
    public partial class Enew
    {
        public int EnewsID { get; set; }
        public string EnewsTitle { get; set; }
        public string EnewsContent { get; set; }
        public string EnewsTitleM { get; set; }
        public string EnewsContentM { get; set; }
        public Nullable<System.DateTime> PublishDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
    }
}
