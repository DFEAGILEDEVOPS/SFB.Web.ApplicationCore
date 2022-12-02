using System.Collections.Generic;
using System.Threading.Tasks;
using SFB.Web.ApplicationCore.Helpers.Enums;
using SFB.Web.ApplicationCore.Models;
using SFB.Web.ApplicationCore.Entities;

namespace SFB.Web.ApplicationCore.DataAccess
{
    public interface IFinancialDataRepository
    {
        Task<List<SchoolTrustFinancialDataObject>> GetTrustSchoolsFinancialDataAsync(int uid, string term);
        Task<List<AcademySummaryDataObject>> GetAcademiesContextualDataObjectAsync(string term, int companyNo);
        Task<SchoolTrustFinancialDataObject> GetTrustFinancialDataObjectbyCompanyNoAsync(int companyNo, string term, MatFinancingType matFinance);
        Task<SchoolTrustFinancialDataObject> GetTrustFinancialDataObjectByUidAsync(int uid, string term, MatFinancingType matFinance);
        Task<List<SchoolTrustFinancialDataObject>> GetMultipleTrustFinancialDataObjectsAsync(List<int> companyNoList, string term, MatFinancingType matFinance);
        Task<SchoolTrustFinancialDataObject> GetTrustFinancialDataObjectByMatNameAsync(string matName, string term, MatFinancingType matFinance);   
        Task<SchoolTrustFinancialDataObject> GetSchoolFinanceDataObjectAsync(long urn, string term, EstablishmentType schoolFinancialType, CentralFinancingType cFinance = CentralFinancingType.Exclude);
        Task<SchoolTrustFinancialDataObject> GetSchoolFinancialDataObjectAsync(long urn, string term, EstablishmentType schoolFinancialType, CentralFinancingType cFinance = CentralFinancingType.Exclude);
        Task<int> SearchTrustCountByCriteriaAsync(BenchmarkCriteria criteria);
        Task<List<SchoolTrustFinancialDataObject>> SearchTrustsByCriteriaAsync(BenchmarkCriteria criteria);
        Task<int> SearchSchoolsCountByCriteriaAsync(BenchmarkCriteria criteria, EstablishmentType estType, bool excludePartial = false);
        Task<List<SchoolTrustFinancialDataObject>> SearchSchoolsByCriteriaAsync(BenchmarkCriteria criteria, EstablishmentType estType, bool excludePartial = false, bool excludeFeds = true);
        Task<int> GetEstablishmentRecordCountAsync(string term, EstablishmentType estType);
        Task<SchoolTrustFinancialDataObject> GetFederationFinancialDataObjectByFuidAsync(long fuid, string term);
        Task<List<int>> GetAllTrustCompanyNos();
    }
}
