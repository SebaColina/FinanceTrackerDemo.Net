using Microsoft.AspNetCore.Mvc;
using FinanceTrackerBackend.Services;

namespace FinanceTrackerBackend.Controllers
{
    [ApiController]
    [Route("api/Transactions")]  // This sets the base route for the controller
    public class FinanceTrackerController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public FinanceTrackerController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        // GET: api/Transactions
        [HttpGet]  // This action will respond to GET requests at "api/Transactions"
        public ActionResult<IEnumerable<TransactionDto>> GetTransactions()
        {
            var transactions = _transactionService.GetAllTransactions();
            return Ok(transactions);
        }

        // GET: api/Transactions/{id}
        [HttpGet("{id}")]  // This action will respond to GET requests at "api/transaction/{id}"
        public ActionResult<TransactionDto> GetTransactionById(int id)
        {
            var transaction = _transactionService.GetTransactionById(id);
            if (transaction == null)
            {
                return NotFound();
            }
            return Ok(transaction);
        }

        // PUT: api/Transactions
        [HttpPut]  // This action will respond to PUT requests at "api/Transactions"
        public ActionResult<bool> PutTransaction(TransactionDto transactionToUpdate)
        {
            var result = _transactionService.UpdateTransaction(transactionToUpdate);
            if(result == false){
                return NotFound();
            }
            return Ok(result);
        }

        // POST: api/Transactions
        [HttpPost]  // This action will respond to POST requests at "api/Transactions"
        public ActionResult<TransactionDto> CreateTransaction(TransactionDto transactionDto)
        {
            return _transactionService.CreateTransaction(transactionDto);
        }

        // DELETE: api/Transactions/{id}
        [HttpDelete("{id}")]  // This action will respond to DELETE requests at "api/transaction/{id}"
        public ActionResult<TransactionDto> DeleteTransaction(int id)
        {
            var transaction = _transactionService.DeleteTransaction(id);
            if (transaction == null)
            {
                return NotFound();
            }
            return Ok(transaction);
        }
    }
}
