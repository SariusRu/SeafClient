﻿using SeafClient.Types;
using System;

namespace SeafClient.Requests.Libraries
{
    /// <summary>
    /// Returns the library information for a given library id
    /// </summary>
    public class GetLibraryInfoRequest : SessionRequest<SeafLibraryInfo>
    {
        public string LibraryId { get; set; }

        public override string CommandUri
        {
            get { return String.Format("api2/repos/{0}/", LibraryId); }
        }

        public GetLibraryInfoRequest(string authToken, string libraryId)
            : base(authToken)
        {
            LibraryId = libraryId;
        }
    }
}
