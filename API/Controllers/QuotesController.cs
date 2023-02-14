using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.QuotesDTOs;
using Application.Quotes.Commands;
using Application.Quotes.Queries;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class QuotesController : BaseApiController
    {

        
        [HttpGet]
        public async Task<IActionResult> GetListQoutes(CancellationToken ct)
        {

            return HandelResult( await Mediator.Send(new GetQuotes.Query(),ct));
        }

        [HttpGet("Random")]
        public async Task<IActionResult> GetRandomQoute(CancellationToken ct)
        {

            return HandelResult(await Mediator.Send(new GetRandomQuote.Query(), ct));
        }
        [HttpGet("ByAuther/{id}")]
        public async Task<IActionResult> GetQouteByAuther(Guid id, CancellationToken ct)
        {

            return HandelResult(await Mediator.Send(new GetQuoteByAuther.Query { Id = id}, ct));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuote(Guid id, CancellationToken ct)
        {

            return HandelResult(await Mediator.Send(new GetQuote.Query{ Id = id}, ct));
        }

        [HttpPut("Edit/{id}")]
        public async Task<IActionResult> EditQuote(Guid id, UpdateQuoteDTO quote, CancellationToken ct)
        {
            quote.Id = id;
            await Mediator.Send(new UpdateQuote.Command { Quote = quote }, ct);
            return Ok();
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteQuote(Guid id, CancellationToken ct)
        {

            await Mediator.Send(new DeleteQuote.Command { Id = id }, ct);
            return Ok();
        }


        [HttpPost("Add")]
        public async Task<IActionResult> AddQuote(AddQuoteDTO qoute ,CancellationToken ct)
        {
           return HandelResult( await Mediator.Send(new AddQuote.Command{Qoute =qoute} ,ct));
            
        }
        
    }
}