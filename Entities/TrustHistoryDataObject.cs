using System;

namespace SFB.Web.ApplicationCore.Entities
{
    public class TrustHistoryDataObject
    {
        public int UID { get; set; }
        //public string GroupName { get; set; }
        //public string GroupStatus { get; set; }
        //public string GroupOpenDate { get; set; }
        //public string GroupClosedDate { get; set; }

        public AcademyOfTrust[] Academies { get; set; }
    }

    public class AcademyOfTrust
    {
        public int URN { get; set; }
        public string EstablishmentName { get; set; }

        public HistoricalEvent[] Events { get; set; }
    }

    public class HistoricalEvent
    {
        public string Term { get; set; }
        public string Date { get; set; }
        public string EventType { get; set; }
    }
}
