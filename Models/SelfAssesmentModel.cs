using SFB.Web.ApplicationCore.Entities;
using System.Collections.Generic;

namespace SFB.Web.ApplicationCore.Models
{
    public class SelfAssesmentModel
    {
        private string OverallPhase { get; set; }

        public int Urn { get; private set; }

        public string Name { get; private set; }

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

        public SelfAssesmentModel(int urn, string name, string overallPhase, bool hasSixthForm, string latestTerm)
        {
            Urn = urn;
            Name = name;
            OverallPhase = overallPhase;
            HasSixthForm = hasSixthForm;
            LatestTerm = latestTerm;
        }
    }
}
