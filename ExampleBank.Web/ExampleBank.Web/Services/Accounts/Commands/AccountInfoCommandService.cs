using ExampleBank.Web.Commons;
using ExampleBank.Web.Data.Tables;
using ExampleBank.Web.Models;
using ExampleBank.Web.Models.Accounts.Requests;
using ExampleBank.Web.Repositories.Accounts.Commands;
using ExampleBank.Web.Services.Bases;
using ExampleBank.Web.UOMs;

namespace ExampleBank.Web.Services.Accounts.Commands
{
    public class AccountInfoCommandService : BaseCommandService<IBankUnitOfWork>, IAccountInfoCommandService
    {
        public AccountInfoCommandService(IBankUnitOfWork unitOfWork, IAccountCommandRepository accountCommandRepository)
            : base(unitOfWork)
        {
            AccountCommandRepository = accountCommandRepository;
        }

        protected IAccountCommandRepository AccountCommandRepository { get; }

        public async Task<ResultModel> CreateAsync(CreateAccountRequestModel model)
        {
            var newAccount = new Account
            {
                Id = Guid.NewGuid(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                BackAccounts = new List<BankAccount>
                {
                    new BankAccount
                    {
                        IBAN = model.IBAM,
                        BankAccountType = model.Type,
                        Amount = model.Amount * CommonInternalConstants.DefaultData.Fee,
                    }
                }
            };

            AccountCommandRepository.Add(newAccount);
            await UnitOfWork.CommitAsync();
            return new ResultModel(true);
        }

        public async Task<ResultModel> UpdateAsync(UpdateAccountRequestModel model)
        {
            var updateEntity = await AccountCommandRepository.GetByIdAsync(model.Id);
            if (updateEntity is null)
            {
                return new ResultModel(false, "Data not found");
            }

            updateEntity.FirstName = model.FirstName;
            updateEntity.LastName = model.LastName;
            AccountCommandRepository.Edit(updateEntity);
            await UnitOfWork.CommitAsync();
            return new ResultModel(true);
        }

    }
}
