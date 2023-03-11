using MediatR;

namespace ExampleBank.Web.Models.Accounts.Requests
{
    public class UpdateAccountRequestModel : CreateAccountRequestModel, IRequest<ResultModel>
    {
        public Guid Id { get; set; }
    }
}
