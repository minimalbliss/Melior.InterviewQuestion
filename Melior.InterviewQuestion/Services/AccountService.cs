using Melior.InterviewQuestion.Data;
using Melior.InterviewQuestion.Types;
using System.Configuration;

namespace Melior.InterviewQuestion.Services
{
    public class AccountService : IAccountService
    {
        private const string DataStoreType = "DataStoreType";

        public Account Get()
        {
            Account account = null;
            BackupAccountDataStore accountDataStore = new BackupAccountDataStore();

            string  dataStoreType = ConfigurationManager.AppSettings[DataStoreType];

            switch (dataStoreType)
            {
                case "Backup":
                    account = accountDataStore.GetAccount(request.DebtorAccountNumber);
                    break;
                default:
                    account = accountDataStore.GetAccount(request.DebtorAccountNumber);
                    break;
                    
            }
        }
    }
}
