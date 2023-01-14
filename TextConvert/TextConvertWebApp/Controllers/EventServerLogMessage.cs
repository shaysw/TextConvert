using Newtonsoft.Json;

namespace TextConvertWebApp.Controllers
{
    internal class EventServerLogMessage
    {
        public static string eventServerUrl = "https://shayschwartzburd.com/EventServer/audit_log/post_event";

        [JsonProperty("sender")]
        public const string sender = "TextConverter";

        [JsonProperty("event_type")]
        public const string eventType = "LOG";

        [JsonProperty("application_id")]
        public const int applicationId = 116;

        [JsonProperty("value")]
        public string value;


        public EventServerLogMessage(string message)
        {
            this.value = message;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}