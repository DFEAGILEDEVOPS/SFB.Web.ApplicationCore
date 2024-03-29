﻿using System;
using System.Linq;
using System.Threading.Tasks;
using SFB.Web.ApplicationCore.Helpers.Constants;
using SFB.Web.ApplicationCore.Models;
using SFB.Web.ApplicationCore.Services.DataAccess;
using SFB.Web.ApplicationCore.Helpers.Enums;
using SFB.Web.ApplicationCore.Entities;

namespace SFB.Web.ApplicationCore.Services.Comparison
{
    public class ComparisonService : IComparisonService
    {
        private readonly IFinancialDataService _financialDataService;
        private readonly IBenchmarkCriteriaBuilderService _benchmarkCriteriaBuilderService;

        public ComparisonService(IFinancialDataService financialDataService, IBenchmarkCriteriaBuilderService benchmarkCriteriaBuilderService)
        {
            _financialDataService = financialDataService;
            _benchmarkCriteriaBuilderService = benchmarkCriteriaBuilderService;
        }

        public async Task<ComparisonResult> GenerateBenchmarkListWithAdvancedComparisonAsync(BenchmarkCriteria criteria, 
            EstablishmentType estType, int basketSize = ComparisonListLimit.LIMIT)
        {
            return await GenerateBenchmarkListWithAdvancedComparisonAsync(criteria, estType, false, basketSize);
        }

        public async Task<ComparisonResult> GenerateBenchmarkListWithAdvancedComparisonAsync(BenchmarkCriteria criteria, EstablishmentType estType,
            bool excludePartial, int basketSize = ComparisonListLimit.LIMIT)
        {
            var benchmarkSchools = await _financialDataService.SearchSchoolsByCriteriaAsync(criteria, estType, excludePartial);            
            return new ComparisonResult()
            {
                BenchmarkSchools = benchmarkSchools,
                BenchmarkCriteria = criteria
            };
        }

        public async Task<ComparisonResult> GenerateBenchmarkListWithBestInClassComparisonAsync(EstablishmentType estType, 
            BenchmarkCriteria benchmarkCriteria, BestInClassCriteria bicCriteria,
            FinancialDataModel defaultSchoolFinancialDataModel)
        {
            //STEP 1: Straight search with prefilled criteria
            var benchmarkSchools = await _financialDataService.SearchSchoolsByCriteriaAsync(benchmarkCriteria, estType, true);

            if (benchmarkSchools.Count > CriteriaSearchConfig.BIC_TARGET_POOL_COUNT) //Original query returns more than required. Clip from top by per people expenditure proximity.
            {
                benchmarkSchools = benchmarkSchools.OrderBy(b => Math.Abs(b.PerPupilTotalExpenditure.GetValueOrDefault() - defaultSchoolFinancialDataModel.PerPupilTotalExpenditure.GetValueOrDefault()))
                    .Take(CriteriaSearchConfig.BIC_TARGET_POOL_COUNT).ToList();
            }

            //STEP 2: Original query returns less than required. Expand criteria values gradually and try this max 15 times
            var tryCount = 0;
            while (benchmarkSchools.Count < CriteriaSearchConfig.BIC_TARGET_POOL_COUNT)
            {
                if (++tryCount > CriteriaSearchConfig.MAX_BIC_TRY_LIMIT) //Max query try reached. Return whatever is found.
                {
                    break;
                }

                benchmarkCriteria = _benchmarkCriteriaBuilderService.BuildFromBicComparisonCriteria(defaultSchoolFinancialDataModel, bicCriteria, tryCount);

                benchmarkSchools = await _financialDataService.SearchSchoolsByCriteriaAsync(benchmarkCriteria, estType, true);

                if (benchmarkSchools.Count > CriteriaSearchConfig.BIC_TARGET_POOL_COUNT) //Number jumping to more than ideal. Clip from top by per people expenditure proximity.
                {
                    benchmarkSchools = benchmarkSchools.OrderBy(b => Math.Abs(b.PerPupilTotalExpenditure.GetValueOrDefault() - defaultSchoolFinancialDataModel.PerPupilTotalExpenditure.GetValueOrDefault()))
                        .Take(CriteriaSearchConfig.BIC_TARGET_POOL_COUNT).ToList();
                    break;
                }
            }

            //STEP 3: Further reduce pool of 50 (or less) to target 15 by highest progress measure
            if (benchmarkSchools.Count > ComparisonListLimit.BIC)
            {
                benchmarkSchools = benchmarkSchools
                    .OrderByDescending(b => b.OverallPhase == "Secondary" || b.OverallPhase == "All-through" ? b.Progress8Measure : b.Ks2Progress)
                    .Take(ComparisonListLimit.BIC)
                    .ToList();
            }

            return new ComparisonResult()
            {
                BenchmarkSchools = benchmarkSchools,
                BenchmarkCriteria = benchmarkCriteria
            };
        }

        public async Task<ComparisonResult> GenerateBenchmarkListWithSpecialComparisonAsync(BenchmarkCriteria benchmarkCriteria, SpecialCriteria specialCriteria, FinancialDataModel defaultSchoolFinancialDataModel)
        {
            //STEP 1: Straight search with prefilled criteria
            var benchmarkSchools = await _financialDataService.SearchSchoolsByCriteriaAsync(benchmarkCriteria, EstablishmentType.All, true);

            if (benchmarkSchools.Count > ComparisonListLimit.SPECIALS) //Original query returns more than required. Clip to closest schools to the top SEN criteria.
            {
                var highestSENName = specialCriteria.TopSenCriteria[0].DataName;
                var highestSENValue = specialCriteria.TopSenCriteria[0].Original.GetValueOrDefault();

                benchmarkSchools = benchmarkSchools.OrderBy(b => Math.Abs(b.getValueByCriteriaName(highestSENName).GetValueOrDefault() - highestSENValue)).Take(ComparisonListLimit.SPECIALS).ToList();
                //Updating the criteria to reflect the final min and max used values used on top SEN
                var minValue = benchmarkSchools.Min(s => s.getValueByCriteriaName(highestSENName));
                var maxValue = benchmarkSchools.Max(s => s.getValueByCriteriaName(highestSENName));
                benchmarkCriteria.FindAndSetMaxMinSenInCriteria(highestSENName, minValue, maxValue);
            }

            //STEP 2: Original query returns less than required. Expand criteria values gradually and try this max 10 times
            var tryCount = 0;
            while (benchmarkSchools.Count < ComparisonListLimit.SPECIALS)
            {
                if (++tryCount > CriteriaSearchConfig.MAX_TRY_LIMIT) //Max query try reached. Return whatever is found.
                {
                    break;
                }

                benchmarkCriteria = _benchmarkCriteriaBuilderService.BuildFromSpecialComparisonCriteria(defaultSchoolFinancialDataModel, specialCriteria, tryCount);

                benchmarkSchools = await _financialDataService.SearchSchoolsByCriteriaAsync(benchmarkCriteria, EstablishmentType.All, true);

                if (benchmarkSchools.Count > ComparisonListLimit.SPECIALS) //Number jumping to more than ideal. Clip to closest schools to the top SEN criteria.
                {
                    var highestSENName = specialCriteria.TopSenCriteria[0].DataName;
                    var highestSENValue = specialCriteria.TopSenCriteria[0].Original.GetValueOrDefault();

                    benchmarkSchools = benchmarkSchools.OrderBy(b => Math.Abs(b.getValueByCriteriaName(highestSENName).GetValueOrDefault() - highestSENValue)).Take(ComparisonListLimit.SPECIALS).ToList();
                    //Updating the criteria to reflect the final min and max used values used on top SEN
                    var minValue = benchmarkSchools.Min(s => s.getValueByCriteriaName(highestSENName));
                    var maxValue = benchmarkSchools.Max(s => s.getValueByCriteriaName(highestSENName));
                    benchmarkCriteria.FindAndSetMaxMinSenInCriteria(highestSENName, minValue, maxValue); break;
                }
            }

            return new ComparisonResult()
            {
                BenchmarkSchools = benchmarkSchools,
                BenchmarkCriteria = benchmarkCriteria
            };
        }

        public async Task<ComparisonResult> GenerateBenchmarkListWithSimpleComparisonAsync(
            BenchmarkCriteria benchmarkCriteria, 
            EstablishmentType estType,
            int basketSize,
            SimpleCriteria simpleCriteria, 
            FinancialDataModel defaultSchoolFinancialDataModel,
            bool excludeFeds = true)
        {
            //STEP 1: Straight search with predefined criteria
            var benchmarkSchools = await _financialDataService.SearchSchoolsByCriteriaAsync(benchmarkCriteria, estType, false, excludeFeds);

            if (benchmarkSchools.Count > basketSize) //Original query returns more than required. Clip from top by people count proximity.
            {
                benchmarkSchools = benchmarkSchools.OrderBy(b => Math.Abs(b.NoPupils.GetValueOrDefault() - defaultSchoolFinancialDataModel.PupilCount.GetValueOrDefault())).Take(basketSize).ToList();
                benchmarkCriteria.MinNoPupil = benchmarkSchools.Min(s => s.NoPupils);
                benchmarkCriteria.MaxNoPupil = benchmarkSchools.Max(s => s.NoPupils); //Update the used criteria to reflect the max and min pupil count of the found schools
            }

            //STEP 2: Original query returns less than required. Expand criteria values gradually and try this max 10 times
            var tryCount = 0;
            while (benchmarkSchools.Count < basketSize)
            {
                if (++tryCount > CriteriaSearchConfig.MAX_TRY_LIMIT) //Max query try reached. Return whatever is found.
                {
                    break;
                }

                benchmarkCriteria = _benchmarkCriteriaBuilderService.BuildFromSimpleComparisonCriteria(defaultSchoolFinancialDataModel, simpleCriteria, tryCount);

                benchmarkSchools = await _financialDataService.SearchSchoolsByCriteriaAsync(benchmarkCriteria, estType, false, excludeFeds);

                if (benchmarkSchools.Count > basketSize) //Number jumping to more than ideal. Cut from top by proximity.
                {
                    benchmarkSchools = benchmarkSchools.OrderBy(b => Math.Abs(b.NoPupils.GetValueOrDefault() - defaultSchoolFinancialDataModel.PupilCount.GetValueOrDefault())).Take(basketSize).ToList();
                    benchmarkCriteria.MinNoPupil = benchmarkSchools.Min(s => s.NoPupils);
                    benchmarkCriteria.MaxNoPupil = benchmarkSchools.Max(s => s.NoPupils); //Update the criteria to reflect the max and min pupil count of the found schools
                    break;
                }
            }
                        
            //STEP 3: Expansion query returns less than required. Expand criteria values further gradually and try this max 10 times
            tryCount = 0;
            while (benchmarkSchools.Count < basketSize)
            {
                if (++tryCount > CriteriaSearchConfig.MAX_TRY_LIMIT) //Max query try reached. Return whatever is found.
                {
                    break;
                }

                benchmarkCriteria = _benchmarkCriteriaBuilderService.BuildFromSimpleComparisonCriteriaExtended(defaultSchoolFinancialDataModel, simpleCriteria, tryCount);

                benchmarkSchools = await _financialDataService.SearchSchoolsByCriteriaAsync(benchmarkCriteria, estType, false, excludeFeds);
                
                if (benchmarkSchools.Count() < basketSize) 
                {
                    benchmarkCriteria.MinNoPupil = (defaultSchoolFinancialDataModel.PupilCount / 100 * 50);
                    benchmarkCriteria.MaxNoPupil = (defaultSchoolFinancialDataModel.PupilCount / 100 * 150);
                    benchmarkSchools = await _financialDataService.SearchSchoolsByCriteriaAsync(benchmarkCriteria, estType, false, excludeFeds);
                }


                if (benchmarkSchools.Count > basketSize) //Number jumping to more than ideal. Cut from top by proximity.
                {
                    benchmarkSchools = benchmarkSchools.OrderBy(b => Math.Abs(b.NoPupils.GetValueOrDefault() - defaultSchoolFinancialDataModel.PupilCount.GetValueOrDefault())).Take(basketSize).ToList();
                    benchmarkCriteria.MinNoPupil = benchmarkSchools.Min(s => s.NoPupils);
                    benchmarkCriteria.MaxNoPupil = benchmarkSchools.Max(s => s.NoPupils); //Update the criteria to reflect the max and min pupil count of the found schools
                    break;
                }
            }


            //STEP 4: Query return is still less than required. Flex the Urban/Rural criteria gradually. Not applied to federations.
            if (defaultSchoolFinancialDataModel.EstabType != EstablishmentType.Federation)
            {
                tryCount = 1;
                while (benchmarkSchools.Count < basketSize)
                {
                    var urbanRuralDefault = defaultSchoolFinancialDataModel.UrbanRural;
                    var urbanRuralKey = Dictionaries.UrbanRuralDictionary.First(d => d.Value == urbanRuralDefault).Key;

                    var urbanRuralQuery = Dictionaries.UrbanRuralDictionary.Where(d =>
                        d.Key >= urbanRuralKey - tryCount && d.Key <= urbanRuralKey + tryCount).Select(d => d.Value).ToArray();

                    benchmarkCriteria.UrbanRural = urbanRuralQuery;

                    benchmarkSchools = await _financialDataService.SearchSchoolsByCriteriaAsync(benchmarkCriteria, estType, false, excludeFeds);

                    if (benchmarkSchools.Count > basketSize) //Number jumping to more than ideal. Cut from top by pupil count proximity.
                    {
                        benchmarkSchools = benchmarkSchools.OrderBy(b => Math.Abs(b.NoPupils.GetValueOrDefault() - defaultSchoolFinancialDataModel.PupilCount.GetValueOrDefault())).Take(basketSize).ToList();
                        benchmarkCriteria.MinNoPupil = benchmarkSchools.Min(s => s.NoPupils);
                        benchmarkCriteria.MaxNoPupil = benchmarkSchools.Max(s => s.NoPupils); //Update the criteria to reflect the max and min pupil count of the found schools
                        break;
                    }

                    if (urbanRuralQuery.Length == Dictionaries.UrbanRuralDictionary.Count)
                    {
                        break;
                    }

                    tryCount++;
                }
            }

            //STEP 5: For federations, eliminate the schools if both federation and its schools are found
            if (defaultSchoolFinancialDataModel.EstabType == EstablishmentType.Federation)
            {
                var fedSchools = benchmarkSchools.Where(school => !school.IsFederation && school.IsPartOfFederation && benchmarkSchools.Exists(fed => fed.IsFederation && fed.FederationUid == school.FederationUid));
                benchmarkSchools = benchmarkSchools.Except(fedSchools).ToList();
            }

            return new ComparisonResult()
            {
                BenchmarkSchools = benchmarkSchools,
                BenchmarkCriteria = benchmarkCriteria
            };
        }

        public async Task<ComparisonResult> GenerateBenchmarkListWithOneClickComparisonAsync(BenchmarkCriteria benchmarkCriteria, EstablishmentType estType,
            int basketSize, FinancialDataModel defaultSchoolFinancialDataModel)
        {
            //STEP 1: Straight search with predefined criteria
            var benchmarkSchools = await _financialDataService.SearchSchoolsByCriteriaAsync(benchmarkCriteria, estType);

            if (benchmarkSchools.Count > basketSize) //Original query returns more than required. Clip from top by people count proximity.
            {
                benchmarkSchools = benchmarkSchools.OrderBy(b => Math.Abs(b.NoPupils.GetValueOrDefault() - defaultSchoolFinancialDataModel.PupilCount.GetValueOrDefault())).Take(basketSize).ToList();
                benchmarkCriteria.MinNoPupil = benchmarkSchools.Min(s => s.NoPupils);
                benchmarkCriteria.MaxNoPupil = benchmarkSchools.Max(s => s.NoPupils); //Update the used criteria to reflect the max and min pupil count of the found schools
            }

            //STEP 2: Original query returns less than required. Expand criteria values gradually and try this max 10 times
            var tryCount = 0;
            while (benchmarkSchools.Count < basketSize)
            {
                if (++tryCount > CriteriaSearchConfig.MAX_TRY_LIMIT) //Max query try reached. Return whatever is found.
                {
                    break;
                }

                benchmarkCriteria = _benchmarkCriteriaBuilderService.BuildFromOneClickComparisonCriteria(defaultSchoolFinancialDataModel, tryCount);

                benchmarkSchools = await _financialDataService.SearchSchoolsByCriteriaAsync(benchmarkCriteria, estType);

                if (benchmarkSchools.Count > basketSize) //Number jumping to more than ideal. Cut from top by pupil count proximity.
                {
                    benchmarkSchools = benchmarkSchools.OrderBy(b => Math.Abs(b.NoPupils.GetValueOrDefault() - defaultSchoolFinancialDataModel.PupilCount.GetValueOrDefault())).Take(basketSize).ToList();
                    benchmarkCriteria.MinNoPupil = benchmarkSchools.Min(s => s.NoPupils);
                    benchmarkCriteria.MaxNoPupil = benchmarkSchools.Max(s => s.NoPupils); //Update the criteria to reflect the max and min pupil count of the found schools
                    break;
                }
            }

            //STEP 3: Query return is still less than required. Flex the Urban/Rural criteria gradually.
            tryCount = 1;
            while (benchmarkSchools.Count < basketSize)
            {
                var urbanRuralDefault = defaultSchoolFinancialDataModel.UrbanRural;
                var urbanRuralKey = Dictionaries.UrbanRuralDictionary.First(d => d.Value == urbanRuralDefault).Key;

                var urbanRuralQuery = Dictionaries.UrbanRuralDictionary.Where(d =>
                    d.Key >= urbanRuralKey - tryCount && d.Key <= urbanRuralKey + tryCount).Select(d => d.Value).ToArray();

                benchmarkCriteria.UrbanRural = urbanRuralQuery;

                benchmarkSchools = await _financialDataService.SearchSchoolsByCriteriaAsync(benchmarkCriteria, estType);

                if (benchmarkSchools.Count > basketSize) //Number jumping to more than ideal. Cut from top by pupil count proximity.
                {
                    benchmarkSchools = benchmarkSchools.OrderBy(b => Math.Abs(b.NoPupils.GetValueOrDefault() - defaultSchoolFinancialDataModel.PupilCount.GetValueOrDefault())).Take(basketSize).ToList();
                    benchmarkCriteria.MinNoPupil = benchmarkSchools.Min(s => s.NoPupils);
                    benchmarkCriteria.MaxNoPupil = benchmarkSchools.Max(s => s.NoPupils); //Update the criteria to reflect the max and min pupil count of the found schools
                    break;
                }

                if (urbanRuralQuery.Length == Dictionaries.UrbanRuralDictionary.Count)
                {
                    break;
                }

                tryCount++;
            }

            return new ComparisonResult()
            {
                BenchmarkSchools = benchmarkSchools,
                BenchmarkCriteria = benchmarkCriteria
            };
        }

    }
}