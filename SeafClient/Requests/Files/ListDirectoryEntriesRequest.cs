using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using SeafClient.Types;

namespace SeafClient.Requests.Files
{
    /// <summary>
    /// Request to receive the contents of a directory
    /// </summary>
    public class SearchFilesRequest : SessionRequest<IList<SeafDirEntry>>
    {
        public string LibraryId { get; private set; }

        public String Path { get; private set; }
        public string Query { get; private set; }
        public override string CommandUri => $"api2/search/?q={Query}&search_repo={LibraryId}&search_path={Path}";

        public SearchFilesRequest(string authToken, string libraryId, string path, string query)
            : base(authToken)
        {
            if (authToken == null)
                throw new ArgumentNullException(nameof(authToken));
            if (libraryId == null)
                throw new ArgumentNullException(nameof(libraryId));
            if (path == null)
                throw new ArgumentNullException(nameof(path));
            if (query == null)
                throw new ArgumentNullException(nameof(query));

            LibraryId = libraryId;
            Path = path;

            if (!Path.StartsWith("/"))
                Path = "/" + Path;
            
            Query = query;
        }

        public override async System.Threading.Tasks.Task<IList<SeafDirEntry>> ParseResponseAsync(
            System.Net.Http.HttpResponseMessage msg)
        {
            var entries = await base.ParseResponseAsync(msg);

            // set the library id & path of the items              
            foreach (var entry in entries)
            {
                entry.LibraryId = LibraryId;

                // parent_dir is only sent when recursive was true
                if (entry.ParentDirectory == null)
                    entry.ParentDirectory = Path;

                if (!entry.ParentDirectory.EndsWith("/"))
                    entry.ParentDirectory += "/";
                entry.Path = entry.ParentDirectory + entry.Name;
            }

            return entries;
        }

        public override SeafError GetSeafError(HttpResponseMessage msg)
        {
            switch (msg.StatusCode)
            {
                case HttpStatusCode.NotFound:
                    return new SeafError(msg.StatusCode, SeafErrorCode.PathDoesNotExist);
                case (HttpStatusCode)440:
                    return new SeafError(msg.StatusCode, SeafErrorCode.EncryptedLibrary_PasswordNotProvided);
                default:
                    return base.GetSeafError(msg);
            }
        }
    }

    public enum DirEntryFilter
    {
        FilesAndDirectories,
        OnlyFiles,
        OnlyDirectories
    }
}