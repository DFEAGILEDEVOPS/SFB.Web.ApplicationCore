using SFB.Web.ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SFB.Web.ApplicationCore.DataAccess
{
    public interface IEdubaseRepository
    {
        Task<EdubaseDataObject> GetSchoolDataObjectByUrnAsync(long urn);
        Task<List<EdubaseDataObject>> GetSchoolsByLaEstabAsync(string laEstab, bool openOnly);        
        Task<List<EdubaseDataObject>> GetMultipleSchoolDataObjectsByUrnsAsync(List<long> urns);
        Task<List<long>> GetAllSchoolUrnsAsync();
        Task<IEnumerable<EdubaseDataObject>> GetAcademiesByCompanyNoAsync(int companyNo);
        Task<int> GetAcademiesCountByCompanyNoAsync(int companyNo);
        Task<IEnumerable<EdubaseDataObject>> GetAcademiesByUidAsync(int uid);
        Task<List<long>> GetAllFederationUids();
    }
}
