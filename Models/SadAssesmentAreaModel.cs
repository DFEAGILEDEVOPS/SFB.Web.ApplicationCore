﻿using SFB.Web.ApplicationCore.Entities;
using System.Collections.Generic;

namespace SFB.Web.ApplicationCore.Models
{
    public class SadAssesmentAreaModel
    {
        public string AssessmentAreaType { get; set; }
        public string AssessmentAreaName { get; set; }

        public decimal? SchoolDataLatestTerm { get; set; }

        public decimal? TotalForAreaTypeLatestTerm { get; set; }

        public List<SADSchoolRatingsDataObject> AllTresholds { get; set; }

        public SadAssesmentAreaModel(string assessmentAreaType,string assessmentAreaName, decimal? schoolData, decimal? totalForAreaType, List<SADSchoolRatingsDataObject> allTresholds)
        {
            AssessmentAreaType = assessmentAreaType;
            AssessmentAreaName = assessmentAreaName;
            SchoolDataLatestTerm = schoolData;
            TotalForAreaTypeLatestTerm = totalForAreaType;
            AllTresholds = allTresholds;
        }
    }
}
