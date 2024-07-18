using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using FluentValidation;

namespace Application.Activities
{
    public class Create
    {
        public class Command : IRequest
        {
            public Domain.Activity Activity { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Activity).SetValidator(new ActivityValidator());
            }
        }
        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;

            public Handler(DataContext Context)
            {
                _context = Context;
            }
            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                 _context.Activities.Add(request.Activity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
