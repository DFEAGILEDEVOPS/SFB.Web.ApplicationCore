using SFB.Web.ApplicationCore.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SFB.Web.ApplicationCore.Models
{
    public class EfficiencyMetricParentModel
    {
        private EfficiencyMetricParentDataObject _data;
        public long URN => _data.Urn;
        public int Rank
        {
            get
            {
                return NeighbourDataModels.Find(n => n.Urn == this.URN).Rank;
            }
        }
        public string Name => _data.Name;
        public string Phase => _data.Phase;
        public string PrimarySecondary => _data.PrimarySecondary;
        public string LocalAuthority => _data.Laname;
        public string SchoolType => _data.EstablishmentTypeGroup;
        public decimal? Progress8 => _data.P8Score;
        public decimal? Ks2 => _data.KS2Progress;

        public List<EfficiencyMetricNeighbourModel> NeighbourDataModels { 
            get {
                return _data.Neighbours.Select(n => new EfficiencyMetricNeighbourModel(n)).ToList();
            } 
        }

        public EfficiencyMetricParentModel(EfficiencyMetricParentDataObject data)
        {
            this._data = data;
        }
    }
}
