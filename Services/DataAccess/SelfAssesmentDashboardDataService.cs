using SFB.Web.ApplicationCore.DataAccess;
using SFB.Web.ApplicationCore.Entities;
using SFB.Web.ApplicationCore.Helpers.Enums;
using System.Collections.Generic;
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

        public async Task<List<SADSchoolRatingsDataObject>> GetSADSchoolRatingsDataObjectAsync(string assesmentArea, EstablishmentType financialType, string overallPhase, bool hasSixthForm, string londonWeighting, string size, string FSM, decimal score, string term)
        {
            var result = await _repository.GetSADSchoolRatingsDataObjectsAsync(assesmentArea, financialType, overallPhase, hasSixthForm, londonWeighting, size, FSM, term);
            return result;
        }
    }
}
