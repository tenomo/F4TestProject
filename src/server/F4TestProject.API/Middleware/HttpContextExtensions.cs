using F4TestProject.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace F4TestProject.API.Middleware
{
    public static class HttpContextExtensions
    {
        public static User GetUser(this HttpContext context)
        {
            return context.Items["Customer"] as User;
        }
    }
}
