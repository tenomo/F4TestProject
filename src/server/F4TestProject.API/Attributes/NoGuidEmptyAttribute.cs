using System;
using System.ComponentModel.DataAnnotations;

namespace F4TestProject.API.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class NoGuidEmptyAttribute : RequiredAttribute
    {
        public override bool IsValid(Object value)
        {
            return value is Guid guid && guid != Guid.Empty;
        }
    }
}