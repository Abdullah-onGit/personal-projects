using System;
using System.Collections.Generic;

namespace FetchCovid19Data.Models
{
    public partial class CountryMaster
    {
        public CountryMaster()
        {
            InfectionMaster = new HashSet<InfectionMaster>();
            StateMaster = new HashSet<StateMaster>();
        }

        public int CountryMasterAutoId { get; set; }
        public string Isocode { get; set; }
        public string CountryName { get; set; }
        public int PhoneCode { get; set; }

        public virtual ICollection<InfectionMaster> InfectionMaster { get; set; }
        public virtual ICollection<StateMaster> StateMaster { get; set; }
    }
}
