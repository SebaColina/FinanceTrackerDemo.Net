using Microsoft.AspNetCore.Mvc;
using FinanceTrackerBackend.Services;

namespace FinanceTrackerBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]  // This sets the base route for the controller
    public class FinanceTrackerController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public FinanceTrackerController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        // GET: api/FinanceTracker
        [HttpGet]  // This action will respond to GET requests at "api/FinanceTracker"
        public ActionResult<IEnumerable<TransactionDto>> GetFinanceTracker()
        {
            var transactions = new List<TransactionDto>(); // _transactionService.GetTransactions(); Assume this gets populated
            return Ok(transactions);
        }

        // GET: api/financeTracker/{id}
        [HttpGet("{id}")]  // This action will respond to GET requests at "api/financeTracker/{id}"
        public ActionResult<TransactionDto> GetFinanceTrackerById(int id)
        {
            var forecast = new TransactionDto(); // Assume this is retrieved by id
            if (forecast == null)
            {
                return NotFound();
            }
            return Ok(forecast);
        }

        // POST: api/financeTracker
        [HttpPost]  // This action will respond to POST requests at "api/financeTracker"
        public ActionResult<TransactionDto> CreateFinanceTracker(TransactionDto forecastDto)
        {
            // Assume this creates a new forecast and returns it
            return CreatedAtAction(nameof(GetFinanceTrackerById), new { id = forecastDto.Id }, forecastDto);
        }
    }
}
