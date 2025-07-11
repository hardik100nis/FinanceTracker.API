namespace FinanceTracker.API.Controllers
{
    using Application.Commands;
    using FinanceTracker.API.Application.Queries;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;

    [Authorize(AuthenticationSchemes = "JwtBearer")]
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
        public async Task<IActionResult> GetExpenses()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                return Unauthorized();

            var userId = Guid.Parse(userIdClaim.Value);

            var query = new GetExpensesQuery { UserId = userId };
            var expenses = await _mediator.Send(query);
            return Ok(expenses);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpense(Guid id)
        {
            var result = await _mediator.Send(new DeleteExpenseCommand(id));

            if (!result)
                return NotFound(new { message = "Expense not found." });

            return Ok(new { message = "Expense deleted successfully." });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExpense(Guid id, UpdateExpenseCommand command)
        {

            var result = await _mediator.Send(new UpdateExpenseCommand
            {
                ExpenseId = id,
                Category = command.Category,
                Amount = command.Amount,
                Description = command.Description,
                ExpenseDate = command.ExpenseDate,
                Currency = command.Currency
            });

            if (result == Guid.Empty)
            {
                return NotFound(new { message = "Expense not found." });
            }

            return Ok(new { message = "Expense updated successfully.", ExpenseId = result });
        }

        [HttpGet("{userId}/expenses/{expenseId}")]
        public async Task<IActionResult> GetExpensesByExpenseId(Guid userId, Guid expenseId)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                return Unauthorized();

            var loggedInUserId = Guid.Parse(userIdClaim.Value);
            if (loggedInUserId != userId)
                return Forbid();

            var query = new GetExpensesByExpenseIdQuery
            {
                ExpenseId = expenseId,
                UserId = loggedInUserId
            };

            var expense = await _mediator.Send(query);
            if (expense == null)
                return NotFound();

            return Ok(expense);
        }
    }

}
