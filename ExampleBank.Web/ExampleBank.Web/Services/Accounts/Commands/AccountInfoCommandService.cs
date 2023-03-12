using ExampleBank.Web.Commons;
using ExampleBank.Web.Data.Tables;
using ExampleBank.Web.Enums;
using ExampleBank.Web.Models;
using ExampleBank.Web.Models.Accounts.Requests;
using ExampleBank.Web.Models.Accounts.Responses;
using ExampleBank.Web.Repositories.Accounts.Commands;
using ExampleBank.Web.Repositories.BankAccounts.Commands;
using ExampleBank.Web.Repositories.Transactions.Commands;
using ExampleBank.Web.Services.Bases;
using ExampleBank.Web.UOMs;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Options;

namespace ExampleBank.Web.Services.Accounts.Commands
{
    public class AccountInfoCommandService : BaseCommandService<IBankUnitOfWork>, IAccountInfoCommandService
    {
        public AccountInfoCommandService(IBankUnitOfWork unitOfWork
            , IAccountCommandRepository accountCommandRepository
            , IBankAccountCommandRepository bankAccountCommandRepository
            , ITransactionCommandRepository transactionCommandRepository)
            : base(unitOfWork)
        {
            AccountCommandRepository = accountCommandRepository;
            BankAccountCommandRepository = bankAccountCommandRepository;
            TransactionCommandRepository = transactionCommandRepository;
        }

        protected IAccountCommandRepository AccountCommandRepository { get; }
        protected IBankAccountCommandRepository BankAccountCommandRepository { get; }
        protected ITransactionCommandRepository TransactionCommandRepository { get; }

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
                TransactionType = TransactionType.Deposit,
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
            var updateEntity = await AccountCommandRepository.GetByIdAsync(Guid.Parse(model.Id));
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

        public async Task<ResultModel<DepositAccountResponseModel>> DepositAsync(DepositAccountRequestModel model)
        {
            if (model.Amount < 1)
            {
                return new ResultModel<DepositAccountResponseModel>(false
                    , "The 'Amount' must more than zero.", ChangeToResponse(model));
            }

            var entity = await BankAccountCommandRepository.GetByIdAsync(model.IBAM, Guid.Parse(model.Id));
            if (entity is null)
            {
                return new ResultModel<DepositAccountResponseModel>(false
                    , "Data not found", ChangeToResponse(model));
            }

            decimal fee = model.Amount * CommonInternalConstants.DefaultData.Fee;
            entity.Amount += model.Amount - fee;

            var newTransaction = new Transaction
            {
                Id = Guid.NewGuid(),
                TransactionType = TransactionType.Deposit,
                IBAN = entity.IBAN,
                AccountId = entity.AccountId,
                Amount = model.Amount,
                Fee = fee,
                Balance = model.Amount - fee,
                Description = TransactionType.Deposit.ToString(),
                TransDate = DateTime.UtcNow
            };

            BankAccountCommandRepository.Edit(entity);
            TransactionCommandRepository.Add(newTransaction);
            await UnitOfWork.CommitAsync();

            return new ResultModel<DepositAccountResponseModel>(true);
        }

        public async Task<ResultModel<TransferAccountResponseModel>> TransferAsync(TransferAccountRequestModel model)
        {
            var fromBankAccount = await BankAccountCommandRepository
                .GetByIdAsync(model.IBAM, Guid.Parse(model.Id));
            if (fromBankAccount is null)
            {
                return new ResultModel<TransferAccountResponseModel>(false
                    , $"From bank account '{model.IBAM}' not found.", ChangeToResponse(model));
            }

            if (fromBankAccount.Amount < model.Amount)
            {
                return new ResultModel<TransferAccountResponseModel>(false
                    , $"Cannot transfer. Because amount not enough.", ChangeToResponse(model));
            }

            var keys = GetKeys(model.ToKeys);
            if (!keys.AccountId.HasValue || string.IsNullOrWhiteSpace(keys.IBAM))
            {
                return new ResultModel<TransferAccountResponseModel>(false
                    , $"Cannot transfer. Keys not found.", ChangeToResponse(model));
            }

            var toBankAccount = await BankAccountCommandRepository.GetByIdAsync(keys.IBAM, keys.AccountId.Value);
            if (toBankAccount is null)
            {
                return new ResultModel<TransferAccountResponseModel>(false
                    , $"To bank account '{model.ToKeys}' not found.", ChangeToResponse(model));
            }

            PassingAndUpdateFromAccount(model, fromBankAccount, keys.IBAM);
            PassingAndUpdateToAccount(model, toBankAccount);
            await UnitOfWork.CommitAsync();
            return new ResultModel<TransferAccountResponseModel>(true);
        }

        private void PassingAndUpdateFromAccount(TransferAccountRequestModel model, BankAccount entity
            , string toIBAM)
        {
            entity.Amount -= model.Amount;
            BankAccountCommandRepository.Edit(entity);
            TransactionCommandRepository.Add(new Transaction
            {
                Id = Guid.NewGuid(),
                AccountId = entity.AccountId,
                IBAN = entity.IBAN,
                Amount = model.Amount,
                Balance = model.Amount,
                Description = $"{TransactionType.Transfer} amount to '{toIBAM}'.",
                Fee = 0,
                TransactionType = TransactionType.Transfer,
                TransDate = DateTime.UtcNow
            });
        }

        private void PassingAndUpdateToAccount(TransferAccountRequestModel model, BankAccount entity)
        {
            entity.Amount += model.Amount;
            BankAccountCommandRepository.Edit(entity);
            TransactionCommandRepository.Add(new Transaction
            {
                Id = Guid.NewGuid(),
                AccountId = entity.AccountId,
                IBAN = entity.IBAN,
                Amount = model.Amount,
                Balance = model.Amount,
                Description = $"Receive amount from '{model.IBAM}'.",
                Fee = 0,
                TransactionType = TransactionType.Transfer,
                TransDate = DateTime.UtcNow
            });
        }

        private TransferAccountResponseModel ChangeToResponse(TransferAccountRequestModel model)
            => new TransferAccountResponseModel
            {
                Id = model.Id,
                Amount = model.Amount,
                IBAM = model.IBAM,
                ToKeys = model.ToKeys
            };

        private DepositAccountResponseModel ChangeToResponse(DepositAccountRequestModel model)
            => new DepositAccountResponseModel
            {
                Id = model.Id,
                Amount = model.Amount,
                IBAM = model.IBAM
            };

        private (Guid? AccountId, string IBAM) GetKeys(string keys)
        {
            try
            {
                string[] rawKeys = keys.DecodeToBase64().Split('|');
                return (Guid.Parse(rawKeys[0]), rawKeys[1]);
            }
            catch
            {
                return (null, null);
            }
        }
    }
}