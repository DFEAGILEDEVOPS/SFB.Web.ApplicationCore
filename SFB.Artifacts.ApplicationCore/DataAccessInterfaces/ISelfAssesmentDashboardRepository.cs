﻿using SFB.Web.ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SFB.Web.ApplicationCore.DataAccess
{
    public interface ISelfAssesmentDashboardRepository
    {
        Task<SADSizeLookupDataObject> GetSADSizeLookupDataObjectAsync(string overallPhase, bool hasSixthForm, decimal noPupils, string term);
        
        Task<SADFSMLookupDataObject> GetSADFSMLookupDataObjectAsync(string overallPhase, bool hasSixthForm, decimal fsm, string term);
        Task<List<SADSizeLookupDataObject>> GetSADSizeLookupListDataObject();
        Task<List<SADFSMLookupDataObject>> GetSADFSMLookupListDataObject();
        Task<List<SADSchoolRatingsDataObject>> GetSADSchoolRatingsDataObjectsAsync(string assesmentArea, string overallPhase, bool hasSixthForm, string londonWeighting, string size, string FSM, string term);

    }
}
