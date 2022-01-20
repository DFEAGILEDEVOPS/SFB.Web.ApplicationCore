using SFB.Web.ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SFB.Web.ApplicationCore.Services.DataAccess
{
    public interface IContextDataService
    {
        Task<EdubaseDataObject> GetSchoolDataObjectByUrnAsync(long urn);        
        Task<List<long>> GetAllSchoolUrnsAsync();
        Task<List<long>> GetAllFederationUidsAsync();
        Task<List<EdubaseDataObject>> GetSchoolDataObjectByLaEstabAsync(string laEstab, bool openOnly);        
        Task<List<EdubaseDataObject>> GetMultipleSchoolDataObjectsByUrnsAsync(List<long> urns);
        Task<IEnumerable<EdubaseDataObject>> GetAcademiesByCompanyNumberAsync(int companyNo);
        Task<IEnumerable<EdubaseDataObject>> GetAcademiesByUidAsync(int uid);
        Task<int> GetAcademiesCountByCompanyNumberAsync(int companyNo);
    }
}
