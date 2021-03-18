using SFB.Web.ApplicationCore.Entities;
using System;

namespace SFB.Web.ApplicationCore.Models
{
    public class EfficiencyMetricNeighbourModel
    {
        private EfficiencyMetricNeighbourDataObject _data;
        public EfficiencyMetricNeighbourModel(EfficiencyMetricNeighbourDataObject data)
        {
            this._data = data;
        }

        public int Urn => _data.Urn;

        public int Rank => _data.Rank;

        public string Name => _data.Name;

        public int LA => _data.La;

        public string LocalAuthority => _data.Laname;

        public decimal Pupils => _data.TotalFte;

        public decimal Ever6 => _data.FsmEverSix;

        public decimal SEN => _data.SenPercentage;

        public decimal ExpenditurePP => _data.Expenditurepp;

        public decimal? Progress8 => _data.P8Score;

        public decimal? Ks2 => _data.KS2Progress;

        public string PrimarySecondary => _data.PrimarySecondary;

        public string Address => $"{_data.Street}, {_data.Town}, {_data.Postcode}";

        public string Telephone => _data.Telephone;

        public string HeadTeacher => $"{_data.HeadFirstName} {_data.HeadLastName}";

        public string SchoolType => _data.TypeOfEstablishment;

        public string OfstedRating => _data.OfstedRating;

        public string ReligiousCharacter => _data.ReligiousCharacter;

        public string OverallPhase => _data.OverallPhase;
        
        public string Phase => _data.Phase;

        public decimal EfficiencyScore => _data.EfficiencyScore;

        public LocationDataObject Location => _data.Location;
    }
}
