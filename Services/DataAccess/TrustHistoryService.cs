using SFB.Web.ApplicationCore.DataAccess;
using SFB.Web.ApplicationCore.Models;
using System.Threading.Tasks;

namespace SFB.Web.ApplicationCore.Services.DataAccess
{
    public class TrustHistoryService : ITrustHistoryService
    {
        private ITrustHistoryRepository _repository;

        public TrustHistoryService(ITrustHistoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<TrustHistoryModel> GetTrustHistoryModelAsync(int uid)
        {
            var data = await _repository.GetTrustHistoryDataObjectAsync(uid);

            return new TrustHistoryModel(data);
        }
    }
}
