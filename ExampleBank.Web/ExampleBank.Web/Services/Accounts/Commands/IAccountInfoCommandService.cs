using ExampleBank.Web.Models;
using ExampleBank.Web.Models.Accounts.Requests;

namespace ExampleBank.Web.Services.Accounts.Commands
{
    public interface IAccountInfoCommandService
    {
        Task<ResultModel> CreateAsync(CreateAccountRequestModel model);
        Task<ResultModel> UpdateAsync(UpdateAccountRequestModel model);
    }
}
