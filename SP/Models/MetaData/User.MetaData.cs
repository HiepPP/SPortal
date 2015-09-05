using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace SetPortal.Models
{
    [MetadataType(typeof(UserMetaData))]
    public partial class User
    {
        internal class UserMetaData
        {
            [Display(Name = "Mã người dùng")]
            public int IDCode { get; set; }

            [Display(Name = "Tên người dùng")]
            [Required(ErrorMessage = "{0} Không được để trống")]
            [StringLength(16, MinimumLength = 6, ErrorMessage = "{0} phải từ 6 đến 16 ký tự")]
            [RegularExpression("[a-zA-Z0-9]*", ErrorMessage = "khong Duoc Dung Ky Tu Dac Biet")]
            public string UserID { get; set; }
            [Display(Name = "Mật khẩu")]
            [Required(ErrorMessage = "{0} Không được để trống")]
            [StringLength(16, MinimumLength = 8, ErrorMessage = "{0} phải từ 8 đến 16 ký tự")]
            //[RegularExpression("[a-zA-Z0-9]*", ErrorMessage = "Mat khau khong duoc dung ky tu dac biet")]
            public string UserPassword { get; set; }
            [Display(Name = "Số lần đăng nhập thất bại")]
            public Nullable<int> TimesLoginFail { get; set; }
            [Display(Name = "Số lần đăng nhập thành công bại")]
            [EmailAddress(ErrorMessage = "{0} Không hợp lệ")]
            public string Email { get; set; }
            public Nullable<System.DateTime> DateTimeLogin { get; set; }
        }
    }
}