namespace FinanceTracker.API.Controllers
{
    using Application.Commands;
    using FinanceTracker.API.Application.Queries;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class ExpensesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExpensesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateExpenseCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetExpenses(Guid userId)
        {
            var query = new GetExpensesQuery { UserId = userId };
            var expenses = await _mediator.Send(query);
            return Ok(expenses);
        }
    }

}
