using Hahn.Services.Contract.Contract;
using Hahn.Shared;
using Hahn.ticket.Entity;
using Microsoft.AspNetCore.Mvc;

namespace HahnWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ILogger<TicketController> _logger;
        private readonly ITicketRepository _ITicketRepository;
        public TicketController(ILogger<TicketController> logger,
                                  ITicketRepository iTicketRepository)
        {
            _logger = logger;
            _ITicketRepository = iTicketRepository;
        }

        [Route("GetAlTickets")]
        [HttpPost]
        public async Task<IActionResult> GetAlTickets([FromBody] Pager filter)
        {
            List<Ticket> liststudent = new List<Ticket>();
            liststudent = await _ITicketRepository.GetAllTickets(filter);
            return Ok(liststudent);
        }

        [HttpDelete("DeleteTicket/{Id}")]
        public IActionResult DeleteTicket(int Id)
        {
            var responce  =  _ITicketRepository.DeleteTicket(Id);
            return Ok(responce);
        }

        [Route("UpdateTicket")]
        [HttpPut]
        public IActionResult UpdateTicket([FromBody] Ticket ticket)
        {
            var responce =  _ITicketRepository.UpdateTicket(ticket);
            return Ok(responce);
        }

        [Route("AddTicket")]
        [HttpPost]
        public IActionResult AddTicket([FromBody] Ticket newticket)
        {
            var responce = _ITicketRepository.AddTicket(newticket);
            return Ok(responce);
        }
    }
}
