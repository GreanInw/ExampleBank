using ExampleBank.Web.Models.Accounts.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ExampleBank.Web.Models.Accounts.Requests
{
    public class TransferAccountRequestModel : IRequest<ResultModel<TransferAccountResponseModel>>
    {
        public TransferAccountRequestModel()
        {
            IBAMItems = new List<SelectListItem>();
        }

        public string Id { get; set; }
        public string IBAM { get; set; }
        [Required(ErrorMessage = "The 'To IBAM' is required.")]
        public string ToKeys { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Amount { get; set; }

        public IEnumerable<SelectListItem> IBAMItems { get; set; }
    }
}
