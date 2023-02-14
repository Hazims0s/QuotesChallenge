using Application.Core;
using Application.DTOs.QuotesDTOs;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Quotes.Commands
{
    public class AddQuote
    {
        public class Command : IRequest<Result<Unit>>
        {
            public AddQuoteDTO Qoute { get; set; }
        }

        public class CommandValidator : AbstractValidator<Auther>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Name).NotEmpty();
            }
        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context; 
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;

            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            { 
                _context.Quotes.Add(  _mapper.Map<Quote>(request.Qoute));
                var result = await  _context.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Failure("Failed To Add New Qoute");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}