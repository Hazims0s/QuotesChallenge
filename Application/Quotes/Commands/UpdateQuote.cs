using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using Application.DTOs.QuotesDTOs;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Quotes.Commands
{
    public class UpdateQuote
    {
        public class Command : IRequest<Result<QuoteDTO>>
        {
            public UpdateQuoteDTO Quote { set; get; }
        }


        public class Handler : IRequestHandler<Command, Result<QuoteDTO>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;

            }
            public async Task<Result<QuoteDTO>> Handle(Command request, CancellationToken cancellationToken)
            {
                var qoute = await _context.Quotes.FindAsync(request.Quote.Id);
                if (qoute == null)
                    return Result<QuoteDTO>.Failure("Quote Not Exists");
                qoute.Text = request.Quote.Text;

                var result = await _context.SaveChangesAsync() > 0;
                if (!result) return Result<QuoteDTO>.Failure("Failed To Update Quote");

                return Result<QuoteDTO>.Success(_mapper.Map<QuoteDTO>(qoute));

            }
        }
    }
}