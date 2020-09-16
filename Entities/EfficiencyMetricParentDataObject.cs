using System.Collections.Generic;

namespace SFB.Web.ApplicationCore.Entities
{
    public class EfficiencyMetricParentDataObject
    {
        public int Urn { get; set; }
        public int La { get; set; }
        public string Laname { get; set; }
        public string Name { get; set; }
        public string Phase { get; set; }
        public decimal Fte { get; set; }
        public decimal Senpub { get; set; }
        public decimal Ever6pub { get; set; }
        public decimal Progress8 { get; set; }
        public decimal Expenditurepp { get; set; }
        public int EfficiencyDecileinGroup { get; set; }
        public List<EfficiencyMetricNeighbourDataObject> Neighbours { get; set;}
    }
}
