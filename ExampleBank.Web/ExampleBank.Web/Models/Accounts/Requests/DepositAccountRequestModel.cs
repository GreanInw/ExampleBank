using ExampleBank.Web.Models.Accounts.Responses;
using MediatR;

namespace ExampleBank.Web.Models.Accounts.Requests
{
    public class DepositAccountRequestModel : IRequest<ResultModel<DepositAccountResponseModel>>
    {
        public string Id { get; set; }
        public string IBAM { get; set; }
        public decimal Amount { get; set; }
    }
}