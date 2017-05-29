using System;
using System.Collections.Generic;
using System.Text;

namespace Swastika.UI.Base.Extensions.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Extension
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
        /// <summary>
        /// Gets or sets the ulr.
        /// </summary>
        /// <value>
        /// The ulr.
        /// </value>
        public string Ulr { get; set; }
        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        /// <value>
        /// The author.
        /// </value>
        public string Author { get; set; }
        /// <summary>
        /// Gets or sets the installed date time.
        /// </summary>
        /// <value>
        /// The installed date time.
        /// </value>
        public string InstalledDateTime { get; set; }
    }
}
