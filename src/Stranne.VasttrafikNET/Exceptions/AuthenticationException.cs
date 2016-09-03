using System;

namespace Stranne.VasttrafikNET.Exceptions
{
    /// <summary>
    /// Represents errors that occur on failed authentication with Västtrafik's servers. Verify key and secret are correct and that they have access to the API in question.
    /// </summary>
    public class AuthenticationException : Exception
    {
        /// <inheritdoc />
        public override string Message => "Authentication failed with Västtrafik's servers. Verify Key and Secret are correct and that the application has access to the API in question.";
    }
}
