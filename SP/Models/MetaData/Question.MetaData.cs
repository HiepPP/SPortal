using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SetPortal.Models.MetaData
{
    [MetadataType(typeof(QuestionMetaData))] 
    public partial class Question
    {
        internal class QuestionMetaData
        {
            public int IDQuestionList { get; set; }
            public int IDCode { get; set; }
            [Required(ErrorMessage="Không được để trống")]
            public string Question1 { get; set; }
            public string Answer1 { get; set; }
            [Required(ErrorMessage = "Không được để trống")]
            public string Question2 { get; set; }
            public string Answer2 { get; set; }
            [Required(ErrorMessage = "Không được để trống")]
            public string Question3 { get; set; }
            public string Answer3 { get; set; }
            public virtual User User { get; set; }
        }
    }
}