namespace moneyucab_portalweb_back.Models
{
    public class ApplicationSettings
    {
        // Properties for JWT Token
        public string JWT_Secret { get; set; }
        public string Client_URL { get; set; }
        public string Token_ExpiredTime { get; set; }

        // Properties for SendGrid
        public string SendGridUser { get; set; }
        public string SendGridKey { get; set; }
        public string ConfirmAccountTemplateID { get; set; }
    }
}
