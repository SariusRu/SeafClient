using System;
using Newtonsoft.Json;
using SeafClient.Converters;

namespace SeafClient.Types
{
    /// <summary>
    ///     Represents a seafile library
    /// </summary>
    public class SeafLibraryInfo : SeafLibrary
    {
        [JsonProperty("file_count")]
        public long FileCount { get; set; }
    }
}