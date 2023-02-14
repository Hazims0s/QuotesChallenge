
using Application.Core;
using Domain;
using MediatR;
using Persistence;
using Application.DTOs.QuotesDTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Application.Quotes.Queries
{
    public class GetQuoteByAuther
    {
        public class Query : IRequest<Result<List<QuoteDTO>>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<QuoteDTO>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;

            }
            public async Task<Result<List<QuoteDTO>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var quote = await _context.Quotes.Where(p=> p.AutherId==request.Id).ToListAsync(); 
                return Result<List<QuoteDTO>>.Success(_mapper.Map<List<QuoteDTO>>(quote));
            }
        }
    }
}