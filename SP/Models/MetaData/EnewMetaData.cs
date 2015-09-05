using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace SetPortal.Models
{
    [MetadataType(typeof(EnewUsMetaData))]
    public partial class Enew
    {
        internal class EnewUsMetaData
        {
            public int EnewsID { get; set; }
            [Required(ErrorMessage = "Tiêu đề không được để  trống!")]
            [MinLength(6, ErrorMessage = "Tiêu đề phải từ  6 ký tự trở lên!")]
            [MaxLength(100,ErrorMessage="Tiêu đề phải ít hơn 100 ký tự!")]
            public string EnewsTitle { get; set; }
            [Required(ErrorMessage="Nội dung không được để  trống!")]
            [MinLength(6,ErrorMessage="Nội dung phải từ  6 ký tự trở lên!")]
            public string EnewsContent { get; set; }
            [Required(ErrorMessage = "Tiêu đề M không được để  trống!")]
            [MinLength(6, ErrorMessage = "Tiêu đề M phải từ  6 ký tự trở lên!")]
            [MaxLength(100, ErrorMessage = "Tiêu đề phải ít hơn 100 ký tự!")]
            public string EnewsTitleM { get; set; }
            [Required(ErrorMessage = "Nội dung M không được để  trống!")]
            [MinLength(6, ErrorMessage = "Nội dung M phải từ  6 ký tự trở lên!")]
            [MaxLength(100, ErrorMessage = "Tiêu đề phải ít hơn 100 ký tự!")]
            public string EnewsContentM { get; set; }
            public Nullable<System.DateTime> PublishDate { get; set; }
            public Nullable<System.DateTime> EndDate { get; set; }
        }
    }
}