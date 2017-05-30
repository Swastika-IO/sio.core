namespace Swastika.Extension.Customer.Application.EventSourcedNormalizers
{
    public class CustomerHistoryData
    {
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
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }
        /// <summary>
        /// Gets or sets the birth date.
        /// </summary>
        /// <value>
        /// The birth date.
        /// </value>
        public string BirthDate { get; set; }
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