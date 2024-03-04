using Moq;
using NUnit.Framework;
using SFB.Web.ApplicationCore.Entities;
using SFB.Web.ApplicationCore.Helpers.Enums;
using SFB.Web.ApplicationCore.Models;
using SFB.Web.ApplicationCore.Services.Comparison;
using SFB.Web.ApplicationCore.Services.DataAccess;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SFB.Web.UnitTests.Services.Comparison
{
    public class ComparisonServiceTests
    {

        [Test]
        public void GenerateBenchmarkListWithBestInClassComparisonAsyncShouldQueryOnlyOnceIfEnoughSchoolsFound()
        {
            var mockFinancialDataService = new Mock<IFinancialDataService>();
            var dummyResult = new SchoolTrustFinancialDataObject();

            Task<List<SchoolTrustFinancialDataObject>> SearchSchoolsByCriteriaAsyncTask = Task.Run(() =>
            {
                var list = new List<SchoolTrustFinancialDataObject>();
                for(int i=0; i<51; i++)
                {
                    list.Add(dummyResult);
                }

                return list;
            });
            mockFinancialDataService.Setup(m => m.SearchSchoolsByCriteriaAsync(It.IsAny<BenchmarkCriteria>(), It.IsAny<EstablishmentType>(), It.IsAny<bool>(), It.IsAny<bool>()))
            .Returns((BenchmarkCriteria criteria, EstablishmentType estType, bool excludePartial, bool excludeFeds) => SearchSchoolsByCriteriaAsyncTask);
            var mockBenchmarkCriteriaBuilderService = new Mock<IBenchmarkCriteriaBuilderService>();

            var service = new ComparisonService(mockFinancialDataService.Object, mockBenchmarkCriteriaBuilderService.Object);

            var task = service.GenerateBenchmarkListWithBestInClassComparisonAsync(EstablishmentType.Academies, new BenchmarkCriteria(), new BestInClassCriteria(), new FinancialDataModel());
            task.Wait();

            mockFinancialDataService.Verify(m => m.SearchSchoolsByCriteriaAsync(It.IsAny<BenchmarkCriteria>(), It.IsAny<EstablishmentType>(), It.IsAny<bool>(), It.IsAny<bool>()), Times.Once);
        }

        [Test]
        public void GenerateBenchmarkListWithBestInClassComparisonAsyncShouldQueryMax16TimesIfNotEnoughSchoolsFound()
        {
            var mockFinancialDataService = new Mock<IFinancialDataService>();
            var dummyResult = new SchoolTrustFinancialDataObject();

            Task<List<SchoolTrustFinancialDataObject>> SearchSchoolsByCriteriaAsyncTask = Task.Run(() =>
            {
                var list = new List<SchoolTrustFinancialDataObject>();
                for (int i = 0; i < 2; i++)
                {
                    list.Add(dummyResult);
                }

                return list;
            });
            mockFinancialDataService.Setup(m => m.SearchSchoolsByCriteriaAsync(It.IsAny<BenchmarkCriteria>(), It.IsAny<EstablishmentType>(), It.IsAny<bool>(), It.IsAny<bool>()))
            .Returns((BenchmarkCriteria criteria, EstablishmentType estType, bool excludePartial, bool excludeFeds) => SearchSchoolsByCriteriaAsyncTask);
            var mockBenchmarkCriteriaBuilderService = new Mock<IBenchmarkCriteriaBuilderService>();

            var service = new ComparisonService(mockFinancialDataService.Object, mockBenchmarkCriteriaBuilderService.Object);

            var task = service.GenerateBenchmarkListWithBestInClassComparisonAsync(EstablishmentType.Academies, new BenchmarkCriteria(), new BestInClassCriteria(), new FinancialDataModel());
            task.Wait();

            mockFinancialDataService.Verify(m => m.SearchSchoolsByCriteriaAsync(It.IsAny<BenchmarkCriteria>(), It.IsAny<EstablishmentType>(), It.IsAny<bool>(), It.IsAny<bool>()), Times.Exactly(16));
        }
    }
}
