using SeafClient.Types;
using System.Collections.Generic;

namespace SeafClient.Requests.Libraries
{
    /// <summary>
    /// Request to list all libraries of the user owning the given authorization token
    /// </summary>
    public class LibrariesByGroupRequest : SessionRequest<IList<GroupSeafLibrary>>
    {
        private int id;
        public override string CommandUri => $"api/v2.1/groups/{id}/libraries/";

        public LibrariesByGroupRequest(string authToken, int id)
            : base(authToken)
        {
            this.id = id;
        }
    }
}
