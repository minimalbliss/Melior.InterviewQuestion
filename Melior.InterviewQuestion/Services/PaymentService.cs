using Melior.InterviewQuestion.Data;
using Melior.InterviewQuestion.Types;

namespace Melior.InterviewQuestion.Services
{
    public class PaymentService : IPaymentService
    {
        public MakePaymentResult MakePayment(MakePaymentRequest request)
        {
                        

            

            MakePaymentResult result = new MakePaymentResult();

            switch (request.PaymentScheme)
            {
                case PaymentScheme.Bacs:
                    if (account == null)
                    {
                        result.Success = false;
                    }
                    else if (!account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.Bacs))
                    {
                        result.Success = false;
                    }
                    break;

                case PaymentScheme.FasterPayments:
                    if (account == null)
                    {
                        result.Success = false;
                    }
                    else if (!account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.FasterPayments))
                    {
                        result.Success = false;
                    }
                    else if (account.Balance < request.Amount)
                    {
                        result.Success = false;
                    }
                    break;

                case PaymentScheme.Chaps:
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
                    break;
            }

            if (result.Success)
            {
                account.Balance -= request.Amount;

                if (dataStoreType == "Backup")
                {
                    BackupAccountDataStore accountDataStore = new BackupAccountDataStore();
                    accountDataStore.UpdateAccount(account);
                }
                else
                {
                    AccountDataStore accountDataStore = new AccountDataStore();
                    accountDataStore.UpdateAccount(account);
                }
            }

            return result;
        }
    }
}
