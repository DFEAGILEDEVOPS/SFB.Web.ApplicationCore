using SFB.Web.ApplicationCore.Entities;
using SFB.Web.ApplicationCore.Models;
using System.Threading.Tasks;

namespace SFB.Web.ApplicationCore.Services.DataAccess
{
    public interface ITrustHistoryService
    {
        Task<TrustHistoryModel> GetTrustHistoryModelAsync(int uid);
    }
}
