using FinanceTracker.API.Application.Commands;
using FinanceTracker.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.API.Application.Handlers
{
    public class DeleteExpenseCommandHandler : IRequestHandler<DeleteExpenseCommand, bool>
    {
        private readonly ApplicationDbContext _dbContext;

        public DeleteExpenseCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(DeleteExpenseCommand request, CancellationToken cancellationToken)
        {
            var expense = await _dbContext.Expenses
                .FirstOrDefaultAsync(e => e.ExpenseId == request.ExpenseId, cancellationToken);

            if (expense == null)
                return false;

            _dbContext.Expenses.Remove(expense);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
