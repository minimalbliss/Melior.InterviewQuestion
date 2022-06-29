using Melior.InterviewQuestion.Types;

public class BacsPaymentsTypeStrategy : IPaymentTypeStrategy
{
    public MakePaymentResult Pay(Account account, decimal amount)
    {
        MakePaymentResult result = new MakePaymentResult();

        if (account == null)
        {
            result.Success = false;
        }
        else if (!account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.Bacs))
        {
            result.Success = false;
        }

        return result;
    }
}
