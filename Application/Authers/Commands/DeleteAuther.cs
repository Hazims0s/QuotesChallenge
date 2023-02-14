using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using MediatR;
using Persistence;

namespace Application.Authers.Commands
{
    public class DeleteAuther
    {
        public class Command :IRequest <Result<Unit>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command,Result<Unit>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;

            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var auther = await _context.Authers.FindAsync(request.Id);
                if (auther==null) 
                    return Result<Unit>.Failure("Auther Not Exists") ; 
                  _context.Remove(auther) ;          
                  var result=await _context.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Failure("Failed To Delete Auther");
               
                 return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}