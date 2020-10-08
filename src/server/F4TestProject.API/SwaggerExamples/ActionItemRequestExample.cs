using F4TestProject.API.Models;
using Swashbuckle.AspNetCore.Filters;
using System;

namespace F4TestProject.API.SwaggerExamples
{
    public class ActionItemRequestExample : IExamplesProvider<ActionItemRequest>
    {
        public ActionItemRequest GetExamples() => new ActionItemRequest()
        {
            Description = "Some action item description",
            Duration = TimeSpan.Parse("10:40:00"),
            ImageLink = @"https://host/imgname.png",
            StartDate = DateTime.Parse("10-10-2020"),
            Title = "Action name"
        };
    }
}
