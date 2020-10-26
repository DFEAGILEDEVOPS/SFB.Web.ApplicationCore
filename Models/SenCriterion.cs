using SFB.Web.ApplicationCore.Helpers.Constants;

namespace SFB.Web.ApplicationCore.Models
{
    public class SenCriterion
    {
        public SenCriterion(int order, string name, decimal? originalValue)
        {
            Order = order;
            Name = name;
            Original = originalValue;
            Min = Original - CriteriaSearchConfig.SPECIALS_CONSTANT_SEN_TOPUP[order];
            Max = Original + CriteriaSearchConfig.SPECIALS_CONSTANT_SEN_TOPUP[order];
        }

        public int Order { get; set; }
        public string Name { get; set; }
        public decimal? Min { get; set; }
        public decimal? Max { get; set; }
        public decimal? Original { get; set; }
    }
}
