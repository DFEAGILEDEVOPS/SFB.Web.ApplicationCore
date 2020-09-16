using System.Collections.Generic;

namespace SFB.Web.ApplicationCore.Models
{
    public class OLD_EfficiencyMetricParentModel
    {      
        public int URN { get; set; }
        public int Rank { get; set; }
        public string Name { get; set; }

        public string Phase { get; set; }

        public string LocalAuthority { get; set; }

        public List<OLD_EfficiencyMetricNeighbourModel> NeighbourDataModels { get; set; }

        public OLD_EfficiencyMetricParentModel(int urn, int rank, string name, string phase, string localAuthority, List<OLD_EfficiencyMetricNeighbourModel> neighbourDataModels)
        {
            URN = urn;
            Rank = rank;
            Name = name;
            Phase = phase;
            LocalAuthority = localAuthority;
            NeighbourDataModels = neighbourDataModels;
        }

    }
}
