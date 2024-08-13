public interface ITransactionService
{
    IEnumerable<TransactionDto> GetTransactions();
}

public class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _transactionRepository;

    public TransactionService(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public IEnumerable<TransactionDto> GetTransactions()
    {
        var transactions = _transactionRepository.GetAllTransactions();
        // Business logic (e.g., filtering, mapping, etc.)
        return transactions.Select(t => new TransactionDto
        {
            Id = t.Id,
            Amount = t.Amount,
            Date = t.Date,
            Description = t.Description,
            Category = t.Category,
            UserId = t.UserId
        });
    }
}
