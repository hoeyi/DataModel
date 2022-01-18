using System;

namespace Ichosoft.DataModel.Exceptions
{
    /// <summary>
    /// Represents errors that occuring when parsing text.
    /// </summary>
    public class ParseException : Exception
    {
        /// <summary>
        /// Creates a new instance of <see cref="ParseException"/>.
        /// </summary>
        /// <param name="message">The error message to describe the new exception.</param>
        /// <param name="innerException">The preceding exception to the new exception.</param>
        public ParseException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }
    }
}
