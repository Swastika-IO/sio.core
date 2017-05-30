using System;
using System.Collections.Generic;
using System.Linq;
using Swastika.Domain.Core.Events;
using Newtonsoft.Json;

namespace Swastika.Extension.Customer.Application.EventSourcedNormalizers
{
    public class CustomerHistory
    {
        /// <summary>
        /// The constant message type customer registered event{CC2D43FA-BBC4-448A-9D0B-7B57ADF2655C}
        /// </summary>
        private const string CONST_MESSAGE_TYPE_CUSTOMER_REGISTERED_EVENT = "CustomerRegisteredEvent";
        /// <summary>
        /// The constant message type customer updated event{CC2D43FA-BBC4-448A-9D0B-7B57ADF2655C}
        /// </summary>
        private const string CONST_MESSAGE_TYPE_CUSTOMER_UPDATED_EVENT = "CustomerUpdatedEvent";
        /// <summary>
        /// The constant message type customer removed event{CC2D43FA-BBC4-448A-9D0B-7B57ADF2655C}
        /// </summary>
        private const string CONST_MESSAGE_TYPE_CUSTOMER_REMOVED_EVENT = "CustomerRemovedEvent";

        /// <summary>
        /// Gets or sets the history data.
        /// </summary>
        /// <value>
        /// The history data.
        /// </value>
        public static IList<CustomerHistoryData> HistoryData { get; set; }

        /// <summary>
        /// To the java script customer history.
        /// </summary>
        /// <param name="storedEvents">The stored events.</param>
        /// <returns></returns>
        public static IList<CustomerHistoryData> ToJavaScriptCustomerHistory(IList<StoredEvent> storedEvents)
        {
            HistoryData = new List<CustomerHistoryData>();
            CustomerHistoryDeserializer(storedEvents);

            var sorted = HistoryData.OrderBy(c => c.When);
            var list = new List<CustomerHistoryData>();
            var last = new CustomerHistoryData();

            foreach (var change in sorted)
            {
                var jsSlot = new CustomerHistoryData
                {
                    Id = change.Id == Guid.Empty.ToString() || change.Id == last.Id
                        ? ""
                        : change.Id,
                    Name = string.IsNullOrWhiteSpace(change.Name) || change.Name == last.Name
                        ? ""
                        : change.Name,
                    Email = string.IsNullOrWhiteSpace(change.Email) || change.Email == last.Email
                        ? ""
                        : change.Email,
                    BirthDate = string.IsNullOrWhiteSpace(change.BirthDate) || change.BirthDate == last.BirthDate
                        ? ""
                        : change.BirthDate.Substring(0, 10),
                    Action = string.IsNullOrWhiteSpace(change.Action) ? "" : change.Action,
                    When = change.When,
                    Who = change.Who
                };

                list.Add(jsSlot);
                last = change;
            }
            return list;
        }

        /// <summary>
        /// Customers the history deserializer.
        /// </summary>
        /// <param name="storedEvents">The stored events.</param>
        private static void CustomerHistoryDeserializer(IEnumerable<StoredEvent> storedEvents)
        {
            foreach (var e in storedEvents)
            {
                var slot = new CustomerHistoryData();
                dynamic values;

                switch (e.MessageType)
                {
                    case CONST_MESSAGE_TYPE_CUSTOMER_REGISTERED_EVENT:
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.BirthDate = values["BirthDate"];
                        slot.Email = values["Email"];
                        slot.Name = values["Name"];
                        slot.Action = "Registered";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;
                    case CONST_MESSAGE_TYPE_CUSTOMER_UPDATED_EVENT:
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.BirthDate = values["BirthDate"];
                        slot.Email = values["Email"];
                        slot.Name = values["Name"];
                        slot.Action = "Updated";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;
                    case CONST_MESSAGE_TYPE_CUSTOMER_REMOVED_EVENT:
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.Action = "Removed";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;
                }
                HistoryData.Add(slot);
            }
        }
    }
}