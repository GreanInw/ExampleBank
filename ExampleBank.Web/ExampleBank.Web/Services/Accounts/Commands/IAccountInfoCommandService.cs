using ExampleBank.Web.Models;
using ExampleBank.Web.Models.Accounts.Requests;
using ExampleBank.Web.Models.Accounts.Responses;

namespace ExampleBank.Web.Services.Accounts.Commands
{
    public interface IAccountInfoCommandService
    {
        Task<ResultModel> CreateAsync(CreateAccountRequestModel model);
        Task<ResultModel> UpdateAsync(UpdateAccountRequestModel model);
        Task<ResultModel<DepositAccountResponseModel>> DepositAsync(DepositAccountRequestModel model);
        Task<ResultModel<TransferAccountResponseModel>> TransferAsync(TransferAccountRequestModel model);
    }
}
