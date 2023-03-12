using ExampleBank.Web.Models;
using ExampleBank.Web.Models.Accounts.Responses;
using ExampleBank.Web.Repositories.Accounts.Queries;
using ExampleBank.Web.Repositories.BankAccounts.Queries;
using Microsoft.EntityFrameworkCore;

namespace ExampleBank.Web.Services.Accounts.Queries
{
    public class AccountInfoQueryService : IAccountInfoQueryService
    {
        public AccountInfoQueryService(IAccountQueryRepository accountQueryRepository
            , IBankAccountQueryRepository bankAccountQueryRepository)
        {
            AccountQueryRepository = accountQueryRepository;
            BankAccountQueryRepository = bankAccountQueryRepository;
        }

        protected IAccountQueryRepository AccountQueryRepository { get; }
        protected IBankAccountQueryRepository BankAccountQueryRepository { get; }

        public async Task<ResultModel<IEnumerable<T>>> GetAsync<T>()
            where T : AccountInfoResponseModel, new()
        {
            var entities = await AccountQueryRepository.All.AsNoTracking()
                .Include(t => t.BackAccounts)
                .Select(s => new T
                {
                    Id = s.Id,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    BankAccounts = s.BackAccounts.Select(ss => new AccountInfoResponseModel.BankAccountInfo
                    {
                        IBAM = ss.IBAN,
                        AccountId = ss.AccountId.ToString(),
                        Amount = ss.Amount,
                        Type = ss.BankAccountType
                    })
                }).ToListAsync();
            return new ResultModel<IEnumerable<T>>(true, entities);
        }
    }
}