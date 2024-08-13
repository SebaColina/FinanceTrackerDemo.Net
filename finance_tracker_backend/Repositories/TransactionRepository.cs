public interface ITransactionRepository
{
    IEnumerable<Transaction> GetAllTransactions();
}

public class TransactionRepository : ITransactionRepository
{
    private readonly ApplicationDbContext _context;

    public TransactionRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Transaction> GetAllTransactions()
    {
        return _context.Transactions.ToList();
    }
}
