using SFB.Web.ApplicationCore.Entities;
using System.Threading.Tasks;

namespace SFB.Web.ApplicationCore.Services.DataAccess
{
    public interface IEfficiencyMetricDataService
    {
        Task<EfficiencyMetricParentDataObject> GetSchoolDataObjectByUrnAsync(int urn);
        Task<bool> GetStatusByUrn(int urn);
    }
}
