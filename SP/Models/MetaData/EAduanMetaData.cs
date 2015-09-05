using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace SetPortal.Models
{
    [MetadataType(typeof(EAduanMetaData))]
    public partial class EAduan
    {
        internal class EAduanMetaData
        {
            public int IDEAduan { get; set; }
            public string ComplaintName { get; set; }
            [EmailAddress(ErrorMessage = "{0} không hợp lệ!")]
            public string Email { get; set; }
            public string Number { get; set; }
            public string Address { get; set; }
            public string Postcode { get; set; }
            public string Town { get; set; }
            public Nullable<int> IDState { get; set; }
            public string Company { get; set; }
            public string LocationCompany { get; set; }
            public string Subject { get; set; }
            public string Complaint { get; set; }
            public string Image { get; set; }
            public string FileName { get; set; }
        }
    }
}