﻿using SFB.Web.ApplicationCore.Entities;
using System;
using System.Collections.Generic;

namespace SFB.Web.ApplicationCore.Models
{
    public class SelfAssesmentModel
    {
        public SelfAssesmentModel()
        {
        }

        public long Urn { get; set; }

        public string Name { get; set; }
        
        public string FinanceType { get; set; }

        public string LondonWeighting { get; set; }

        public decimal? NumberOfPupilsLatestTerm { get; set; }

        public string OfstedRating { get; set; }

        public DateTime? OfstedInspectionDate { get;  set; }

        public decimal? P8Score { get; set; }

        public decimal? Ks2Score { get; set; }

        public string ProgressScoreType { get; set; }

        public decimal? Progress8Banding { get; set; }
        
        public decimal? FSMLatestTerm { get; set; }

        public string LatestTerm { get; set; }

        public bool HasSixthForm { get; set; }

        public bool IsReturnsComplete { get; set; }
        
        public bool DoReturnsExist { get; set; }

        public string OverallPhase { get; set; }

        public decimal? TotalExpenditureLatestTerm { get; set; }

        public decimal? TotalIncomeLatestTerm { get; set; }

        public decimal? TeachersTotalLastTerm { get; set; }

        public decimal? TeachersLeaderLastTerm { get; set; }

        public decimal? WorkforceTotalLastTerm { get; set; }

        public List<string> AvailableScenarioTerms { get; set; }
        public SADSizeLookupDataObject SadSizeLookup { get; set; }
        public SADFSMLookupDataObject SadFSMLookup { get; set; }
        public List<SadAssesmentAreaModel> SadAssesmentAreas { get; set; }

        public SelfAssesmentModel(long urn, 
            string name, 
            string overallPhase, 
            string financeType,
            string londonWeighting, 
            decimal? numberOfPupils, 
            decimal? fsm,
            string ofstedRating,
            DateTime? ofstedInspectionDate,
            decimal? p8Score,
            decimal? ks2Score,
            string progressScoreType,
            decimal? progress8Banding,
            bool hasSixthForm,
            decimal? totalExpenditure,
            decimal? totalIncome,
            string latestTerm,
            decimal? teachersTotal,
            decimal? teachersLeader,
            decimal? workforceTotal,
            bool isReturnsComplete,
            bool doReturnsExist)
        {
            Urn = urn;
            Name = name;
            OverallPhase = overallPhase;
            FinanceType = financeType;
            LondonWeighting = londonWeighting;
            NumberOfPupilsLatestTerm = numberOfPupils;
            FSMLatestTerm = fsm;
            OfstedRating = ofstedRating;
            OfstedInspectionDate = ofstedInspectionDate;
            P8Score = p8Score;
            Ks2Score = ks2Score;
            ProgressScoreType = progressScoreType;
            Progress8Banding = progress8Banding;
            HasSixthForm = hasSixthForm;
            TotalExpenditureLatestTerm = totalExpenditure;
            TotalIncomeLatestTerm = totalIncome;
            LatestTerm = latestTerm;
            TeachersTotalLastTerm = teachersTotal;
            TeachersLeaderLastTerm = teachersLeader;
            WorkforceTotalLastTerm = workforceTotal;
            IsReturnsComplete = isReturnsComplete;
            DoReturnsExist = doReturnsExist;
        }

        public SelfAssesmentModel(long urn,
            string name,
            string overallPhase,
            string financeType,
            string ofstedRating,
            DateTime? ofstedInspectionDate,
            string governmentOfficeRegion,
            string officialSixthForm) :
                this(urn, name, overallPhase, financeType, 
                    governmentOfficeRegion == "London" ? "Inner, Outer" : "Neither", 
                    null, null, ofstedRating, ofstedInspectionDate,
                    null, null, null, null, 
                    officialSixthForm == "Has a sixth form", 
                    null, null, null, null, null, null, false, false)
         { }
    }
}
