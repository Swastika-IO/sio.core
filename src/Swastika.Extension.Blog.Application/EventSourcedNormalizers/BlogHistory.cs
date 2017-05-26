//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Swastika.Domain.Core.Events;
//using Newtonsoft.Json;

//namespace Swastika.Extension.Blog.Application.EventSourcedNormalizers
//{
//    public class BlogHistory
//    {
//        private const string CONST_MESSAGE_TYPE_CUSTOMER_REGISTERED_EVENT = "BlogRegisteredEvent";
//        private const string CONST_MESSAGE_TYPE_CUSTOMER_UPDATED_EVENT = "BlogUpdatedEvent";
//        private const string CONST_MESSAGE_TYPE_CUSTOMER_REMOVED_EVENT = "BlogRemovedEvent";

//        public static IList<BlogHistoryData> HistoryData { get; set; }

//        public static IList<BlogHistoryData> ToJavaScriptBlogHistory(IList<StoredEvent> storedEvents)
//        {
//            HistoryData = new List<BlogHistoryData>();
//            BlogHistoryDeserializer(storedEvents);

//            var sorted = HistoryData.OrderBy(c => c.When);
//            var list = new List<BlogHistoryData>();
//            var last = new BlogHistoryData();

//            foreach (var change in sorted)
//            {
//                var jsSlot = new BlogHistoryData
//                {
//                    Id = change.Id == Guid.Empty.ToString() || change.Id == last.Id
//                        ? ""
//                        : change.Id,
//                    Name = string.IsNullOrWhiteSpace(change.Name) || change.Name == last.Name
//                        ? ""
//                        : change.Name,
//                    Email = string.IsNullOrWhiteSpace(change.Email) || change.Email == last.Email
//                        ? ""
//                        : change.Email,
//                    BirthDate = string.IsNullOrWhiteSpace(change.BirthDate) || change.BirthDate == last.BirthDate
//                        ? ""
//                        : change.BirthDate.Substring(0,10),
//                    Action = string.IsNullOrWhiteSpace(change.Action) ? "" : change.Action,
//                    When = change.When,
//                    Who = change.Who
//                };

//                list.Add(jsSlot);
//                last = change;
//            }
//            return list;
//        }

//        private static void BlogHistoryDeserializer(IEnumerable<StoredEvent> storedEvents)
//        {
//            foreach (var e in storedEvents)
//            {
//                var slot = new BlogHistoryData();
//                dynamic values;

//                switch (e.MessageType)
//                {
//                    case CONST_MESSAGE_TYPE_CUSTOMER_REGISTERED_EVENT:
//                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
//                        slot.BirthDate = values["BirthDate"];
//                        slot.Email = values["Email"];
//                        slot.Name = values["Name"];
//                        slot.Action = "Registered";
//                        slot.When = values["Timestamp"];
//                        slot.Id = values["Id"];
//                        slot.Who = e.User;
//                        break;
//                    case CONST_MESSAGE_TYPE_CUSTOMER_UPDATED_EVENT:
//                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
//                        slot.BirthDate = values["BirthDate"];
//                        slot.Email = values["Email"];
//                        slot.Name = values["Name"];
//                        slot.Action = "Updated";
//                        slot.When = values["Timestamp"];
//                        slot.Id = values["Id"];
//                        slot.Who = e.User;
//                        break;
//                    case CONST_MESSAGE_TYPE_CUSTOMER_REMOVED_EVENT:
//                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
//                        slot.Action = "Removed";
//                        slot.When = values["Timestamp"];
//                        slot.Id = values["Id"];
//                        slot.Who = e.User;
//                        break;
//                }
//                HistoryData.Add(slot);
//            }
//        }
//    }
//}