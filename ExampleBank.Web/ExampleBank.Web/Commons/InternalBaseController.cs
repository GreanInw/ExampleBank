using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExampleBank.Web.Commons
{
    public class InternalBaseController : Controller
    {
        public InternalBaseController(IMediator mediator)
        {
            Mediator = mediator;
        }

        protected IMediator Mediator { get; }
    }
}
