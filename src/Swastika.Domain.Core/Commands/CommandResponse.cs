using System;

namespace Swastika.Domain.Core.Commands
{
    public class CommandResponse
    {
        /// <summary>
        /// The ok{CC2D43FA-BBC4-448A-9D0B-7B57ADF2655C}
        /// </summary>
        public static CommandResponse Ok = new CommandResponse { Success = true };
        /// <summary>
        /// The fail{CC2D43FA-BBC4-448A-9D0B-7B57ADF2655C}
        /// </summary>
        public static CommandResponse Fail = new CommandResponse { Success = false };

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandResponse" /> class.
        /// </summary>
        /// <param name="success">if set to <c>true</c> [success].</param>
        public CommandResponse(bool success = false)
        {
            Success = success;
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="CommandResponse" /> is success.
        /// </summary>
        /// <value>
        ///   <c>true</c> if success; otherwise, <c>false</c>.
        /// </value>
        public bool Success { get; private set; }
    }
}