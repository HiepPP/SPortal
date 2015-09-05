using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace SetPortal.Models
{
    [MetadataType(typeof(ContactUsMetaData))]
    public partial class ContactWithU
    {
        internal class ContactUsMetaData
        {
            public int ID { get; set; }
            public string HinhAnh { get; set; }
            public string Name { get; set; }
            [EmailAddress(ErrorMessage = "Email khong hop le!")]
            public string Email { get; set; }
            public string SubjectEmail { get; set; }
            public string ContentEmail { get; set; }
        }
    }
}