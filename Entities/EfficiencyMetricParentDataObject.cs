using System.Collections.Generic;

namespace SFB.Web.ApplicationCore.Entities
{
    public class EfficiencyMetricParentDataObject
    {
        public long Urn { get; set; }
        public int La { get; set; }
        public string Laname { get; set; }
        public string Name { get; set; }
        public string Phase { get; set; }
        public string PrimarySecondary { get; set; }
        public string EstablishmentTypeGroup { get; set; }
        public decimal TotalFte { get; set; }
        public decimal SenPercentage { get; set; }
        public decimal FsmEverSix { get; set; }
        public decimal? KS2Progress { get; set; }
        public decimal? P8Score { get; set; }
        public decimal? Ks2 { get; set; }
        public decimal Expenditurepp { get; set; }    
        public List<EfficiencyMetricNeighbourDataObject> Neighbours { get; set;}
    }
}
