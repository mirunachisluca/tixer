using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tixer.DTOs;
using Tixer.Helpers;
using Tixer.Models;
using Tixer.Services;

namespace Tixer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketsService _ticketsService;
        private readonly IMapper _mapper;

        public TicketsController(ITicketsService ticketsService, IMapper mapper)
        {
            _ticketsService = ticketsService ?? throw new ArgumentNullException(nameof(ticketsService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("{id}", Name = "GetTicket")]
        public ActionResult<TicketDto> GetTicket(string id)
        {
            var ticket = _ticketsService.GetTicket(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<TicketDto>(ticket));
        }

        [HttpGet(Name = "GetAllTickets")]
        public ActionResult<IEnumerable<TicketDto>> GetAllTickets()
        {
            var tickets = _ticketsService.GetTickets();

            return Ok(_mapper.Map<IEnumerable<TicketDto>>(tickets));
        }

        [HttpPost(Name = "CreateTicket")]
        public ActionResult CreateTicket(TicketToInsertDto ticket)
        {
            var ticketEntity = _mapper.Map<Ticket>(ticket);

            ticketEntity.PublicId = IdGenerator.Generate();

            _ticketsService.AddTicket(ticketEntity);

            var ticketToReturn = _mapper.Map<TicketDto>(ticketEntity);

            return CreatedAtRoute("GetTicket", new { id = ticketEntity.PublicId }, ticketToReturn);
        }

        [HttpPut("{id}", Name = "UpdateTicket")]
        public ActionResult UpdateTicket(string id, [FromBody] TicketToUpdateDto ticket)
        {
            var ticketEntity = _ticketsService.GetTicket(id);

            if (ticketEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(ticket, ticketEntity);

            _ticketsService.UpdateTicket(ticketEntity);

            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteTicket")]
        public ActionResult DeleteTicket(string id)
        {
            var ticketEntity = _ticketsService.GetTicket(id);

            if (ticketEntity == null)
            {
                return NotFound();
            }

            _ticketsService.DeleteTicket(ticketEntity);

            return NoContent();
        }
    }
}
