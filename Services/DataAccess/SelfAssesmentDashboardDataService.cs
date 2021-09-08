using SFB.Web.ApplicationCore.DataAccess;
using SFB.Web.ApplicationCore.Entities;
using SFB.Web.ApplicationCore.Helpers.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFB.Web.ApplicationCore.Services.DataAccess
{
    public class SelfAssesmentDashboardDataService : ISelfAssesmentDashboardDataService
    {
        private readonly ISelfAssesmentDashboardRepository _repository;
        public SelfAssesmentDashboardDataService(ISelfAssesmentDashboardRepository repository)
        {
            _repository = repository;
        }

        public async Task<SADSizeLookupDataObject> GetSADSizeLookupDataObject(string overallPhase, bool hasSixthForm, decimal noPupils, string term)
        {
            var result = await _repository.GetSADSizeLookupDataObjectAsync(overallPhase, hasSixthForm, noPupils, term);

            return result;
        }

        public async Task<SADFSMLookupDataObject> GetSADFSMLookupDataObject(string overallPhase, bool hasSixthForm, decimal fsm, string term)
        {
            var result = await _repository.GetSADFSMLookupDataObjectAsync(overallPhase, hasSixthForm, fsm, term);
            return result;
        }

        public async Task<List<SADSizeLookupDataObject>> GetSADSizeLookups()
        {
            var result = await _repository.GetSADSizeLookupListDataObject();
            return result;
        }

        public async Task<List<SADFSMLookupDataObject>> GetSADFSMLookups()
        {
            var result = await _repository.GetSADFSMLookupListDataObject();
            return result;
        }

        public async Task<List<SADSchoolRatingsDataObject>> GetSADSchoolRatingsDataObjectAsync(string assesmentArea, string overallPhase, bool hasSixthForm, string londonWeighting, string size, string FSM, string term)
        {
            var results = await _repository.GetSADSchoolRatingsDataObjectsAsync(assesmentArea, overallPhase, hasSixthForm, londonWeighting, size, FSM, term);
            if (results.Count > 0)
            {
                var ordered = results.OrderBy(r => r.Term).ToList();
                var latestRatings = ordered.GroupBy(r => r.Term).Last();
                return latestRatings.ToList();
            }
            else {
                return new List<SADSchoolRatingsDataObject>();
            }
        }
    }
}
