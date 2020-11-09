using SFB.Web.ApplicationCore.Entities;
using System;
using System.Collections.Generic;

namespace SFB.Web.ApplicationCore.Models
{
    public class SelfAssesmentModel
    {
        public int Urn { get; private set; }

        public string Name { get; private set; }
        
        public string FinanceType { get; private set; }

        public string LondonWeighting { get; private set; }

        public decimal NumberOfPupilsLatestTerm { get; private set; }

        public string OfstedRating { get; private set; }

        public DateTime? OfstedInspectionDate { get; private set; }

        public decimal? P8Score { get; private set; }

        public decimal? Ks2Score { get; private set; }

        public string ProgressScoreType { get; private set; }

        public decimal Progress8Banding { get; private set; }
        
        public decimal FSMLatestTerm { get; private set; }

        public string LatestTerm { get; set; }

        public bool HasSixthForm { get; set; }

        public bool IsReturnsComplete { get; set; }

        public string OverallPhase { get; set; }

        public decimal TotalExpenditureLatestTerm { get; set; }

        public decimal TotalIncomeLatestTerm { get; set; }

        public decimal TeachersTotalLastTerm { get; set; }

        public decimal TeachersLeaderLastTerm { get; set; }

        public decimal WorkforceTotalLastTerm { get; set; }

        public SADSizeLookupDataObject SadSizeLookup { get; set; }
        public SADFSMLookupDataObject SadFSMLookup { get; set; }
        public List<SadAssesmentAreaModel> SadAssesmentAreas { get; set; }

        public SelfAssesmentModel(int urn, 
            string name, 
            string overallPhase, 
            string financeType,
            string londonWeighting, 
            decimal numberOfPupils, 
            decimal fsm,
            string ofstedRating,
            DateTime? ofstedInspectionDate,
            decimal? p8Score,
            decimal? ks2Score,
            string progressScoreType,
            decimal progress8Banding,
            bool hasSixthForm,
            decimal totalExpenditure,
            decimal totalIncome,
            string latestTerm,
            decimal teachersTotal,
            decimal teachersLeader,
            decimal workforceTotal,
            bool isReturnsComplete)
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
        }
    }
}
