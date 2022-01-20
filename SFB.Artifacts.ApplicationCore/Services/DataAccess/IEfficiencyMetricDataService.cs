using SFB.Web.ApplicationCore.Entities;
using System.Threading.Tasks;

namespace SFB.Web.ApplicationCore.Services.DataAccess
{
    public interface IEfficiencyMetricDataService
    {
        Task<EfficiencyMetricParentDataObject> GetSchoolDataObjectByUrnAsync(long urn);
        Task<bool> GetStatusByUrn(long urn);
    }
}
