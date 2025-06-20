namespace FinanceTracker.API.Application.Commands
{
    using MediatR;

    public class CreateExpenseCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public Guid CategoryId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime ExpenseDate { get; set; }
        public string Currency { get; set; }
    }

}
