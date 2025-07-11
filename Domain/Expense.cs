namespace FinanceTracker.API.Domain
{
    public class Expense
    {
        public Guid ExpenseId { get; set; }
        public Guid UserId { get; set; }
        public string Category { get; set; } // Changed from Guid to string
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime ExpenseDate { get; set; }
        public string Currency { get; set; }
    }

}
