namespace DesafioPicPay.Domain.ExceptionExtension
{
    public class DomainException(string message) : Exception(message)
    {
        public static void When(bool conditionThrow, string message)
        {
            if(conditionThrow)
                throw new DomainException(message);
        }
    }
}