﻿using Newtonsoft.Json;
using System.Net.Http;
using SeafClient.Types;

namespace SeafClient.Requests.UserAccountInfo
{
    /// <summary>
    /// Request to receive general account information of the user
    /// who owns the current session
    /// </summary>
    public class AccountInfoRequest : SessionRequest<AccountInfo>
    {
        public override string CommandUri
        {
            get { return "api2/account/info/"; }
        }

        public override SeafError GetSeafError(HttpResponseMessage msg)
        {
            switch(msg.StatusCode)
            {
                case System.Net.HttpStatusCode.Forbidden:
                    return new SeafError(msg.StatusCode, SeafErrorCode.InvalidToken);                    
                default:
                    return base.GetSeafError(msg);
            }
        }

        public AccountInfoRequest(string authToken)
            : base(authToken)
        {
            // --
        }
    }

    /// <summary>
    /// Describes the account info of a seafile account
    /// </summary>
    public class AccountInfo
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Institution { get; set; }
        public string Department { get; set; }        

        /// <summary>
        /// The space which the user's data consumes in bytes
        /// </summary>
        public long Usage { get; set; }

        /// <summary>
        /// The quota of the user in bytes
        /// If this is -2 then the user is not limited in space
        /// </summary>
        [JsonProperty("total")]
        public long Quota { get; set; }

        /// <summary>
        /// Returns if this user has no quota
        /// </summary>
        public bool HasUnlimitedSpace
        {
            get
            {
                return Quota == -2;
            }
        }
    }
}
