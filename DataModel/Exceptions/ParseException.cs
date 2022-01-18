using System;

namespace Ichosoft.DataModel.Exceptions
{
    /// <summary>
    /// Represents errors that occuring when parsing text.
    /// </summary>
    public class ParseException : Exception
    {
        public ParseException() : base()
        {
        }

        public ParseException(string message) : base(message)
        {
        }

        public ParseException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
