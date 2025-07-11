using FinanceTracker.API.Application.Commands;
using FinanceTracker.API.Domain;
using FinanceTracker.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace FinanceTracker.API.Application.Handlers
{
    public class CreateExpenseCommandHandler : IRequestHandler<CreateExpenseCommand, Guid>
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateExpenseCommandHandler(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Guid> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
        {
            // 🔐 Get UserId from JWT claims
            var userIdClaim = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                throw new UnauthorizedAccessException("User is not authenticated");

            var userId = Guid.Parse(userIdClaim.Value); // assuming UserId is Guid

            var expense = new Expense
            {
                ExpenseId = Guid.NewGuid(),
                UserId = userId, // ✅ assigned from logged-in user
                Category = request.Category,
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
