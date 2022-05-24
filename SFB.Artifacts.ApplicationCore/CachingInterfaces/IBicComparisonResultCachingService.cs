using SFB.Web.ApplicationCore.Models;

namespace SFB.Web.ApplicationCore.Services
{
    public interface IBicComparisonResultCachingService
    {
        ComparisonResult GetBicComparisonResultByUrn(long urn);
        void StoreBicComparisonResultByUrn(long urn, ComparisonResult comparisonResult);
    }
}
