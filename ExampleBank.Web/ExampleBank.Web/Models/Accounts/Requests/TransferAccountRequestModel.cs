using ExampleBank.Web.Models.Accounts.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ExampleBank.Web.Models.Accounts.Requests
{
    public class TransferAccountRequestModel : IRequest<ResultModel<TransferAccountResponseModel>>
    {
        public string Id { get; set; }
        public string FromIBAM { get; set; }

        public string ToIBAM { get; set; }
        public string ToAccountId { get; set; }

        [Required(ErrorMessage = "The 'Amount' is required.")]
        public decimal Amount { get; set; }
    }
}
