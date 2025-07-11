using MediatR;

namespace FinanceTracker.API.Application.Commands
{
    public class DeleteExpenseCommand : IRequest<bool>
    {
        public Guid ExpenseId { get; set; }

        public DeleteExpenseCommand(Guid expenseId)
        {
            ExpenseId = expenseId;
        }
    }
}
