using System.Threading.Tasks;
using SFB.Web.ApplicationCore.Models;

namespace SFB.Web.ApplicationCore.Services
{
    public interface IBicComparisonResultCachingService
    {
        ComparisonResult GetBicComparisonResultByUrn(long urn);
        void StoreBicComparisonResultByUrn(long urn, ComparisonResult comparisonResult);
        
        Task<bool> CscpHasPage(int urn, bool isMat);
        Task<bool> GiasHasPage(int urn, bool isMat);
    }
}
