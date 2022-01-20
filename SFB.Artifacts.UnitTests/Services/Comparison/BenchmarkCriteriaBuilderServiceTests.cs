using NUnit.Framework;
using SFB.Web.ApplicationCore.Entities;
using SFB.Web.ApplicationCore.Helpers.Enums;
using SFB.Web.ApplicationCore.Models;
using SFB.Web.ApplicationCore.Services.Comparison;

namespace SFB.Web.UnitTests.Services.Comparison
{
    public class BenchmarkCriteriaBuilderServiceTests
    {
        [Test]
        public void BuildFromBicComparisonCriteriaShouldReturnBMCriteria()
        {
            var service = new BenchmarkCriteriaBuilderService();

            var dummyFinancialDataModel = new FinancialDataModel("1", "2020/2021", new SchoolTrustFinancialDataObject(), EstablishmentType.Academies);
            var dummyBicCriteria = new BestInClassCriteria();
            var result = service.BuildFromBicComparisonCriteria(dummyFinancialDataModel, dummyBicCriteria);
            Assert.IsNotNull(result);
        }

        [Test]
        public void BuildFromBicComparisonCriteriaShouldKeepPupilNumbersPositive()
        {
            var service = new BenchmarkCriteriaBuilderService();

            var dummyFinancialDataModel = new FinancialDataModel("1", "2020/2021", new SchoolTrustFinancialDataObject(), EstablishmentType.Academies);
            var dummyBicCriteria = new BestInClassCriteria()
            {
                NoPupilsMin = 1,
                NoPupilsMax = 2,
                PercentageFSMMin = 1,
                PercentageFSMMax = 2,
                PerPupilExpMin = 1,
                PerPupilExpMax = 2,
                PercentageSENMin = 1,
                PercentageSENMax = 2
            };
            var result = service.BuildFromBicComparisonCriteria(dummyFinancialDataModel, dummyBicCriteria, 15);
            Assert.GreaterOrEqual(result.MinNoPupil, 0);
            Assert.GreaterOrEqual(result.MaxNoPupil, 0);
        }

        [Test]
        public void BuildFromBicComparisonCriteriaShouldKeepPercentLimits()
        {
            var service = new BenchmarkCriteriaBuilderService();

            var dummyFinancialDataModel = new FinancialDataModel("1", "2020/2021", new SchoolTrustFinancialDataObject(), EstablishmentType.Academies);
            var dummyBicCriteria = new BestInClassCriteria()
            {
                NoPupilsMin = 1,
                NoPupilsMax = 2,
                PercentageFSMMin = 1,
                PercentageFSMMax = 100,
                PerPupilExpMin = 1,
                PerPupilExpMax = 2,
                PercentageSENMin = 1,
                PercentageSENMax = 100
            };
            var result = service.BuildFromBicComparisonCriteria(dummyFinancialDataModel, dummyBicCriteria, 15);
            Assert.GreaterOrEqual(result.MinPerFSM, 0);
            Assert.LessOrEqual(result.MaxPerFSM, 100);             
        }

        [Test]
        public void BuildFromBicComparisonCriteriaShouldSetSchoolPhaseforAllThrough ()
        {
            var service = new BenchmarkCriteriaBuilderService();

            var dummyFinancialDataModel = new FinancialDataModel("1", "2020/2021", new SchoolTrustFinancialDataObject(), EstablishmentType.Academies);
            var dummyBicCriteria = new BestInClassCriteria()
            {
                NoPupilsMin = 1,
                NoPupilsMax = 2,
                PercentageFSMMin = 1,
                PercentageFSMMax = 100,
                PerPupilExpMin = 1,
                PerPupilExpMax = 2,
                PercentageSENMin = 1,
                PercentageSENMax = 100,
                OverallPhase = "All-through"
            };

            var result = service.BuildFromBicComparisonCriteria(dummyFinancialDataModel, dummyBicCriteria, 15);
            Assert.AreEqual(result.SchoolPhase[0], "All-through");
        }
    }
}
