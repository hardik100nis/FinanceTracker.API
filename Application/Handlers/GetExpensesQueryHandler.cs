using FinanceTracker.API.Application.DTOs;
using FinanceTracker.API.Application.Queries;
using FinanceTracker.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.API.Application.Handlers
{
    public class GetExpensesQueryHandler : IRequestHandler<GetExpensesQuery, List<ExpenseDto>>
    {
        private readonly ApplicationDbContext _context;

        public GetExpensesQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ExpenseDto>> Handle(GetExpensesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Expenses
                .Where(e => e.UserId == request.UserId)
                .Select(e => new ExpenseDto
                {
                    ExpenseId = e.ExpenseId,
                    Amount = e.Amount,
                    Description = e.Description,
                    ExpenseDate = e.ExpenseDate,
                    Currency = e.Currency,
                    Category = e.Category,

                }).ToListAsync();
        }
    }
}
