namespace FinanceTracker.API.Application.DTOs
{
    public class ExpenseDto
    {
        public Guid ExpenseId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime ExpenseDate { get; set; }
        public string Currency { get; set; }

        public string Category { get; set; }
    }
}
