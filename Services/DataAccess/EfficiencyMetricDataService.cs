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
            var emData =  await _efficiencyMetricRepository.GetEfficiencyMetricDataObjectByUrnAsync(urn);
            emData.Neighbours = emData.Neighbours.OrderByDescending(n => n.EfficiencyScore).ToList();
            return emData;
        }
    }
}
