using System.Collections.Generic;

namespace Swastika.UI.Base.Extensions {

    /// <summary>
    ///
    /// </summary>
    public class ExtensionManager {

        /// <summary>
        /// Initializes the <see cref="ExtensionManager" /> class.
        /// </summary>
        static ExtensionManager() {
            Extensions = new List<ExtensionInfo>();
        }

        /// <summary>
        /// Gets or sets the extensions.
        /// </summary>
        /// <value>
        /// The extensions.
        /// </value>
        public static IList<ExtensionInfo> Extensions { get; set; }

        /// <summary>
        /// Gets or sets the relative path.
        /// </summary>
        /// <value>
        /// The relative path.
        /// </value>
        public static string RelativePath { get; set; }
    }
}