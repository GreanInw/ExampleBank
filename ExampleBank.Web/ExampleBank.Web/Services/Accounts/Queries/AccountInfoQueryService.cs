using ExampleBank.Web.Models;
using ExampleBank.Web.Models.Accounts.Responses;
using ExampleBank.Web.Repositories.Accounts.Queries;
using Microsoft.EntityFrameworkCore;

namespace ExampleBank.Web.Services.Accounts.Queries
{
    public class AccountInfoQueryService : IAccountInfoQueryService
    {
        public AccountInfoQueryService(IAccountQueryRepository accountQueryRepository)
        {
            AccountQueryRepository = accountQueryRepository;
        }

        public IAccountQueryRepository AccountQueryRepository { get; }

        public async Task<ResultModel<IEnumerable<T>>> GetAsync<T>()
            where T : AccountInfoResponseModel, new()
        {
            var entities = await AccountQueryRepository.All.AsNoTracking()
                .Select(s => new T
                {
                    Id = s.Id,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                }).ToListAsync();
            return new ResultModel<IEnumerable<T>>(true, entities);
        }
    }
}