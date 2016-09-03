using System;

namespace Stranne.VasttrafikNET.Exceptions
{
    /// <summary>
    /// Represents errors that occur on Västtrafik's servers
    /// </summary>
    public class ServerException : Exception
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <inheritdoc />
        public override string Message => $"{Name}: {Description}";
    }
}
