
using System.Collections.Generic;
using System.Security.Claims;

namespace Swastika.Domain.Core.Interfaces
{
    public interface IUser
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; }
        /// <summary>
        /// Determines whether this instance is authenticated.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance is authenticated; otherwise, <c>false</c>.
        /// </returns>
        bool IsAuthenticated();
        /// <summary>
        /// Gets the claims identity.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
