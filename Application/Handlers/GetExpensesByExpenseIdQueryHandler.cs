using FinanceTracker.API.Application.DTOs;
using FinanceTracker.API.Application.Queries;
using FinanceTracker.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.API.Application.Handlers
{
    public class GetExpensesByExpenseIdQueryHandler : IRequestHandler<GetExpensesByExpenseIdQuery, ExpenseDto>
    {
        private readonly ApplicationDbContext _context;

        public GetExpensesByExpenseIdQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ExpenseDto> Handle(GetExpensesByExpenseIdQuery request, CancellationToken cancellationToken)
        {

            var expense = await _context.Expenses
             .AsNoTracking()
             .FirstOrDefaultAsync(e => e.ExpenseId == request.ExpenseId && e.UserId == request.UserId, cancellationToken);

            if (expense == null)
                return null;

            return new ExpenseDto
            {
                ExpenseId = expense.ExpenseId,
                Amount = expense.Amount,
                Description = expense.Description,
                ExpenseDate = expense.ExpenseDate,
                Currency = expense.Currency,
                Category = expense.Category,
            };
        }
    }
}
