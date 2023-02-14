using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using Application.DTOs.AutherDTOs;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Authers.Queries
{
    public class GetListAuthers
    {

        public class Query : IRequest<Result<List<AutherDTO>>>
        {

        }

        public class Handler : IRequestHandler<Query, Result<List<AutherDTO>>>
        {
            private readonly DataContext _context;private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;

            }

            public async Task<Result<List<AutherDTO>>> Handle(Query request, CancellationToken cancellationToken)
            {
                return Result<List<AutherDTO>>.Success(_mapper.Map<List<AutherDTO>>( await _context.Authers.ToListAsync()));
            }
        }
    }

}
