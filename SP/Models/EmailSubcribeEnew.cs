using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SetPortal.Models
{
    public partial class EmailSubcribeEnew
    {
        public int IDEmail { get; set; }
        [EmailAddress(ErrorMessage = "Email không hợp lệ!")]
        [Required(ErrorMessage = "Vui lòng nhập Email!")]
        public string EmailSubcribe { get; set; }
        public string UserID { get; set; }
    }
}
