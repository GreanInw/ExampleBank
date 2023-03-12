using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExampleBank.Web.Models.Accounts.Responses
{
    public class GetTransferInfoResponseModel
    {
        public GetTransferInfoResponseModel()
        {
            IBAMItems = new List<SelectListItem>();
        }

        public decimal TotalAmount { get; set; }
        public IEnumerable<SelectListItem> IBAMItems { get; set; }
    }
}
