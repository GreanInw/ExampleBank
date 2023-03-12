using ExampleBank.Web.Models;
using ExampleBank.Web.Models.Accounts.Requests;
using ExampleBank.Web.Models.Accounts.Responses;

namespace ExampleBank.Web.Services.Accounts.Queries
{
    public interface IAccountInfoQueryService
    {
        Task<ResultModel<IEnumerable<T>>> GetAsync<T>() where T : AccountInfoResponseModel, new();
        Task<GetTransferInfoResponseModel> GetTransferInfoAsync(GetTransferInfoRequestModel model);
    }
}
