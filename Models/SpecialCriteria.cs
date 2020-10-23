using System;

namespace SFB.Web.ApplicationCore.Models
{
    public class SpecialCriteria : IEquatable<SpecialCriteria>
    {
        public bool? SimilarPupils { get; set; }
        public bool Equals(SpecialCriteria other)
        {
            return this.SimilarPupils == other.SimilarPupils;
        }
    }
}
