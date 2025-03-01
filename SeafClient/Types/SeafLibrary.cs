using System;
using Newtonsoft.Json;
using SeafClient.Converters;

namespace SeafClient.Types
{
    /// <summary>
    ///     Represents a seafile library
    /// </summary>
    public class SeafLibrary
    {
        /// <summary>
        ///     The unique ID of this seafile library / repository
        /// </summary>
        public virtual string Id { get; set; }
        
        public virtual string Type { get; set; } 
        public virtual string Name { get; set; }

        public virtual string Owner { get; set; }
        
        [JsonProperty("owner_name")]
        public virtual string OwnerName { get; set; }
        
        [JsonProperty("owner_contact_email")]
        public virtual string OwnerContactEmail { get; set; }
        
        [JsonProperty("modifier_email")]
        public string ModifierEmail { get; set; }

        [JsonProperty("modifier_contact_email")]
        public string ModifierContactEmail { get; set; }

        [JsonProperty("modifier_name")]
        public string ModifierName { get; set; }

        [JsonProperty("mtime_relative")]
        public string MtimeRelative { get; set; }

        [JsonProperty("size")]
        public long? Size { get; set; }

        [JsonProperty("size_formatted")]
        public string SizeFormatted { get; set; }

        [JsonProperty("virtual")]
        public bool? Virtual { get; set; }

        [JsonProperty("root")]
        public string Root { get; set; }

        [JsonProperty("head_commit_id")]
        public string HeadCommitId { get; set; }

        [JsonProperty("version")]
        public int? Version { get; set; }

        [JsonProperty("salt")]
        public string Salt { get; set; }

        public virtual bool Encrypted { get; set; }

        [JsonConverter(typeof(SeafPermissionConverter))]
        public virtual SeafPermission Permission { get; set; }

        /// <summary>
        ///     Time of the last modification of this entry
        ///     (as UNIX timestamp)
        /// </summary>
        [JsonProperty("mtime")]
        [JsonConverter(typeof(SeafTimestampConverter))]
        public virtual DateTime? Timestamp { get; set; }

        [JsonProperty("desc")]
        public virtual string Description { get; set; }
    }
}