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

        [Required(ErrorMessage = "Enter minimum number of pupils")]
        [Range(0, int.MaxValue, ErrorMessage = "Enter a value greater than zero for minimum number of pupils")]
        public decimal? NoPupilsMin { get; set; }
        
        [Required(ErrorMessage = "Enter maximum number of pupils")]
        [Range(0, int.MaxValue, ErrorMessage = "Enter a value greater than zero for maximum number of pupils")]
        public decimal? NoPupilsMax { get; set; }

        [Required(ErrorMessage = "Enter minimum FSM percentage")]
        [Range(0.0, double.MaxValue, ErrorMessage = "Enter a value greater than zero for minimum FSM percentage")]
        public decimal? PercentageFSMMin { get; set; }
                
        [Required(ErrorMessage = "Enter maximum FSM percentage")]
        [Range(0.0, double.MaxValue, ErrorMessage = "Enter a value greater than zero for maximum FSM percentage")]
        public decimal? PercentageFSMMax { get; set; }

        [Required(ErrorMessage = "Enter minimum SEN percentage")]
        [Range(0.0, double.MaxValue, ErrorMessage = "Enter a value greater than zero for minimum SEN percentage")]
        public decimal? PercentageSENMin { get; set; }

        [Required(ErrorMessage = "Enter maximum SEN percentage")]
        [Range(0.0, double.MaxValue, ErrorMessage = "Enter a value greater than zero for maximum SEN percentage")]
        public decimal? PercentageSENMax { get; set; }
        
        [Required]
        public decimal RRPerIncomeMin { get; set; }

        [Required(ErrorMessage = "Enter minimum total expenditure per pupil")]
        [Range(0.0, double.MaxValue, ErrorMessage = "Enter a value greater than zero for minimum total expenditure per pupil")]
        public decimal? PerPupilExpMin { get; set; }

        [Required(ErrorMessage = "Enter maximum total expenditure per pupil")]
        [Range(0.0, double.MaxValue, ErrorMessage = "Enter a value greater than zero for maximum total expenditure per pupil")]
        public decimal? PerPupilExpMax { get; set; }

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
