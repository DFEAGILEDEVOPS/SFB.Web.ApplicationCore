using SFB.Web.ApplicationCore.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SFB.Web.ApplicationCore.Models
{
    public class EfficiencyMetricParentModel
    {
        private EfficiencyMetricParentDataObject _data;
        public int URN => _data.Urn;
        public int Rank => _data.EfficiencyDecileinGroup;
        public string Name => _data.Name;
        public string Phase => _data.Phase;      
        public string LocalAuthority => _data.Laname;
        public string SchoolType => _data.SchoolType;

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
