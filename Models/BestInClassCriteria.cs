using SFB.Web.ApplicationCore.Helpers.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace SFB.Web.ApplicationCore.Models
{
    public class BestInClassCriteria : IEquatable<BestInClassCriteria>
    {
        public EstablishmentType EstablishmentType { get; set; }
        public string OverallPhase { get; set; }
        public string UrbanRural { get; set; }
        public decimal? Ks2ProgressScoreMin { get; set; }
        public decimal? Ks2ProgressScoreMax { get; set; }
        public decimal? Ks4ProgressScoreMin { get; set; }
        public decimal? Ks4ProgressScoreMax { get; set; }        
        [Required]
        public decimal NoPupilsMin { get; set; }
        [Required]
        public decimal NoPupilsMax { get; set; }
        [Required]
        public decimal PercentageFSMMin { get; set; }
        [Required]
        public decimal PercentageFSMMax { get; set; }
        [Required]
        public decimal PercentageSENMin { get; set; }
        [Required]
        public decimal PercentageSENMax { get; set; }
        [Required]
        public decimal RRPerIncomeMin { get; set; }
        [Required]
        public decimal PerPupilExpMin { get; set; }
        [Required]
        public decimal PerPupilExpMax { get; set; }
        public bool UREnabled { get; set; }
        public bool SENEnabled { get; set; }
        public string[] LondonWeighting { get; set; }

        public bool Equals(BestInClassCriteria other)
        {
            return this.EstablishmentType == other.EstablishmentType
                && this.OverallPhase == other.OverallPhase
                && this.UrbanRural == other.UrbanRural
                && this.Ks2ProgressScoreMin == other.Ks2ProgressScoreMin
                && this.Ks2ProgressScoreMax == other.Ks2ProgressScoreMax
                && this.Ks4ProgressScoreMin == other.Ks4ProgressScoreMin
                && this.Ks4ProgressScoreMax == other.Ks4ProgressScoreMax
                && this.PercentageFSMMin == other.PercentageFSMMin
                && this.PercentageFSMMax == other.PercentageFSMMax
                && this.PercentageSENMin == other.PercentageSENMin
                && this.PercentageSENMax == other.PercentageSENMax
                && this.NoPupilsMin == other.NoPupilsMin
                && this.NoPupilsMax == other.NoPupilsMax
                && this.RRPerIncomeMin == other.RRPerIncomeMin
                && this.PerPupilExpMin == other.PerPupilExpMin
                && this.PerPupilExpMax == other.PerPupilExpMax
                && this.UREnabled == other.UREnabled
                && this.SENEnabled == other.SENEnabled
                && this.LondonWeighting == other.LondonWeighting;
        }
    }
}
