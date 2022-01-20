using System.Collections.Generic;
using System.Threading.Tasks;

namespace SFB.Web.ApplicationCore.Services
{
    public interface IActiveEstablishmentsService
    {
        Task<List<long>> GetAllActiveUrnsAsync();
        Task<List<int>> GetAllActiveCompanyNosAsync();
        Task<List<long>> GetAllActiveFuidsAsync();
    }
}
