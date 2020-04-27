using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MeetupAPI.Filters
{
    public class NationalityFilter : Attribute, IAuthorizationFilter
    {
        private string[] _nationalites;
        public NationalityFilter(string nationalities)
        {
            _nationalites = nationalities.Split(",");
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var nationality = context.HttpContext.User.FindFirst(c => c.Type == "Nationality").Value;

            if (!_nationalites.Any(c => c == nationality))
            {
                context.Result = new StatusCodeResult(403);
            }
        }
    }
}
