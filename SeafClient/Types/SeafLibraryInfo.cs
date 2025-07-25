using Newtonsoft.Json;

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