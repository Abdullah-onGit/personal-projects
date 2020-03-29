using System;
using System.Collections.Generic;

namespace COVID19.Models
{
    public class vInfectionMaster : InfectionMasterBase
    {
        public string StateName { get; set; }
    }
    public class InfectionMaster : InfectionMasterBase
    {

    }
    public partial class InfectionMasterBase
    {
        public int InfectionMasterAutoId { get; set; }
        public string AreaType { get; set; }
        public int? CountryMasterAutoId { get; set; }
        public int? StateMasterAutoId { get; set; }
        public int? CityMasterAutoId { get; set; }
        public DateTime InfectionDateTime { get; set; }
        public int TotalConfirmedCasesNational { get; set; }
        public int TotalConfirmedCasesForeignNational { get; set; }
        public int Cured { get; set; }
        public int Death { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? LastUpdatedDateTime { get; set; }
        public int? LastUpdatedBy { get; set; }
        public bool? ActiveStatus { get; set; }

        public virtual CityMaster CityMasterAuto { get; set; }
        public virtual CountryMaster CountryMasterAuto { get; set; }
        public virtual StateMaster StateMasterAuto { get; set; }
    }
}
