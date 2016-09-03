using System;
using System.Collections.Generic;

namespace Stranne.VasttrafikNET.Exceptions
{
    /// <summary>
    /// Represents errors that occur when preparing message for Västtrafik's servers with a request that missing required parameters
    /// </summary>
    public class MissingRequiredParameterException : Exception
    {
        /// <summary>
        /// List of the property names of missing required parameters
        /// </summary>
        public IEnumerable<string> MissingParameters { get; }

        /// <summary>
        /// Create a new exception
        /// </summary>
        /// <param name="missingParameters">List of the property names of missing required parameters</param>
        public MissingRequiredParameterException(IEnumerable<string> missingParameters)
        {
            MissingParameters = missingParameters;
        }

        /// <inheritdoc />
        public override string Message => $"Missing the required parameters: {string.Join(", ", MissingParameters)}";
    }
}
