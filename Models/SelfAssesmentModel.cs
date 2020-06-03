using SFB.Web.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;

namespace SFB.Web.ApplicationCore.Models
{
    public class SelfAssesmentModel
    {
        private string OverallPhase { get; set; }

        public int Urn { get; private set; }

        public string Name { get; private set; }
        
        public string LondonWeighting { get; private set; }

        public decimal NumberOfPupils { get; private set; }

        public string OfstedRating { get; private set; }

        public DateTime OfstedInspectionDate { get; private set; }

        public decimal ProgressScore { get; private set; }

        public string ProgressScoreType { get; private set; }

        public decimal Progress8Banding { get; private set; }
        
        public decimal FSM { get; private set; }

        public string LatestTerm { get; set; }

        private bool HasSixthForm { get; set; }

        public string OverallPhaseWSixthForm
        {
            get
            {
                if (HasSixthForm)
                {
                    return $"{OverallPhase} with sixth form" ;
                }
                else
                {
                    return OverallPhase;
                }
                
            }
        }

        public SADSizeLookupDataObject SadSizeLookup { get; set; }
        public SADFSMLookupDataObject SadFSMLookup { get; set; }
        public List<SadAssesmentAreaModel> SadAssesmentAreas { get; set; }

        public SelfAssesmentModel(int urn, 
            string name, 
            string overallPhase, 
            string londonWeighting, 
            decimal numberOfPupils, 
            decimal fsm,
            string ofstedRating,
            string ofstedInspectionDate,
            decimal progressScore,
            string progressScoreType,
            decimal progress8Banding,
            bool hasSixthForm, 
            string latestTerm)
        {
            Urn = urn;
            Name = name;
            OverallPhase = overallPhase;
            LondonWeighting = londonWeighting;
            NumberOfPupils = numberOfPupils;
            FSM = fsm;
            OfstedRating = ofstedRating;
            OfstedInspectionDate = DateTime.Parse(ofstedInspectionDate, CultureInfo.CurrentCulture, DateTimeStyles.None);
            ProgressScore = progressScore;
            ProgressScoreType = progressScoreType;
            Progress8Banding = progress8Banding;
            HasSixthForm = hasSixthForm;
            LatestTerm = latestTerm;
        }
    }
}
