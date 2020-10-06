using SFB.Web.ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SFB.Web.ApplicationCore.DataAccess
{
    public interface IEfficiencyMetricRepository
    {
        Task<List<EfficiencyMetricParentDataObject>> GetEfficiencyMetricDataObjectByUrnAsync(int urn);

        Task<bool> GetStatusByUrnAsync(int urn);
    }
}
