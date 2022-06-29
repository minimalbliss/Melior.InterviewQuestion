using Melior.InterviewQuestion.Data;
using Melior.InterviewQuestion.Types;
using System.Configuration;

namespace Melior.InterviewQuestion.Services
{
    public class AccountService : IAccountService
    {
        private const string DataStoreTypeKey = "DataStoreType";
        private const string BackupType = "Backup";
        private readonly IAccountDataStore _accountDataStore = null;

        public AccountService()
        {
            string _dataStoreType = ConfigurationManager.AppSettings[DataStoreTypeKey];
            _accountDataStore = _dataStoreType switch
            {
                BackupType => new BackupAccountDataStore(),
                _ => new AccountDataStore(),
            };
        }

        public Account Get(string accountNumber)
        {
            return _accountDataStore.GetAccount(accountNumber);
        }

        public void Update(Account account)
        {
            _accountDataStore.UpdateAccount(account);
        }
    }
}
