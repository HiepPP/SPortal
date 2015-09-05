using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SetPortal.Models.ViewModel
{
    public class FirstTimeLoginViewModel
    {
        //public int IDCode { get; set; }
        //public string UserID { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        [StringLength(16, MinimumLength = 8, ErrorMessage = "8 đến 16 ký tự")]
        public string UserPassword { get; set; }
        public Nullable<int> TimesLoginFail { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> DateTimeLogin { get; set; }
        public Nullable<int> IDQuestion1 { get; set; }
        public string Answer1 { get; set; }
        public Nullable<int> IDQuestion2 { get; set; }
        public string Answer2 { get; set; }
        public Nullable<int> IDQuestion3 { get; set; }
        public string Answer3 { get; set; }

        public string Question11 { get; set; }

        public string Question21 { get; set; }

        public string Question31 { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        [StringLength(16, MinimumLength = 8, ErrorMessage = "8 đến 16 ký tự")]
        [RegularExpression("[a-zA-Z0-9]*", ErrorMessage = "Mat khau khong duoc dung ky tu dac biet")]
        public string NewPassword { get; set; }
        [Compare("NewPassword", ErrorMessage = "mat khau nhap lai khong chinh xac")]
        [Required(ErrorMessage = "Không được để trống")]
        [StringLength(16, MinimumLength = 8, ErrorMessage = "8 đến 16 ký tự")]
        public string ConfirmPassword { get; set; }


    }
}