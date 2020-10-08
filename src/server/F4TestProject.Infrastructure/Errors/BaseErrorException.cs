using System;

namespace F4TestProject.Infrastructure.Errors
{
    public abstract class BaseErrorException : InvalidOperationException
    {
        public virtual int ErrorCode { get; }
    }

    public class EntryNotFound
    {

    }

}
