using System.Linq;
using System.Threading.Tasks;
using SFB.Web.ApplicationCore.DataAccess;
using SFB.Web.ApplicationCore.Entities;

namespace SFB.Web.ApplicationCore.Services.DataAccess
{
    public class EfficiencyMetricDataService : IEfficiencyMetricDataService
    {
        private readonly IEfficiencyMetricRepository _efficiencyMetricRepository;

        public EfficiencyMetricDataService(IEfficiencyMetricRepository efficiencyMetricRepository)
        {
            _efficiencyMetricRepository = efficiencyMetricRepository;
        }

        public async Task<EfficiencyMetricParentDataObject> GetSchoolDataObjectByUrnAsync(int urn)
        {
            EfficiencyMetricParentDataObject emData = null;
            var emDatas =  await _efficiencyMetricRepository.GetEfficiencyMetricDataObjectByUrnAsync(urn);
            if (emDatas.Count == 2) {
                emData = emDatas.Where(em => em.PrimarySecondary == "Secondary").FirstOrDefault();
            }
            else {
                emData = emDatas.First();
            }
            emData.Neighbours = emData.Neighbours.OrderByDescending(n => n.EfficiencyScore).ToList();
            return emData;
        }

        public Task<bool> GetStatusByUrn(int urn)
        {
            return _efficiencyMetricRepository.GetStatusByUrnAsync(urn);            
        }
    }
}
