using ExampleBank.Web.UOMs.Bases;

namespace ExampleBank.Web.Services.Bases
{
    public abstract class BaseCommandService<TInterfaceUnitOfWork> where TInterfaceUnitOfWork : IUnitOfWork
    {
        public BaseCommandService(TInterfaceUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        protected TInterfaceUnitOfWork UnitOfWork { get; }
    }
}
