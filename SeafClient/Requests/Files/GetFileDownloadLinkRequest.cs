﻿using SeafClient.Types;
using System;
using System.Net;
using System.Net.Http;

namespace SeafClient.Requests.Files
{
    /// <summary>
    /// Return a download link for the given file
    /// </summary>
    public class GetFileDownloadLinkRequest : SessionRequest<string>
    {
        public string LibraryId { get; set; }

        public string Path { get; set; }

        public int Reuse { get; set; }

        public override string CommandUri
        {
            get { return String.Format("api2/repos/{0}/file/?p={1}&reuse={2}", LibraryId, WebUtility.UrlEncode(Path),Reuse); }
        }

        public GetFileDownloadLinkRequest(string authToken, string libraryId, string path, bool reuseableLink) : base(authToken)
        {
	        LibraryId = libraryId;
	        Path = path;

	        if (!Path.StartsWith("/"))
		        Path = "/" + Path;

	        Reuse = reuseableLink ? 1 : 0;
        }

        public GetFileDownloadLinkRequest(string authToken, string libraryId, string path)
            : base(authToken)
        {
            LibraryId = libraryId;
            Path = path;

            if (!Path.StartsWith("/"))
                Path = "/" + Path;
        }

        public override SeafError GetSeafError(HttpResponseMessage msg)
        {
            switch (msg.StatusCode)
            {
                case HttpStatusCode.NotFound:
                    return new SeafError(msg.StatusCode, SeafErrorCode.FileNotFound);                    
                case HttpStatusCode.BadRequest:
                    return new SeafError(msg.StatusCode, SeafErrorCode.PathDoesNotExist);                    
                default:
                    return base.GetSeafError(msg);
            }
        }

        public override async System.Threading.Tasks.Task<string> ParseResponseAsync(HttpResponseMessage msg)
        {
            string content = await msg.Content.ReadAsStringAsync();
            return content.Trim('\"');
        }
    }
}
