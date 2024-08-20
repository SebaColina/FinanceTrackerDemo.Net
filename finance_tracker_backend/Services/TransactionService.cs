using AutoMapper;

namespace FinanceTrackerBackend.Services
{
    public interface ITransactionService
    {
        IEnumerable<TransactionDto> GetAllTransactions();
        TransactionDto GetTransactionById(int id);
        bool UpdateTransaction(TransactionDto transaction);
    }

    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public TransactionService(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public IEnumerable<TransactionDto> GetAllTransactions()
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

        public TransactionDto GetTransactionById(int id)
        {
            var transaction = _transactionRepository.GetTransactionById(id);
            return _mapper.Map<TransactionDto>(transaction);
        }

        public bool UpdateTransaction(TransactionDto transactionDto)
        {
            var oldTransaction = _transactionRepository.GetTransactionById(transactionDto.Id);
            if(oldTransaction != null){
                _mapper.Map(transactionDto, oldTransaction);
                _transactionRepository.UpdateTransaction(oldTransaction);
                return true;
            }else{
                return false;
            }
        }
    }
}