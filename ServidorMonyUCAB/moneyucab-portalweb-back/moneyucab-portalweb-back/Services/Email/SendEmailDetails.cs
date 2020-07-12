using Newtonsoft.Json;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Utilidades.Email
{
    public class SendEmailDetails
    {
        public string FromName { get; set; }
        public string FromEmail { get; set; }
        public string ToEmail { get; set; }
        public string ToName { get; set; }
        public string Subject { get; set; }
        public string TemplateID { get; set; }
        public EmailData TemplateData { get; set; }
    }

    public class EmailData
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("URL")]
        public string URL { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("buttonTitle")]
        public string ButtonTitle { get; set; }
    }
}
