using SFB.Web.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SFB.Web.ApplicationCore.Models
{
    public class TrustHistoryModel
    {
        private TrustHistoryDataObject _data;
        public TrustHistoryModel(TrustHistoryDataObject data)
        {
            _data = data;
            BuildEventHistory();
        }

        //public int UID => _data.UID;
        //public string GroupName => _data.GroupName;
        //public string GroupStatus => _data.GroupStatus;
        //public DateTime GroupOpenDate => _data.GroupOpenDate;
        //public DateTime GroupClosedDate => _data.GroupClosedDate;
        public List<EventModel> Events { get; private set; }

        private void BuildEventHistory()
        {
            Events = new List<EventModel>();
            foreach (var academy in _data.Academies)
            {
                foreach (var @event in academy.Events)
                {
                    DateTime.TryParse(@event.Date, out DateTime date);
                    this.Events.Add(new EventModel(@event.Term, date, @event.EventType, academy.EstablishmentName, academy.URN ));
                }
            }

            this.Events = this.Events.OrderBy(e => e.Date).ToList();
        }
    }

    public class EventModel
    {
        public EventModel(string schoolYear, DateTime date, string @event, string schoolName, int schoolUrn)
        {
            SchoolYear = schoolYear;
            Date = date;
            Event = @event;
            OrganisationName = schoolName;
            OrganisationUrn = schoolUrn;
        }

        public string SchoolYear { get; set; }
        public DateTime Date { get; set; }
        public string Event { get; set; }
        public string OrganisationName { get; set; }
        public int OrganisationUrn { get; set; }

    }
}
