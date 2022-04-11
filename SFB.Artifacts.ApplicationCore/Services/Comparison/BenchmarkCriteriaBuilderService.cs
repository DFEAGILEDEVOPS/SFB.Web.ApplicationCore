using SFB.Web.ApplicationCore.Attributes;
using SFB.Web.ApplicationCore.Helpers.Constants;
using SFB.Web.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SFB.Web.ApplicationCore.Services.Comparison
{
    public class BenchmarkCriteriaBuilderService : IBenchmarkCriteriaBuilderService
    {
        public BenchmarkCriteria BuildFromBicComparisonCriteria(FinancialDataModel benchmarkSchoolData, BestInClassCriteria bicCriteria, int percentageMargin = 0)
        {
            var bmCriteria = new BenchmarkCriteria()
            {
                SchoolOverallPhase = new[] { bicCriteria.OverallPhase },
                SchoolPhase = CriteriaSearchConfig.BIC_ALLOWED_PHASES,
                MinKs2Progress = bicCriteria.Ks2ProgressScoreMin,
                MaxKs2Progress = bicCriteria.Ks2ProgressScoreMax,
                MinP8Mea = bicCriteria.Ks4ProgressScoreMin,
                MaxP8Mea = bicCriteria.Ks4ProgressScoreMax,
                MinRRToIncome = bicCriteria.RRPerIncomeMin,
                MinNoPupil = WithinPositiveLimits(bicCriteria.NoPupilsMin - (bicCriteria.NoPupilsMin * percentageMargin / 100)),
                MaxNoPupil = bicCriteria.NoPupilsMax + (bicCriteria.NoPupilsMax * percentageMargin / 100),
                MinPerPupilExp = bicCriteria.PerPupilExpMin,
                MaxPerPupilExp = bicCriteria.PerPupilExpMax + (bicCriteria.PerPupilExpMax * percentageMargin / 100),
                MinPerFSM = WithinPercentLimits(bicCriteria.PercentageFSMMin - (bicCriteria.PercentageFSMMin * percentageMargin / 100)),
                MaxPerFSM = WithinPercentLimits(bicCriteria.PercentageFSMMax + (bicCriteria.PercentageFSMMax * percentageMargin / 100)),
                LondonWeighting = bicCriteria.LondonWeighting
            };

            if(bicCriteria.OverallPhase == "All-through")
            {
                bmCriteria.SchoolPhase = new[] { "All-through" };
            }

            if (bicCriteria.SENEnabled)
            {
                bmCriteria.MinPerSEN = WithinPercentLimits(bicCriteria.PercentageSENMin - (bicCriteria.PercentageSENMin * percentageMargin / 100));
                bmCriteria.MaxPerSEN = WithinPercentLimits(bicCriteria.PercentageSENMax + (bicCriteria.PercentageSENMax * percentageMargin / 100));
            }

            if(bicCriteria.UREnabled)
            {
                bmCriteria.UrbanRural = new[] { bicCriteria.UrbanRural };
            }

            return bmCriteria;
        }

        public BenchmarkCriteria BuildFromOneClickComparisonCriteria(FinancialDataModel benchmarkSchoolData, int percentageMargin = 0)
        {
            var criteria = new BenchmarkCriteria();

            criteria.SchoolOverallPhase = new[] { benchmarkSchoolData.SchoolOverallPhase };
            criteria.UrbanRural = new[] { benchmarkSchoolData.UrbanRural };

            var minPcMarginFactor = 1 - ((percentageMargin + CriteriaSearchConfig.PC_DEFAULT_MARGIN) / 100m);
            var maxPcMarginFactor = 1 + ((percentageMargin + CriteriaSearchConfig.PC_DEFAULT_MARGIN) / 100m);

            criteria.MinNoPupil = WithinPositiveLimits(benchmarkSchoolData.PupilCount - CriteriaSearchConfig.QC_DEFAULT_CONSTANT_PUPIL_COUNT_TOPUP) * minPcMarginFactor;
            criteria.MaxNoPupil = (benchmarkSchoolData.PupilCount + CriteriaSearchConfig.QC_DEFAULT_CONSTANT_PUPIL_COUNT_TOPUP) * maxPcMarginFactor;

            var fsm = benchmarkSchoolData.PercentageOfEligibleFreeSchoolMeals;
            criteria.MinPerFSM = WithinPercentLimits(fsm - percentageMargin);
            criteria.MaxPerFSM = WithinPercentLimits(fsm + percentageMargin);

            var sen = benchmarkSchoolData.PercentageOfPupilsWithSen;
            criteria.MinPerSEN = WithinPercentLimits(sen - percentageMargin);
            criteria.MaxPerSEN = WithinPercentLimits(sen + percentageMargin);

            var eal = benchmarkSchoolData.PercentageOfPupilsWithEal;
            criteria.MinPerEAL = WithinPercentLimits(eal - percentageMargin);
            criteria.MaxPerEAL = WithinPercentLimits(eal + percentageMargin);

            var ppGrantFunding = benchmarkSchoolData.PerPupilGrantFunding;
            var minGfMarginFactor = 1 - ((percentageMargin + CriteriaSearchConfig.GF_DEFAULT_MARGIN) / 100m);
            var maxGfMarginFactor = 1 + ((percentageMargin + CriteriaSearchConfig.GF_DEFAULT_MARGIN) / 100m);
            criteria.MinPerPupilGrantFunding = ppGrantFunding * minGfMarginFactor;
            criteria.MaxPerPupilGrantFunding = ppGrantFunding * maxGfMarginFactor;

            criteria.LondonWeighting = benchmarkSchoolData.LondonWeighting == "Neither" ? new[] { "Neither" } : new[] { "Inner", "Outer" };

            criteria.PeriodCoveredByReturn = 12;

            return criteria;
        }

        public BenchmarkCriteria BuildFromSimpleComparisonCriteria(FinancialDataModel benchmarkSchoolData, SimpleCriteria simpleCriteria, int percentageMargin = 0)
        {
            return BuildFromSimpleComparisonCriteria(benchmarkSchoolData, simpleCriteria.IncludeFsm.GetValueOrDefault(),
                simpleCriteria.IncludeSen.GetValueOrDefault(), simpleCriteria.IncludeEal.GetValueOrDefault(),
                simpleCriteria.IncludeLa.GetValueOrDefault(), percentageMargin);
        }

        public BenchmarkCriteria BuildFromSimpleComparisonCriteriaExtended(FinancialDataModel benchmarkSchoolData, SimpleCriteria simpleCriteria, int percentageMargin = 0)
        {
            return BuildFromSimpleComparisonCriteriaByFsmSenEalWeight(benchmarkSchoolData, simpleCriteria.IncludeFsm.GetValueOrDefault(),
                simpleCriteria.IncludeSen.GetValueOrDefault(), simpleCriteria.IncludeEal.GetValueOrDefault(),
                simpleCriteria.IncludeLa.GetValueOrDefault(), percentageMargin);
        }

        public BenchmarkCriteria BuildFromSimpleComparisonCriteria(FinancialDataModel benchmarkSchoolData, bool includeFsm, bool includeSen, bool includeEal, bool includeLa, int percentageMargin = 0) 
        {
            var criteria = new BenchmarkCriteria();

            criteria.SchoolOverallPhase = new []{ benchmarkSchoolData.SchoolOverallPhase};
            
            if (benchmarkSchoolData.UrbanRural != null)
            {
                criteria.UrbanRural = new[] { benchmarkSchoolData.UrbanRural };
            }

            var minMarginFactor = 1 - ((percentageMargin + CriteriaSearchConfig.PC_DEFAULT_MARGIN) / 100m);
            var maxMarginFactor = 1 + ((percentageMargin + CriteriaSearchConfig.PC_DEFAULT_MARGIN) / 100m);
            
            criteria.MinNoPupil = WithinPositiveLimits(benchmarkSchoolData.PupilCount - CriteriaSearchConfig.QC_DEFAULT_CONSTANT_PUPIL_COUNT_TOPUP) * minMarginFactor;
            criteria.MaxNoPupil = (benchmarkSchoolData.PupilCount + CriteriaSearchConfig.QC_DEFAULT_CONSTANT_PUPIL_COUNT_TOPUP) * maxMarginFactor;

            if(includeFsm)
            {
                var fsm = benchmarkSchoolData.PercentageOfEligibleFreeSchoolMeals;
                criteria.MinPerFSM =  WithinPercentLimits(fsm - percentageMargin);
                criteria.MaxPerFSM = WithinPercentLimits(fsm + percentageMargin);
            }

            if(includeSen)
            {
                var sen = benchmarkSchoolData.PercentageOfPupilsWithSen;
                criteria.MinPerSEN =  WithinPercentLimits(sen - percentageMargin);
                criteria.MaxPerSEN = WithinPercentLimits(sen + percentageMargin);
            }

            if(includeEal)
            {
                var eal = benchmarkSchoolData.PercentageOfPupilsWithEal;
                criteria.MinPerEAL = WithinPercentLimits(eal - percentageMargin);
                criteria.MaxPerEAL = WithinPercentLimits(eal + percentageMargin);
            }

            if(includeLa)
            {
                criteria.LocalAuthorityCode = benchmarkSchoolData.LaNumber;
            }

            criteria.PeriodCoveredByReturn = 12;

            return criteria;
        }

        public BenchmarkCriteria BuildFromSimpleComparisonCriteriaByFsmSenEalWeight(FinancialDataModel benchmarkSchoolData, bool includeFsm, bool includeSen, bool includeEal, bool includeLa, int percentageMargin = 0)
        {
            var criteria = new BenchmarkCriteria();

            criteria.SchoolOverallPhase = new[] { benchmarkSchoolData.SchoolOverallPhase };

            if (benchmarkSchoolData.UrbanRural != null)
            {
                criteria.UrbanRural = new[] { benchmarkSchoolData.UrbanRural };
            }

            var minMarginFactor = 1 - ((percentageMargin + CriteriaSearchConfig.PC_DEFAULT_MARGIN) / 100m);
            var maxMarginFactor = 1 + ((percentageMargin + CriteriaSearchConfig.PC_DEFAULT_MARGIN) / 100m);

            criteria.MinNoPupil = WithinPositiveLimits(benchmarkSchoolData.PupilCount - CriteriaSearchConfig.QC_DEFAULT_CONSTANT_PUPIL_COUNT_TOPUP) * minMarginFactor;
            criteria.MaxNoPupil = (benchmarkSchoolData.PupilCount + CriteriaSearchConfig.QC_DEFAULT_CONSTANT_PUPIL_COUNT_TOPUP) * maxMarginFactor;

            var fsmSenEalListOrdered = BuildFsmSenEalOrdered();

            if (includeFsm)
            {
                var fsmFactor = CalculateFactorBasedOnFsmSenEalOrder(fsmSenEalListOrdered, benchmarkSchoolData.PercentageOfEligibleFreeSchoolMeals);
                criteria.MinPerFSM = WithinPercentLimits(benchmarkSchoolData.PercentageOfEligibleFreeSchoolMeals - percentageMargin * fsmFactor);
                criteria.MaxPerFSM = WithinPercentLimits(benchmarkSchoolData.PercentageOfEligibleFreeSchoolMeals + percentageMargin * fsmFactor);
            }

            if (includeSen)
            {
                var senFactor = CalculateFactorBasedOnFsmSenEalOrder(fsmSenEalListOrdered, benchmarkSchoolData.PercentageOfPupilsWithSen);
                criteria.MinPerSEN = WithinPercentLimits(benchmarkSchoolData.PercentageOfPupilsWithSen - percentageMargin * senFactor);
                criteria.MaxPerSEN = WithinPercentLimits(benchmarkSchoolData.PercentageOfPupilsWithSen + percentageMargin * senFactor);
            }

            if (includeEal)
            {
                var ealFactor = CalculateFactorBasedOnFsmSenEalOrder(fsmSenEalListOrdered, benchmarkSchoolData.PercentageOfPupilsWithEal);
                criteria.MinPerEAL = WithinPercentLimits(benchmarkSchoolData.PercentageOfPupilsWithEal - percentageMargin * ealFactor);
                criteria.MaxPerEAL = WithinPercentLimits(benchmarkSchoolData.PercentageOfPupilsWithEal + percentageMargin * ealFactor);
            }

            if (includeLa)
            {
                criteria.LocalAuthorityCode = benchmarkSchoolData.LaNumber;
            }

            criteria.PeriodCoveredByReturn = 12;

            return criteria;

            List<decimal?> BuildFsmSenEalOrdered()
            {
                return new List<decimal?> {
                    includeFsm ? benchmarkSchoolData.PercentageOfEligibleFreeSchoolMeals : -1,
                    includeSen ? benchmarkSchoolData.PercentageOfPupilsWithSen : -1,
                    includeEal ? benchmarkSchoolData.PercentageOfPupilsWithEal : -1
                }.OrderBy(y => y).ToList();
            }

            decimal CalculateFactorBasedOnFsmSenEalOrder(List<decimal?> orderedFsmSenEalList, decimal? param)
            {
                return orderedFsmSenEalList.Where(x => x == param).Select(x => 1m + orderedFsmSenEalList.IndexOf(param) * 0.5m).FirstOrDefault();
            }
        }

        public BenchmarkCriteria BuildFromSpecialComparisonCriteria(FinancialDataModel benchmarkSchoolData, SpecialCriteria specialCriteria, int tryCount = 0)
        {
            var criteria = new BenchmarkCriteria();

            criteria.SchoolOverallPhase = new[] { "Special"};
 
            if (specialCriteria.SimilarPupils.GetValueOrDefault())
            {
                criteria.MinLowestAgePupils = benchmarkSchoolData.LowestAgePupils - CriteriaSearchConfig.SPECIALS_AGE_EXP_RANGE;
                criteria.MaxLowestAgePupils = benchmarkSchoolData.LowestAgePupils + CriteriaSearchConfig.SPECIALS_AGE_EXP_RANGE;
                criteria.MinHighestAgePupils = benchmarkSchoolData.HighestAgePupils - CriteriaSearchConfig.SPECIALS_AGE_EXP_RANGE;
                criteria.MaxHighestAgePupils = benchmarkSchoolData.HighestAgePupils + CriteriaSearchConfig.SPECIALS_AGE_EXP_RANGE;                
            }


            foreach (var sen in specialCriteria.TopSenCriteria)
            {
                criteria.FindAndSetMaxMinSenInCriteria(sen, tryCount);
            }

            return criteria;
        }

        private decimal? WithinPercentLimits(decimal? percent)
        {
            if(percent > 100)
            {
                return 100;
            }
            if (percent < 0)
            {
                return 0;
            }
            else return percent;
        }

        private decimal? WithinPositiveLimits(decimal? value)
        {
            if (value < 0)
            {
                return 0;
            }
            else return value;
        }
    }

}