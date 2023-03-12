using ExampleBank.Web.Models.Accounts.Responses;
using MediatR;

namespace ExampleBank.Web.Models.Accounts.Requests
{
    public class GetTransferInfoRequestModel : IRequest<GetTransferInfoResponseModel>
    {
        public string IBAM { get; set; }
        public string AccountId { get; set; }
        public string ExcludeIBAM { get; set; }
    }
}