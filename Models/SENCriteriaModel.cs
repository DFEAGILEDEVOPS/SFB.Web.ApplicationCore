using System.Runtime.CompilerServices;

namespace SFB.Web.ApplicationCore.Models
{
    public class SENCriteriaModel
    {
        public string DataName { get; set; }
        public string Definition { get; set; }
        public decimal? Value { get; set; }

        public SENCriteriaModel(string name, string definition, decimal? value)
        {
            DataName = name;
            Definition = definition;
            Value = value;
        }
    }
}
