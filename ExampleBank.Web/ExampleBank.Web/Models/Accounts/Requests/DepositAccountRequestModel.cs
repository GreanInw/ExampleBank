using ExampleBank.Web.Models.Accounts.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ExampleBank.Web.Models.Accounts.Requests
{
    public class DepositAccountRequestModel : IRequest<ResultModel<DepositAccountResponseModel>>
    {
        public string Id { get; set; }
        public string IBAM { get; set; }
        [Required(ErrorMessage = "The 'Amount' is required.")]
        public decimal Amount { get; set; }
    }
}