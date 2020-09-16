namespace SFB.Web.ApplicationCore.Entities
{
    public class OLD_EfficiencyMetricNeighbourListItemObject
    {
        public OLD_EfficiencyMetricNeighbourListItemObject(int urn, int rank)
        {
            URN = urn;
            Rank = rank;
        }
        public int URN { get; set; }

        public int Rank { get; set; }
    }
}