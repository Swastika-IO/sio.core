namespace Swastika.Domain.Core.Models {

    /// <summary>
    /// History Data class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class HistoryData<T> where T : class {

        /// <summary>
        /// Gets or sets the action.
        /// </summary>
        /// <value>
        /// The action.
        /// </value>
        public string Action { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public T Model { get; set; }

        /// <summary>
        /// Gets or sets the when.
        /// </summary>
        /// <value>
        /// The when.
        /// </value>
        public string When { get; set; }

        /// <summary>
        /// Gets or sets the who.
        /// </summary>
        /// <value>
        /// The who.
        /// </value>
        public string Who { get; set; }
    }
}