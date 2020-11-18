using SFB.Web.ApplicationCore.Entities;
using System.Threading.Tasks;

namespace SFB.Web.ApplicationCore.DataAccess
{
    public interface ITrustHistoryRepository
    {
        Task<TrustHistoryDataObject> GetTrustHistoryDataObjectAsync(int uid);
    }
}
