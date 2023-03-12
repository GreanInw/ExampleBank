using ExampleBank.Web.Models.Transactions.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExampleBank.Web.Models.Transactions.Requests
{
    public class GetTransactionsByAccountRequestModel : IRequest<IEnumerable<GetTransactionsByAccountResponseModel>>
    {
        public string Id { get; set; }
        public string IBAM { get; set; }
    }
}