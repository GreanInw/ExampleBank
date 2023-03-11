using ExampleBank.Web.Models.Accounts.Responses;
using MediatR;

namespace ExampleBank.Web.Models.Accounts.Requests
{
    public class GetAccountRequestModel : IRequest<ResultModel<IEnumerable<AccountInfoResponseModel>>>
    {
    }
}