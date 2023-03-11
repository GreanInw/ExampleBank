using MediatR;

namespace ExampleBank.Web.Models.Accounts.Requests
{
    public class UpdateAccountRequestModel : IRequest<ResultModel>
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
