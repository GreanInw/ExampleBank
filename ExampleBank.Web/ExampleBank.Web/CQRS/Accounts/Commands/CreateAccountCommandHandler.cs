using ExampleBank.Web.Models;
using ExampleBank.Web.Models.Accounts.Requests;
using ExampleBank.Web.Services.Accounts.Commands;
using MediatR;

namespace ExampleBank.Web.CQRS.Accounts.Commands
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountRequestModel, ResultModel>
    {
        public CreateAccountCommandHandler(IAccountInfoCommandService accountInfoCommandService)
        {
            AccountInfoCommandService = accountInfoCommandService;
        }

        public IAccountInfoCommandService AccountInfoCommandService { get; }

        public async Task<ResultModel> Handle(CreateAccountRequestModel request, CancellationToken cancellationToken)
            => await AccountInfoCommandService.CreateAsync(request);
    }
}
