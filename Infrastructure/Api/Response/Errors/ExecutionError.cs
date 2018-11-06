using System;

namespace Infrastructure.Api.Response.Errors
{
    /// <summary>
    /// Denotes an Exception that has happened in the system
    /// </summary>
    public class ExecutionError
    {
        /// <summary>
        /// Exception message - without stack trace
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Deprecated - for Serialize
        /// </summary>
        [Obsolete("Do not use, for serializers only")]
        public ExecutionError()
        {

        }

        /// <summary>
        /// Initialise with Exception
        /// </summary>
        /// <param name="ex"></param>
        public ExecutionError(Exception ex)
        {
            Message = ex?.Message;
        }
    }
}