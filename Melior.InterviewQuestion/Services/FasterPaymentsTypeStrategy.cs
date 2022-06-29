using Melior.InterviewQuestion.Types;

public class FasterPaymentsTypeStrategy : IPaymentTypeStrategy
{
    public MakePaymentResult Pay(Account account, decimal amount)
    {
        MakePaymentResult result = new MakePaymentResult();

        if (account == null)
        {
            result.Success = false;
        }
        else if (!account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.FasterPayments))
        {
            result.Success = false;
        }
        else if (account.Balance < amount)
        {
            result.Success = false;
        }

        return result;
    }
}