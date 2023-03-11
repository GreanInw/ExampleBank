using ExampleBank.Web.Commons;
using ExampleBank.Web.Data.Tables;
using ExampleBank.Web.Models;
using ExampleBank.Web.Models.Accounts.Requests;
using ExampleBank.Web.Repositories.Accounts.Commands;
using ExampleBank.Web.Repositories.Transactions.Commands;
using ExampleBank.Web.Services.Bases;
using ExampleBank.Web.UOMs;

namespace ExampleBank.Web.Services.Accounts.Commands
{
    public class AccountInfoCommandService : BaseCommandService<IBankUnitOfWork>, IAccountInfoCommandService
    {
        public AccountInfoCommandService(IBankUnitOfWork unitOfWork
            , IAccountCommandRepository accountCommandRepository
            , ITransactionCommandRepository transactionCommandRepository)
            : base(unitOfWork)
        {
            AccountCommandRepository = accountCommandRepository;
            TransactionCommandRepository = transactionCommandRepository;
        }

        protected IAccountCommandRepository AccountCommandRepository { get; }
        public ITransactionCommandRepository TransactionCommandRepository { get; }

        public async Task<ResultModel> CreateAsync(CreateAccountRequestModel model)
        {
            decimal fee = model.Amount * CommonInternalConstants.DefaultData.Fee;

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
                        Amount = model.Amount - fee,
                    }
                }
            };

            var newTransaction = new Transaction
            {
                Id = Guid.NewGuid(),
                AccountId = newAccount.Id,
                IBAN = model.IBAM,
                Amount = model.Amount,
                Fee = fee,
                Balance = model.Amount - fee,
                TransactionType = Enums.TransactionType.Deposit,
                Description = "Initilize",
                TransDate = DateTime.UtcNow,
            };

            AccountCommandRepository.Add(newAccount);
            TransactionCommandRepository.Add(newTransaction);
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
