using System.Collections.Generic;

namespace SFB.Web.ApplicationCore.Entities
{
    public class EfficiencyMetricNeighbourDataObject
    {
        public int Urn { get; set; }
        public string Name { get; set; }
        public decimal Rank { get; set; }
        public int La { get; set; }
        public string Laname { get; set; }
        public decimal Fte { get; set; }
        public decimal Ever6Pub { get; set;}
        public decimal SenPub { get; set; }
        public decimal Expenditurepp { get; set; }
        public string HeadTeacher { get; set; }
        public string OfstedRating { get; set; }
        public string ReligiousCharacter { get; set; }
        public string OverallPhase { get; set; }
        public string Phase { get; set; }
        public string PrimarySecondary { get; set; }
        public decimal? KS2Progress { get; set; }
        public decimal? P8Score { get; set; }
        public decimal EfficiencyScore { get; set; }
        public string Street { get; set; }
        public string Town { get; set; }
        public string Postcode { get; set; }
        public string Telephone { get; set; }
        public string TypeOfEstablishment { get; set; }
        public string HeadFirstName { get; set; }
        public string HeadLastName { get; set; }
        
        public LocationDataObject Location { get; set; }

    }
}