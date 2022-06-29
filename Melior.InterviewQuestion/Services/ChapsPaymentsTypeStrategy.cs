using Melior.InterviewQuestion.Types;

public class ChapsPaymentsTypeStrategy : IPaymentTypeStrategy
{
    public MakePaymentResult Pay(Account account, decimal amount)
    {
        MakePaymentResult result = new MakePaymentResult();

        if (account == null)
        {
            result.Success = false;
        }
        else if (!account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.Chaps))
        {
            result.Success = false;
        }
        else if (account.Status != AccountStatus.Live)
        {
            result.Success = false;
        }

        return result;
    }
}
