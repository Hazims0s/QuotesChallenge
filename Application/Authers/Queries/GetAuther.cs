using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using Application.DTOs.AutherDTOs;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Authers.Queries
{
    public class GetAuther
    {
        public class Query : IRequest<Result<AutherDTO>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<AutherDTO>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;

            }
            public async Task<Result<AutherDTO>> Handle(Query request, CancellationToken cancellationToken)
            {

                var auther = await _context.Authers.FindAsync(request.Id);
                return Result<AutherDTO>.Success(_mapper.Map<AutherDTO>(auther));
            }
        }
    }
}