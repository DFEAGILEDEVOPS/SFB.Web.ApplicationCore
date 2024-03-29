using System.Collections.Generic;
using SFB.Web.ApplicationCore.Entities;
using System.Threading.Tasks;
using SFB.Web.ApplicationCore.DataAccess;

namespace SFB.Web.ApplicationCore.Services.DataAccess
{
    public class ContextDataService : IContextDataService
    {
        private readonly IEdubaseRepository _edubaseRepository;

        public ContextDataService(IEdubaseRepository edubaseRepository)
        {
            _edubaseRepository = edubaseRepository;
        }

        public async Task<EdubaseDataObject> GetSchoolDataObjectByUrnAsync(long urn)
        {
            return await _edubaseRepository.GetSchoolDataObjectByUrnAsync(urn);
        }

        public async Task<List<long>> GetAllSchoolUrnsAsync()
        {
            return await _edubaseRepository.GetAllSchoolUrnsAsync();
        }

        public async Task<List<long>> GetAllFederationUidsAsync()
        {
            return await _edubaseRepository.GetAllFederationUids();
        }

        public async Task<List<EdubaseDataObject>> GetSchoolDataObjectByLaEstabAsync(string laEstab, bool openOnly)
        {
            return await _edubaseRepository.GetSchoolsByLaEstabAsync(laEstab, openOnly);
        }

        public async Task<List<EdubaseDataObject>> GetMultipleSchoolDataObjectsByUrnsAsync(List<long> urns)
        {
            return await _edubaseRepository.GetMultipleSchoolDataObjectsByUrnsAsync(urns);
        }

        public async Task<IEnumerable<EdubaseDataObject>> GetAcademiesByCompanyNumberAsync(int companyNo)
        {
            return await _edubaseRepository.GetAcademiesByCompanyNoAsync(companyNo);
        }

        public async Task<int> GetAcademiesCountByCompanyNumberAsync(int companyNo)
        {
            return await _edubaseRepository.GetAcademiesCountByCompanyNoAsync(companyNo);
        }

        public async Task<IEnumerable<EdubaseDataObject>> GetAcademiesByUidAsync(int uid)
        {
            return await _edubaseRepository.GetAcademiesByUidAsync(uid);
        }

    }
}