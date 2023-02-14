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

namespace Application.Authers.Commands
{
    public class UpdateAuther
    {
        public class Command :IRequest <Result<AutherDTO>>
        {
            public AutherDTO Auther { get; set; }
        }

        public class Handler : IRequestHandler<Command,Result<AutherDTO>>
        {
            private readonly DataContext _context;
           private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;

            }
            public async Task<Result<AutherDTO>> Handle(Command request, CancellationToken cancellationToken)
            {
                var auther = await _context.Authers.FindAsync(request.Auther.Id);
                if (auther==null) 
                    return Result<AutherDTO>.Failure("Auther Not Exists") ; 
                auther.Name = request.Auther.Name ;

                  var result=await _context.SaveChangesAsync() > 0;
                if (!result) return Result<AutherDTO>.Failure("Failed To Update Auther");
               
                 return Result<AutherDTO>.Success(_mapper.Map<AutherDTO>(auther));
            }
        }
    }
}