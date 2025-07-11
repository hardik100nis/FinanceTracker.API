using FinanceTracker.API.Application.DTOs;
using MediatR;

namespace FinanceTracker.API.Application.Queries
{
    public class GetExpensesByExpenseIdQuery : IRequest<ExpenseDto>
    {
        public Guid UserId { get; set; }

        public Guid ExpenseId { get; set; }
    }
}
