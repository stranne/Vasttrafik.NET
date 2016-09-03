using Newtonsoft.Json;
using Stranne.VasttrafikNET.ApiModels.JourneyPlanner.Enums;

namespace Stranne.VasttrafikNET.ApiModels.JourneyPlanner
{
    /// <summary>
    /// Note
    /// </summary>
    public class Note
    {
        /// <summary>
        /// Type of this note
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Severity of this note
        /// </summary>
        public NoteSeverity Severity { get; set; }

        /// <summary>
        /// Priority of the note which can be used to order the notes in the list
        /// </summary>
        public string Priority { get; set; }

        /// <summary>
        /// Note's message
        /// </summary>
        [JsonProperty(PropertyName = "$")]
        public string Message { get; set; }
    }
}