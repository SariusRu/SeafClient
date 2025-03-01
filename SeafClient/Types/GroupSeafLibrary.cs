using System;
using Newtonsoft.Json;
using SeafClient.Converters;

namespace SeafClient.Types;

public class GroupSeafLibrary
{
    [JsonProperty("repo_id")]
    public string RepoId { get; set; }

    [JsonProperty("repo_name")]
    public string RepoName { get; set; }

    [JsonProperty("mtime")]
    public DateTime? Mtime { get; set; }

    [JsonProperty("last_modified")]
    public DateTime? LastModified { get; set; }

    [JsonConverter(typeof(SeafPermissionConverter))]
    public virtual SeafPermission Permission { get; set; }

    [JsonProperty("size")]
    public long? Size { get; set; }

    [JsonProperty("encrypted")]
    public bool? Encrypted { get; set; }

    [JsonProperty("is_admin")]
    public bool? IsAdmin { get; set; }

    [JsonProperty("owner_email")]
    public string OwnerEmail { get; set; }

    [JsonProperty("owner_name")]
    public string OwnerName { get; set; }

    [JsonProperty("owner_contact_email")]
    public string OwnerContactEmail { get; set; }

    [JsonProperty("modifier_email")]
    public string ModifierEmail { get; set; }

    [JsonProperty("modifier_name")]
    public string ModifierName { get; set; }

    [JsonProperty("modifier_contact_email")]
    public string ModifierContactEmail { get; set; }

    [JsonProperty("starred")]
    public bool? Starred { get; set; }
}