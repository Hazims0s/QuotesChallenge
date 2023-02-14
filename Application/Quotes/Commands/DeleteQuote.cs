using Application.Core;
using MediatR;
using Persistence;

namespace Application.Quotes.Commands
{
    public class DeleteQuote
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
                var quote = await _context.Quotes.FindAsync(request.Id);
                if (quote==null) 
                    return Result<Unit>.Failure("Qoute Not Exists") ; 
                  _context.Remove(quote) ;          
                  var result=await _context.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Failure("Failed To Delete Qoute");
               
                 return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}