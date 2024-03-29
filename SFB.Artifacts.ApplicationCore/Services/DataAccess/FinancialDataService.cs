﻿using System.Collections.Generic;
using System.Threading.Tasks;
using SFB.Web.ApplicationCore.Entities;
using SFB.Web.ApplicationCore.Models;
using SFB.Web.ApplicationCore.Helpers;
using System.Linq;
using SFB.Web.ApplicationCore.DataAccess;
using SFB.Web.ApplicationCore.Helpers.Enums;
using SFB.Web.ApplicationCore.Helpers.Constants;
using System;

namespace SFB.Web.ApplicationCore.Services.DataAccess
{
    public class FinancialDataService : IFinancialDataService
    {
        private readonly IDataCollectionManager _dataCollectionManager;
        private readonly IFinancialDataRepository _financialDataRepository;

        public FinancialDataService(IDataCollectionManager dataCollectionManager, IFinancialDataRepository financialDataRepository)
        {
            _dataCollectionManager = dataCollectionManager;
            _financialDataRepository = financialDataRepository;
        }

        public async Task<List<SchoolTrustFinancialDataObject>> GetTrustSchoolsFinancialDataAsync(int uid, string term)
        {
            return await _financialDataRepository.GetTrustSchoolsFinancialDataAsync(uid, term);
        }
        public async Task<SchoolTrustFinancialDataObject> GetSchoolFinancialDataObjectAsync(long urn, string term, EstablishmentType schoolFinancialType, CentralFinancingType cFinance)
        {
            return await _financialDataRepository.GetSchoolFinanceDataObjectAsync(urn, term, schoolFinancialType, cFinance);
        }

        public async Task<SchoolTrustFinancialDataObject> GetSchoolFinancialDataObjectAsync(long urn, EstablishmentType schoolFinancialType, CentralFinancingType cFinance = CentralFinancingType.Exclude)
        {
            var latestYear = await GetLatestDataYearPerEstabTypeAsync(schoolFinancialType);
            var term = SchoolFormatHelpers.FinancialTermFormatAcademies(latestYear);
            return await _financialDataRepository.GetSchoolFinancialDataObjectAsync(urn, term, schoolFinancialType, cFinance);
        }

        public async Task<FinancialDataModel> GetSchoolsLatestFinancialDataModelAsync(long urn, EstablishmentType schoolFinancialType)
        {
            var latestYear = await GetLatestDataYearPerEstabTypeAsync(schoolFinancialType);
            var term = SchoolFormatHelpers.FinancialTermFormatAcademies(latestYear);
            var schoolFinancialDataObject = await _financialDataRepository.GetSchoolFinancialDataObjectAsync(urn, term, schoolFinancialType);
            return new FinancialDataModel(urn.ToString(), term, schoolFinancialDataObject, schoolFinancialType);
        }

        public async Task<List<SchoolTrustFinancialDataObject>> GetMultipleTrustDataObjectsByCompanyNumbersAsync(List<int> companyNos)
        {
            var term = (await GetActiveTermsForMatCentralAsync()).First();            
            var trustList = await _financialDataRepository.GetMultipleTrustFinancialDataObjectsAsync(companyNos, term, MatFinancingType.TrustOnly);
            return trustList;
        }

        public async Task<int> GetLatestFinancialDataYearAsync()
        {
            return await _dataCollectionManager.GetOverallLatestFinancialDataYearAsync();
        }

        public async Task<int> GetLatestDataYearPerEstabTypeAsync(EstablishmentType type)
        {
            return await _dataCollectionManager.GetLatestFinancialDataYearPerEstabTypeAsync(type);
        }

        public async Task<List<string>> GetActiveTermsForMatCentralAsync()
        {
            return await _dataCollectionManager.GetActiveTermsByDataGroupAsync(DataGroups.MATCentral);
        }

        public async Task<List<string>> GetActiveTermsForMaintainedAsync()
        {
            return await _dataCollectionManager.GetActiveTermsByDataGroupAsync(DataGroups.Maintained);
        }

        public async Task<List<string>> GetActiveTermsForAcademiesAsync()
        {
            return await _dataCollectionManager.GetActiveTermsByDataGroupAsync(DataGroups.Academies);
        }

        public async Task<List<SchoolTrustFinancialDataObject>> SearchSchoolsByCriteriaAsync(BenchmarkCriteria criteria, EstablishmentType estType)
        {
            return await _financialDataRepository.SearchSchoolsByCriteriaAsync(criteria, estType, false, true);
        }

        public async Task<List<SchoolTrustFinancialDataObject>> SearchSchoolsByCriteriaAsync(BenchmarkCriteria criteria, EstablishmentType estType, bool excludePartial = false, bool excludeFeds = true)
        {
            return await _financialDataRepository.SearchSchoolsByCriteriaAsync(criteria, estType, excludePartial, excludeFeds);
        }

        public async Task<List<SchoolTrustFinancialDataObject>> SearchTrustsByCriteriaAsync(BenchmarkCriteria criteria)
        {
            return await _financialDataRepository.SearchTrustsByCriteriaAsync(criteria);
        }

        public async Task<int> SearchSchoolsCountByCriteriaAsync(BenchmarkCriteria criteria, EstablishmentType estType, bool excludePartial = false)
        {
            return await _financialDataRepository.SearchSchoolsCountByCriteriaAsync(criteria, estType, excludePartial);
        }

        public async Task<int> SearchTrustCountByCriteriaAsync(BenchmarkCriteria criteria)
        {
            return await _financialDataRepository.SearchTrustCountByCriteriaAsync(criteria);
        }

        public async Task<int> GetEstablishmentRecordCountAsync(string term, EstablishmentType estType)
        {
            return await _financialDataRepository.GetEstablishmentRecordCountAsync(term, estType);
        }

        public async Task<List<AcademySummaryDataObject>> GetAcademiesByCompanyNumberAsync(string term, int companyNo)
        {
            return await _financialDataRepository.GetAcademiesContextualDataObjectAsync(term, companyNo);
        }

        public async Task<List<FinancialDataModel>> GetFinancialDataForSchoolsAsync(List<SchoolSearchModel> schools, CentralFinancingType centralFinancing = CentralFinancingType.Include)
        {
            var models = new List<FinancialDataModel>();

            var taskList = new List<Task<SchoolTrustFinancialDataObject>>();
            foreach (var school in schools)
            {
                var estabType = (EstablishmentType)Enum.Parse(typeof(EstablishmentType), school.EstabType);
                var latestYear = await this.GetLatestDataYearPerEstabTypeAsync(estabType);
                var term = SchoolFormatHelpers.FinancialTermFormatAcademies(latestYear);

                var task = this.GetSchoolFinancialDataObjectAsync(long.Parse(school.Urn), term, estabType, centralFinancing);
                taskList.Add(task);
            }

            for (var i = 0; i < schools.Count; i++)
            {
                var estabType = (EstablishmentType)Enum.Parse(typeof(EstablishmentType), schools[i].EstabType);
                var latestYear = await this.GetLatestDataYearPerEstabTypeAsync(estabType);
                var term = SchoolFormatHelpers.FinancialTermFormatAcademies(latestYear);
                var resultDocument = await taskList[i];

                if (estabType == EstablishmentType.Academies && centralFinancing == CentralFinancingType.Include && resultDocument == null)//if nothing found in -Allocs collection try to source it from (non-allocated) Academies data
                {
                    resultDocument = (await this.GetSchoolFinancialDataObjectAsync(long.Parse(schools[i].Urn), term, estabType, CentralFinancingType.Exclude));
                }

                if (resultDocument != null && resultDocument.DidNotSubmit)//School did not submit finance, return & display "no data" in the charts
                {
                    resultDocument = null;
                }

                models.Add(new FinancialDataModel(schools[i].Urn, term, resultDocument, (EstablishmentType)Enum.Parse(typeof(EstablishmentType), schools[i].EstabType)));
            }

            return models;
        }

        public async Task<SchoolTrustFinancialDataObject> GetTrustFinancialDataObjectByCompanyNoAsync(int companyNo, string term, MatFinancingType matFinance)
        {
            return await _financialDataRepository.GetTrustFinancialDataObjectbyCompanyNoAsync(companyNo, term, matFinance);
        }

        public async Task<SchoolTrustFinancialDataObject> GetTrustFinancialDataObjectByUidAsync(int uid, string term)
        {
            return await _financialDataRepository.GetTrustFinancialDataObjectByUidAsync(uid, term, MatFinancingType.TrustOnly);
        }

        public async Task<SchoolTrustFinancialDataObject> GetFederationFinancialDataObjectByFuidAsync(long fuid, string term)
        {
            return await _financialDataRepository.GetFederationFinancialDataObjectByFuidAsync(fuid, term);
        }

        public async Task<List<int>> GetAllTrustCompanyNosAsync()
        {
            return await _financialDataRepository.GetAllTrustCompanyNos();
        }
    }
}
