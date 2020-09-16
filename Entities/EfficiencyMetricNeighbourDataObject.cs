using System.Collections.Generic;

namespace SFB.Web.ApplicationCore.Entities
{
    public class EfficiencyMetricNeighbourDataObject
    {
        public int Urn { get; set; }
        public string Name { get; set; }
        public int EfficiencyDecileNeighbour { get; set; }
        public int La { get; set; }
        public string Laname { get; set; }
        public decimal Fte { get; set; }
        public decimal Ever6Pub { get; set;}
        public decimal SenPub { get; set; }
        public decimal Expenditurepp { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string HeadTeacher { get; set; }
        public string SchoolType { get; set; }
        public string OfstedRating { get; set; }
        public string ReligiousCharacter { get; set; }
        public string OverallPhase { get; set; }
        public decimal Progress8 { get; set; }
        public decimal EfficiencyScore { get; set; }
        public object Street { get; }
        public object Town { get; }
        public object Postcode { get; }
        public string TelephoneNum { get; internal set; }
        public string TypeOfEstablishment { get; internal set; }
        public object HeadFirstName { get; internal set; }
        public object HeadLastName { get; internal set; }

        public LocationDataObject Location { get; set; }

        public List<EfficiencyMetricNeighbourDataObject> Neighbours { get; set; }
    }
}