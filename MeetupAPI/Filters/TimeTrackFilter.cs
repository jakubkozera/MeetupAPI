using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MeetupAPI.Filters
{
    public class TimeTrackFilter : Attribute, IActionFilter
    {
        private Stopwatch _stopwatch;
        public void OnActionExecuted(ActionExecutedContext context)
        {
            _stopwatch.Stop();

            var milliseconds = _stopwatch.ElapsedMilliseconds;
            var action = context.ActionDescriptor.DisplayName;

            Debug.WriteLine($"Action [{action}], executed in: {milliseconds} milliseconds");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _stopwatch = new Stopwatch();
            _stopwatch.Start();
        }
    }
}
