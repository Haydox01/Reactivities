﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Security
{
    public class IsHostRequirement : IAuthorizationRequirement
    {
    }
    public class IHostRequirementHandler : AuthorizationHandler<IsHostRequirement>
    {
        private readonly DataContext dbContext;
        private readonly IHttpContextAccessor httpContextAccessor;

        public IHostRequirementHandler(DataContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            this.dbContext = dbContext;
            this.httpContextAccessor = httpContextAccessor;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsHostRequirement requirement)
        {
            var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return Task.CompletedTask;

            var activityId = Guid.Parse(httpContextAccessor.HttpContext?.Request.RouteValues
                .SingleOrDefault(x=> x.Key =="id").Value.ToString());

            var attendee = dbContext.ActivityAttendees
                .AsNoTracking()
                .SingleOrDefaultAsync(x=> x.AppUserId == userId && x.ActivityId== activityId).Result;

            if(attendee== null) return Task.CompletedTask;

            if (attendee.IsHost) context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }

    
}
