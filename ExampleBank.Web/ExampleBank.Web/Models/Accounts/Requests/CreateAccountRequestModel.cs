using ExampleBank.Web.Enums;
using MediatR;

namespace ExampleBank.Web.Models.Accounts.Requests
{
    public class CreateAccountRequestModel : IRequest<ResultModel>
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string IBAM { get; set; }
        public decimal Amount { get; set; }
        public BankAccountType Type { get; set; }
    }
}