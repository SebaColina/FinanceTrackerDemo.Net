public interface ITransactionRepository
{
    IEnumerable<Transaction> GetAllTransactions();
    Transaction GetTransactionById(int id);
    bool UpdateTransaction(Transaction transaction);
    bool CreateTransaction(Transaction transaction);
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

    public Transaction GetTransactionById(int id)
    {
        if (_context == null)
        {
            throw new InvalidOperationException("Database context is null.");
        }

        var result = _context.Transactions.Find(id) ?? throw new KeyNotFoundException($"Transaction with id {id} was not found.");
        return result;
    }


    public bool UpdateTransaction(Transaction transaction)
    {
        if (_context == null)
        {
            throw new InvalidOperationException("Database context is null.");
        }
        _context.Transactions.Update(transaction);
        return _context.SaveChanges() > 0;
    }

    public bool CreateTransaction(Transaction transaction)
    {
        if (_context == null)
        {
            throw new InvalidOperationException("Database context is null.");
        }
        _context.Transactions.Add(transaction);
        _context.SaveChanges();
        return true;
    }
}
