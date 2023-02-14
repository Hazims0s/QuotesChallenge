using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using Application.DTOs.QuotesDTOs;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Quotes.Queries
{
    public class GetRandomQuote
    {
         public class Query : IRequest<Result<QuoteDTO>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<QuoteDTO>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;

            }
            public async Task<Result<QuoteDTO>> Handle(Query request, CancellationToken cancellationToken)
            {

                var quote = await _context.Quotes.OrderBy(r => Guid.NewGuid()).FirstOrDefaultAsync(cancellationToken);
                return Result<QuoteDTO>.Success(_mapper.Map<QuoteDTO>(quote));
            }
        }
    }
}