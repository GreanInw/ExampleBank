using ExampleBank.Web.Models;
using ExampleBank.Web.Models.Accounts.Requests;
using ExampleBank.Web.Models.Accounts.Responses;
using ExampleBank.Web.Services.Accounts.Queries;
using MediatR;

namespace ExampleBank.Web.CQRS.Accounts.Queries
{
    public class GetAccountInfoQueryHandler : IRequestHandler<GetAccountRequestModel
        , ResultModel<IEnumerable<AccountInfoResponseModel>>>
    {
        public GetAccountInfoQueryHandler(IAccountInfoQueryService accountInfoQueryService)
        {
            AccountInfoQueryService = accountInfoQueryService;
        }

        public IAccountInfoQueryService AccountInfoQueryService { get; }

        public async Task<ResultModel<IEnumerable<AccountInfoResponseModel>>>
            Handle(GetAccountRequestModel request, CancellationToken cancellationToken)
            => await AccountInfoQueryService.GetAsync<AccountInfoResponseModel>();
    }
}
