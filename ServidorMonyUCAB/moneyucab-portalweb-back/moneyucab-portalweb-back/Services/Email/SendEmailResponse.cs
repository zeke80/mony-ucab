namespace moneyucab_portalweb_back.Comandos.ComandosService.Utilidades.Email
{
    public class SendEmailResponse
    {
        public bool Successful => ErrorMsg == null;
        public string ErrorMsg { get; set; }
    }
}
