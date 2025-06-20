using FinanceTracker.API.Application.DTOs;
using MediatR;

namespace FinanceTracker.API.Application.Queries
{
    public class GetExpensesQuery : IRequest<List<ExpenseDto>>
    {
        public Guid UserId { get; set; }
    }
}
