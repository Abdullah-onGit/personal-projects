using System;
using System.Collections.Generic;

namespace COVID19.Models
{
    public partial class CityMaster
    {
        public CityMaster()
        {
            InfectionMaster = new HashSet<InfectionMaster>();
        }

        public int CityMasterAutoId { get; set; }
        public string CityName { get; set; }
        public int StateMasterAutoId { get; set; }

        public virtual ICollection<InfectionMaster> InfectionMaster { get; set; }
    }
}
