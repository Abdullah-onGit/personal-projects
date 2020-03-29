using System;
using System.Collections.Generic;

namespace FetchCovid19Data.Models
{
    public partial class InfectionMaster
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
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public int? CreatedBy { get; set; }
        public DateTime? LastUpdatedDateTime { get; set; }
        public int? LastUpdatedBy { get; set; }
        public bool ActiveStatus { get; set; }=true;

        public virtual CityMaster CityMasterAuto { get; set; }
        public virtual CountryMaster CountryMasterAuto { get; set; }
        public virtual StateMaster StateMasterAuto { get; set; }
    }
}
