namespace DesafioPicPay.Application.Services.Responses
{
    public record AuthorizerTransactionResponse
    {
        public string Message { get; private set; } = string.Empty;

        public bool IsAuthorized()
        {
            return Message.Equals("Autorizado");
        }        
    }
}