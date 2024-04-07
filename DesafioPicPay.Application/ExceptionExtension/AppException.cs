namespace DesafioPicPay.Application.ExceptionExtension
{
    public class AppException(string message) : Exception(message)
    {
        public static void When(bool conditionThrow, string message)
        {
            if(conditionThrow)
                throw new AppException(message);
        } 
    }
}