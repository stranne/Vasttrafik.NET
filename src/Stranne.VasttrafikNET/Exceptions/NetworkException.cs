using System;
using System.Net;

namespace Stranne.VasttrafikNET.Exceptions
{
    /// <summary>
    /// Represents errors that occur during communicating with Västtrafik's servers
    /// </summary>
    public class NetworkException : Exception
    {
        /// <summary>
        /// Http status code returned
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Message body, if any
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Uri of request
        /// </summary>
        public Uri RequestUri { get; set; }
    }
}
