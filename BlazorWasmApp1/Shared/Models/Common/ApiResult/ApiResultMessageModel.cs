
using System;

using Newtonsoft.Json;

namespace BlazorWasmApp1.Shared.Models.Common.ApiResult
{
    /// <summary>
    /// Represents a message about the current result.
    /// </summary>
    [Serializable]
    public class ApiResultMessageModel : IApiResultMessageModel
    {
        /// <summary>
        /// Represents the severity or level of this message.
        /// </summary>
        [JsonProperty("messageType")]
        public ApiResultMessageTypeEnum MessageType { get; set; }

        /// <summary>
        /// Represents a code for this message; Usually will equate to a HttpStatusCode, but could be different.
        /// </summary>
        [JsonProperty("code")]
        public int? Code { get; set; }

        /// <summary>
        /// Friendly message about this message.
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// Source that caused this message.
        /// </summary>
        [JsonProperty("source")]
        public string Source { get; set; }

        ///// <summary>
        ///// UnhandledException
        ///// </summary>
        //[JsonProperty("unhandledException")]
        //public Exception UnhandledException { get; set; }

        // TODO
        //public bool ShouldSerializeUnhandledException() =>
        //    !StaticServices.HostingEnvironment.IsProduction();
    }

    /// <summary>
    /// Represents a message about the current result.
    /// </summary>
    public interface IApiResultMessageModel
    {
        /// <summary>
        /// Represents the severity or level of this message.
        /// </summary>
        ApiResultMessageTypeEnum MessageType { get; set; }

        /// <summary>
        /// Represents a code for this message; Usually will equate to a HttpStatusCode, but could be different.
        /// </summary>
        int? Code { get; set; }

        /// <summary>
        /// Friendly message about this message.
        /// </summary>
        string Message { get; set; }

        /// <summary>
        /// Source that caused this message.
        /// </summary>
        string Source { get; set; }

        ///// <summary>
        ///// UnhandledException
        ///// </summary>
        //Exception UnhandledException { get; set; }

        //bool ShouldSerializeUnhandledException();
    }
}
