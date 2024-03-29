﻿using SFB.Web.ApplicationCore;
using SFB.Web.ApplicationCore.Models;

namespace SFB.Web.ApplicationCore.Services.Comparison
{
    public interface IBenchmarkCriteriaBuilderService
    {
        BenchmarkCriteria BuildFromSimpleComparisonCriteria(FinancialDataModel benchmarkSchoolData, SimpleCriteria simpleCriteria, int percentageMargin = 0);
        BenchmarkCriteria BuildFromSimpleComparisonCriteriaExtended(FinancialDataModel benchmarkSchoolData, SimpleCriteria simpleCriteria, int percentageMargin = 0);
        BenchmarkCriteria BuildFromSpecialComparisonCriteria(FinancialDataModel benchmarkSchoolData, SpecialCriteria specialCriteria, int percentageMargin = 0);
        BenchmarkCriteria BuildFromSimpleComparisonCriteria(FinancialDataModel benchmarkSchoolData, bool includeFsm, bool includeSen, bool includeEal, bool includeLa, int percentageMargin = 0);
        BenchmarkCriteria BuildFromBicComparisonCriteria(FinancialDataModel benchmarkSchoolData, BestInClassCriteria bicCriteria, int percentageMargin = 0);
        BenchmarkCriteria BuildFromOneClickComparisonCriteria(FinancialDataModel benchmarkSchoolData, int percentageMargin = 0);
    }
}
