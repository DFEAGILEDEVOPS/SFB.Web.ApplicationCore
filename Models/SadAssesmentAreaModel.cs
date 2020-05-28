using SFB.Web.ApplicationCore.Entities;
using System.Collections.Generic;

namespace SFB.Web.ApplicationCore.Models
{
    public class SadAssesmentAreaModel
    {
        public string AssesmentAreaName { get; set; }

        public decimal SchoolData { get; set; }

        public decimal PercentageSchoolData { get; set; }

        public List<SADSchoolRatingsDataObject> AllTresholds { get; set; }

        public SadAssesmentAreaModel(string assesmentAreaName, decimal schoolData, decimal percentageSchoolData, List<SADSchoolRatingsDataObject> allTresholds)
        {
            AssesmentAreaName = assesmentAreaName;
            SchoolData = schoolData;
            PercentageSchoolData = percentageSchoolData;
            AllTresholds = allTresholds;
        }
    }
}
