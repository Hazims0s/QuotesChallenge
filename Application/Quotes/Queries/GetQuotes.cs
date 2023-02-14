using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using Application.DTOs.QuotesDTOs;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Quotes.Queries
{
    public class GetQuotes
    {

        public class Query : IRequest<Result<List<QuoteDTO>>>
        {

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
                var quotes =_mapper.Map<List<QuoteDTO>>( await _context.Quotes.Include(p=>p.Auther).ToListAsync());
                return Result<List<QuoteDTO>>.Success(quotes);
            }
        }
    }

}
