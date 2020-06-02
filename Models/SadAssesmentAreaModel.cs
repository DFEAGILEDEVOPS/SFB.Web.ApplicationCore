using SFB.Web.ApplicationCore.Entities;
using System.Collections.Generic;

namespace SFB.Web.ApplicationCore.Models
{
    public class SadAssesmentAreaModel
    {
        public string AssessmentAreaType { get; set; }
        public string AssessmentAreaName { get; set; }

        public decimal SchoolData { get; set; }

        public decimal PercentageSchoolData { get; set; }

        public List<SADSchoolRatingsDataObject> AllTresholds { get; set; }

        public SadAssesmentAreaModel(string assessmentAreaType,string assessmentAreaName, decimal schoolData, decimal percentageSchoolData, List<SADSchoolRatingsDataObject> allTresholds)
        {
            AssessmentAreaType = assessmentAreaType;
            AssessmentAreaName = assessmentAreaName;
            SchoolData = schoolData;
            PercentageSchoolData = percentageSchoolData;
            AllTresholds = allTresholds;
        }
    }
}
