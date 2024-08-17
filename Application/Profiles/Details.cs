using Application.Core;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Profiles
{
    public class Details
    {
        public class Query : IRequest<Result<AttendeesProfile>>
        {
            public string UserName { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<AttendeesProfile>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
        private readonly IUserAccessor _userAccessor;
            public Handler(DataContext context, IMapper mapper, IUserAccessor userAccessor)
            {
            _userAccessor = userAccessor;
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<AttendeesProfile>> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.ProjectTo<AttendeesProfile>(_mapper.ConfigurationProvider,
                 new {currentUsername = _userAccessor.GetUsername()})
                    .SingleOrDefaultAsync(x => x.UserName == request.UserName);

                if (user == null) return null;

                return Result<AttendeesProfile>.Success(user);
            }

       
        }
    }
}
