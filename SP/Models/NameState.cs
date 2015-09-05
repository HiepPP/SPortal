using System;
using System.Collections.Generic;

namespace SetPortal.Models
{
    public partial class NameState
    {
        public NameState()
        {
            this.EAduans = new List<EAduan>();
        }

        public int IDState { get; set; }
        public string State { get; set; }
        public virtual ICollection<EAduan> EAduans { get; set; }
    }
}
