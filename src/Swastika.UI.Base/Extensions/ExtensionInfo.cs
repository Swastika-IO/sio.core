using System.Reflection;
using System.Linq;

namespace Swastika.UI.Base.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public class ExtensionInfo
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the assembly.
        /// </summary>
        /// <value>
        /// The assembly.
        /// </value>
        public Assembly Assembly { get; set; }

        /// <summary>
        /// Gets the short name.
        /// </summary>
        /// <value>
        /// The short name.
        /// </value>
        public string ShortName
        {
            get
            {
                return Name.Split('.').Last();
            }
        }

        /// <summary>
        /// Gets or sets the absolute path.
        /// </summary>
        /// <value>
        /// The absolute path.
        /// </value>
        public string AbsolutePath { get; set; }
    }
}
