using Moq;
using NUnit.Framework;
using SFB.Web.ApplicationCore.DataAccess;
using SFB.Web.ApplicationCore.Entities;
using SFB.Web.ApplicationCore.Services.DataAccess;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFB.Web.UnitTests.Services.DataAccess
{
    public class SelfAssessmentDashboardDataServiceTests
    {
        [Test]
        public void GetSADSchoolRatingsDataObjectAsyncShouldReturnLatest()
        {
            var mockRepository = new Mock<ISelfAssesmentDashboardRepository>();

            var dummyTask = Task.Run(() => {
                return new List<SADSchoolRatingsDataObject>() { 
                    new SADSchoolRatingsDataObject() { Term = "2020/2021" , RatingText = "1" },
                    new SADSchoolRatingsDataObject() { Term = "2020/2021" , RatingText = "2" },
                    new SADSchoolRatingsDataObject() { Term = "2019/2020" , RatingText = "2" },
                    new SADSchoolRatingsDataObject() { Term = "2021/2022" , RatingText = "30" },
                    new SADSchoolRatingsDataObject() { Term = "2021/2022" , RatingText = "31" },
                    new SADSchoolRatingsDataObject() { Term = "2021/2022" , RatingText = "32" },
                    new SADSchoolRatingsDataObject() { Term = "2018/2019" , RatingText = "4" },
                };
            });
            
            mockRepository.Setup(m => m.GetSADSchoolRatingsDataObjectsAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(dummyTask);            

            var service = new SelfAssesmentDashboardDataService(mockRepository.Object);

            var task = service.GetSADSchoolRatingsDataObjectAsync("", "", true, "", "", "", "");
            task.Wait();

            Assert.AreEqual(3, task.Result.Count);
            Assert.AreEqual("2021/2022", task.Result.First().Term);
        }
    }
}
