namespace moneyucab_portalweb_back.Services
{
    public class AuthMessageSenderOptions
    {
        public string SendGridUser { get; set; }
        public string SendGridKey { get; set; }
        public string ConfirmAccountTemplateID { get; set; }
    }
}
