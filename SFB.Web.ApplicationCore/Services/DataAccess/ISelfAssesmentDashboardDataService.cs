using SFB.Web.ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SFB.Web.ApplicationCore.Services.DataAccess
{
    public interface ISelfAssesmentDashboardDataService
    {
        Task<SADSizeLookupDataObject> GetSADSizeLookupDataObject(string overallPhase, bool hasSixthForm, decimal noPupils, string term);
        Task<List<SADSizeLookupDataObject>> GetSADSizeLookups();
        Task<SADFSMLookupDataObject> GetSADFSMLookupDataObject(string overallPhase, bool hasSixthForm, decimal fsm, string term);
        Task<List<SADFSMLookupDataObject>> GetSADFSMLookups();
        Task<List<SADSchoolRatingsDataObject>> GetSADSchoolRatingsDataObjectAsync(string assesmentArea, string overallPhase, bool hasSixthForm, string londonWeighting, string size, string FSM, string term);

    }
}
