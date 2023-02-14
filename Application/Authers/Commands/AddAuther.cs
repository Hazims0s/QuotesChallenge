using Application.Core;
using Application.DTOs.AutherDTOs;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Authers.Commands
{
    public class AddAuther
    {
        public class Command : IRequest<Result<Unit>>
        {
            public AddAutherDTO Auther { get; set; }
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
                _context.Authers.Add(_mapper.Map<Auther>(request.Auther));
                var result = await _context.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Failure("Failed To Add New Auther");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}