using System;
using System.Collections.Generic;

namespace FetchCovid19Data.Models
{
    public partial class StateMaster
    {
        public StateMaster()
        {
            InfectionMaster = new HashSet<InfectionMaster>();
        }

        public int StateMasterAutoId { get; set; }
        public string StateName { get; set; }
        public int CountryMasterAutoId { get; set; }

        public virtual CountryMaster CountryMasterAuto { get; set; }
        public virtual ICollection<InfectionMaster> InfectionMaster { get; set; }
    }
}
