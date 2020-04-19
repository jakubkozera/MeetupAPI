using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace MeetupAPI.Authorization
{
    public class MinimumAgeHandler : AuthorizationHandler<MinimumAgeRequirement>
    {
        private readonly ILogger<MinimumAgeHandler> _logger;

        public MinimumAgeHandler(ILogger<MinimumAgeHandler> logger)
        {
            _logger = logger;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAgeRequirement requirement)
        {
            var userEmail = context.User.FindFirst(c => c.Type == ClaimTypes.Name).Value;
            var dateOfBirth = DateTime.Parse(context.User.FindFirst(c => c.Type == "DateOfBirth").Value);

            _logger.LogInformation($"Handling minimum age requirement fo: {userEmail}. [dateOfBirth: {dateOfBirth}]");

            if (dateOfBirth.AddYears(requirement.MinimumAge) <= DateTime.Today)
            {
                _logger.LogInformation("Access granted");
                context.Succeed(requirement);
            }
            else
            {
                _logger.LogInformation("Access denied");

            }

            return Task.CompletedTask;
        }
    }
}
