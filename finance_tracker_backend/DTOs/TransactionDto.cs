public class TransactionDto
{
    public int Id { get; set; }
    public int Amount { get; set; }
    public DateOnly Date { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public string UserId { get; set; }
}
