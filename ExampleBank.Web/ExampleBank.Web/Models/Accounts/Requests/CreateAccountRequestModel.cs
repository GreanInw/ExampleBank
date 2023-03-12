using ExampleBank.Web.Enums;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ExampleBank.Web.Models.Accounts.Requests
{
    public class CreateAccountRequestModel : IRequest<ResultModel>
    {
        public string Id { get; set; }
        
        [Required(ErrorMessage ="The 'IBAM' is required.")]
        public string IBAM { get; set; }

        [Required(ErrorMessage ="The 'First name' is required.")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage ="The 'Last name' is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage ="The 'Amount' is required.")]
        public decimal Amount { get; set; }
        public BankAccountType Type { get; set; }
    }
}