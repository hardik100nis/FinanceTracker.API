using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FinanceTracker.API.Application.Commands
{
    public class UpdateExpenseCommand : IRequest<Guid>
    {
        public Guid ExpenseId { get; set; }
        public string Category { get; set; } // Change type to string
        public decimal Amount { get; set; }
        public string? Description { get; set; }
        public DateTime ExpenseDate { get; set; }
        public string? Currency { get; set; }

        public UpdateExpenseCommand() { }

        public UpdateExpenseCommand(Guid expenseId, string Category, decimal amount, string? description, DateTime expenseDate, string? currency)
        {
            ExpenseId = expenseId;
            Category = Category;
            Amount = amount;
            Description = description;
            ExpenseDate = expenseDate;
            Currency = currency;
        }
    }
}
