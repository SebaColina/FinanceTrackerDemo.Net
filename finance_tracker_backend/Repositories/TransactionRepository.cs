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
        if (_context == null)
        {
            throw new InvalidOperationException("Database context is null.");
        }
        var result =  _context.Transactions.ToList();
        return result;
    }
}
