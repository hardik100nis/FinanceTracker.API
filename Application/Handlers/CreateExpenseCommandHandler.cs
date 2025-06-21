using FinanceTracker.API.Application.Commands;
using FinanceTracker.API.Domain;
using FinanceTracker.API.Infrastructure.Persistence;
using FinanceTracker.Infrastructure.Persistence;
using MediatR;

namespace FinanceTracker.API.Application.Handlers
{
    public class CreateExpenseCommandHandler : IRequestHandler<CreateExpenseCommand, Guid>
    {
        private readonly ApplicationDbContext _context;

        public CreateExpenseCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
        {
            var expense = new Expense
            {
                ExpenseId = Guid.NewGuid(),
                UserId = request.UserId,
                CategoryId = request.CategoryId,
                Amount = request.Amount,
                Description = request.Description,
                ExpenseDate = request.ExpenseDate,
                Currency = request.Currency
            };

            _context.Expenses.Add(expense);
            await _context.SaveChangesAsync();
            return expense.ExpenseId;
        }
    }
}
