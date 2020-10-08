using System;

namespace F4TestProject.Infrastructure.Errors
{
    public abstract class BaseErrorException : InvalidOperationException
    {
        protected BaseErrorException(string message) : base(message)
        {

        }
    }

    public class EntryNotFoundException : BaseErrorException
    {
        public EntryNotFoundException(string message) : base(message)
        {

        }
    }

    public class WrongPasswordException : BaseErrorException
    {
        public WrongPasswordException(string message) : base(message)
        {

        }
    }

    public class NotUniqueEntryException : BaseErrorException
    {
        public NotUniqueEntryException(string message) : base(message)
        {

        }
    }
}
