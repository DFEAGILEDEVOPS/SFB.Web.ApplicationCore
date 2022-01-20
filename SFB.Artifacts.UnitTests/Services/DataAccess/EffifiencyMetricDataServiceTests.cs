using NUnit.Framework;
using Moq;
using SFB.Web.ApplicationCore.DataAccess;
using System.Threading.Tasks;
using SFB.Web.ApplicationCore.Entities;
using System.Collections.Generic;
using SFB.Web.ApplicationCore.Services.DataAccess;
using System;

namespace SFB.Web.UnitTests.Services.DataAccess
{
    public class EffifiencyMetricDataServiceTests
    {
        [Test]
        public void GetSchoolDataObjectByUrnAsyncShouldRaiseException()
        {
            var dummmyTask = Task.Run(() => 
            { 
                return new List<EfficiencyMetricParentDataObject> (); 
            });

            var mockRepository = new Mock<IEfficiencyMetricRepository>();
            mockRepository.Setup(m => m.GetEfficiencyMetricDataObjectByUrnAsync(It.IsAny<long>())).Returns(dummmyTask);

            var service = new EfficiencyMetricDataService(mockRepository.Object);
   
            Assert.Throws<AggregateException>(() => {
                var task = service.GetSchoolDataObjectByUrnAsync(1);
                task.Wait();
            });
        }

        [Test]
        public void GetSchoolDataObjectByUrnShouldReturnSecondaryDataIfDoubleResults() {

            var dummyTask = Task.Run(() => {
                return new List<EfficiencyMetricParentDataObject> { 
                    new EfficiencyMetricParentDataObject() { PrimarySecondary = "Primary", Neighbours = new List<EfficiencyMetricNeighbourDataObject>() { new EfficiencyMetricNeighbourDataObject() { Rank = 1 } } }, 
                    new EfficiencyMetricParentDataObject() { PrimarySecondary = "Secondary", Neighbours = new List<EfficiencyMetricNeighbourDataObject>() { new EfficiencyMetricNeighbourDataObject() { Rank = 1 } } }                      
                };
            });

            var mockRepository = new Mock<IEfficiencyMetricRepository>();
            mockRepository.Setup(m => m.GetEfficiencyMetricDataObjectByUrnAsync(It.IsAny<long>())).Returns(dummyTask);

            var service = new EfficiencyMetricDataService(mockRepository.Object);

            var task = service.GetSchoolDataObjectByUrnAsync(1);
            task.Wait();

            Assert.AreEqual("Secondary", task.Result.PrimarySecondary);

        }


        [Test]
        public void GetSchoolDataObjectByUrnShouldReturnFirstOneIfMultipleResults()
        {
            var dummyTask = Task.Run(() => {
                return new List<EfficiencyMetricParentDataObject> {
                    new EfficiencyMetricParentDataObject() { PrimarySecondary = "Primary", Neighbours = new List<EfficiencyMetricNeighbourDataObject>() { new EfficiencyMetricNeighbourDataObject() { Rank = 1 } } },
                    new EfficiencyMetricParentDataObject() { PrimarySecondary = "Secondary", Neighbours = new List<EfficiencyMetricNeighbourDataObject>() { new EfficiencyMetricNeighbourDataObject() { Rank = 1 } } },
                    new EfficiencyMetricParentDataObject() { PrimarySecondary = "Secondary", Neighbours = new List<EfficiencyMetricNeighbourDataObject>() { new EfficiencyMetricNeighbourDataObject() { Rank = 1 } } }
                };
            });

            var mockRepository = new Mock<IEfficiencyMetricRepository>();

            mockRepository.Setup(m => m.GetEfficiencyMetricDataObjectByUrnAsync(It.IsAny<long>())).Returns(dummyTask);

            var service = new EfficiencyMetricDataService(mockRepository.Object);

            var task = service.GetSchoolDataObjectByUrnAsync(1);
            task.Wait();

            Assert.AreEqual("Primary", task.Result.PrimarySecondary);
        }
    }
}
