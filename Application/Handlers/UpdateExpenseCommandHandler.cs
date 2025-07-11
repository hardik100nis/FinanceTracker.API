using FinanceTracker.API.Application.Commands;
using FinanceTracker.API.Domain;
using FinanceTracker.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using System.Security.Claims;

namespace FinanceTracker.API.Application.Handlers
{
    public class UpdateExpenseCommandHandler : IRequestHandler<UpdateExpenseCommand, Guid>
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UpdateExpenseCommandHandler(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Guid> Handle(UpdateExpenseCommand request, CancellationToken cancellationToken)
        {
            // 🔐 Get UserId from JWT claims
            var userIdClaim = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                throw new UnauthorizedAccessException("User is not authenticated");

            var userId = Guid.Parse(userIdClaim.Value); // assuming UserId is Guid

            // Explicitly specify the namespace to resolve ambiguity
            var expense = await Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.FirstOrDefaultAsync(
                _context.Expenses,
                e => e.ExpenseId == request.ExpenseId,
                cancellationToken
            );

            if (expense == null)
                throw new KeyNotFoundException("Expense not found");

            // Update the existing expense
            expense.Category = request.Category;
            expense.Amount = request.Amount;
            expense.Description = request.Description;
            expense.ExpenseDate = request.ExpenseDate;
            expense.Currency = request.Currency;

            _context.Expenses.Update(expense);
            await _context.SaveChangesAsync(cancellationToken);

            return expense.ExpenseId;
        }
    }
}