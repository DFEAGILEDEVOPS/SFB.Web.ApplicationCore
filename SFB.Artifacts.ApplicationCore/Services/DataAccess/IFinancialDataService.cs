﻿using System.Collections.Generic;
using System.Threading.Tasks;
using SFB.Web.ApplicationCore.Entities;
using SFB.Web.ApplicationCore.Models;
using SFB.Web.ApplicationCore.Helpers.Enums;

namespace SFB.Web.ApplicationCore.Services.DataAccess
{
    public interface IFinancialDataService : ITermYearDataService
    {
        Task<List<SchoolTrustFinancialDataObject>> GetTrustSchoolsFinancialDataAsync(int uid, string term);
        Task<List<AcademySummaryDataObject>> GetAcademiesByCompanyNumberAsync(string term, int companyNo);
        Task<List<SchoolTrustFinancialDataObject>> GetMultipleTrustDataObjectsByCompanyNumbersAsync(List<int> companyNos);
        Task<FinancialDataModel> GetSchoolsLatestFinancialDataModelAsync(long urn, EstablishmentType schoolFinancialType);
        Task<SchoolTrustFinancialDataObject> GetSchoolFinancialDataObjectAsync(long urn, EstablishmentType schoolFinancialType, CentralFinancingType cFinance = CentralFinancingType.Exclude);
        Task<SchoolTrustFinancialDataObject> GetSchoolFinancialDataObjectAsync(long urn, string term, EstablishmentType schoolFinancialType, CentralFinancingType cFinance = CentralFinancingType.Exclude);
        Task<SchoolTrustFinancialDataObject> GetTrustFinancialDataObjectByCompanyNoAsync(int companyNo, string term, MatFinancingType matFinance);
        Task<SchoolTrustFinancialDataObject> GetTrustFinancialDataObjectByUidAsync(int uid, string term);
        Task<List<SchoolTrustFinancialDataObject>> SearchTrustsByCriteriaAsync(BenchmarkCriteria criteria);
        Task<List<SchoolTrustFinancialDataObject>> SearchSchoolsByCriteriaAsync(BenchmarkCriteria criteria, EstablishmentType estType, bool excludePartial = false, bool excludeFeds = true);                
        Task<int> SearchSchoolsCountByCriteriaAsync(BenchmarkCriteria criteria, EstablishmentType estType, bool excludePartial = false);
        Task<int> SearchTrustCountByCriteriaAsync(BenchmarkCriteria criteria);
        Task<List<int>> GetAllTrustCompanyNosAsync();
        Task<int> GetEstablishmentRecordCountAsync(string term, EstablishmentType estType);
        Task<List<FinancialDataModel>> GetFinancialDataForSchoolsAsync(List<SchoolSearchModel> schools, CentralFinancingType centralFinancing = CentralFinancingType.Include);
        Task<SchoolTrustFinancialDataObject> GetFederationFinancialDataObjectByFuidAsync(long fuid, string term);
    }

    public interface ITermYearDataService
    {
        Task<List<string>> GetActiveTermsForMatCentralAsync();
        Task<List<string>> GetActiveTermsForAcademiesAsync();
        Task<List<string>> GetActiveTermsForMaintainedAsync();
        Task<int> GetLatestFinancialDataYearAsync();        
        Task<int> GetLatestDataYearPerEstabTypeAsync(EstablishmentType type);
    }
}
