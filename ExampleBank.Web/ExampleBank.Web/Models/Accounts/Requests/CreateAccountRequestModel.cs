using MediatR;

namespace ExampleBank.Web.Models.Accounts.Requests
{
    public class CreateAccountRequestModel : IRequest<ResultModel>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}