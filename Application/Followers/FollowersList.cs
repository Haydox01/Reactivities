using Application.Core;
using Application.Interfaces;
using Application.Profiles;
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

namespace Application.Followers
{
    public class FollowersList
    {
        public class Query : IRequest<Result<List<AttendeesProfile>>>
        {
            public string Username { get; set; }
            public string Predicate { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<AttendeesProfile>>>
        {
            private readonly DataContext context;
            private readonly IMapper mapper;
            private readonly IUserAccessor userAccessor;

            public Handler(DataContext context, IMapper mapper, IUserAccessor userAccessor)
            {
                this.context = context;
                this.mapper = mapper;
                this.userAccessor = userAccessor;
            }

            public async Task<Result<List<AttendeesProfile>>> Handle(Query request, CancellationToken cancellationToken)
            {

                var profiles = new List<AttendeesProfile>();

                switch (request.Predicate)
                {
                    case "followers":

                        profiles = await context.UserFollowings
                            .Where(x => x.Target.UserName == request.Username)
                            .Select(u => u.Observer)
                            .ProjectTo<AttendeesProfile>(mapper.ConfigurationProvider, 
                            new {currentUsername = userAccessor.GetUsername()})
                            .ToListAsync();
                        break;

                    case "following":

                        profiles = await context.UserFollowings
                             .Where(x => x.Observer.UserName == request.Username)
                             .Select(u => u.Target)
                             .ProjectTo<AttendeesProfile>(mapper.ConfigurationProvider,
                               new {currentUsername = userAccessor.GetUsername()})
                             .ToListAsync();
                        break;

                }

                return Result<List<AttendeesProfile>>.Success(profiles);

            }

               
        }
    }
}
