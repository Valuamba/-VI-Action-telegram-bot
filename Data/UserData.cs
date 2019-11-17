using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TelegramSimpleBot.SqlModelDI.SqlService;
using TelegramSimpleBot.Services;

namespace TelegramSimpleBot.Data
{
    public class UserData : IUserData
    {
        public delegate void ManageUser(string user);

        private static DbAutoProvideSqlCommand _dbAutoProvideSql;
        public UserData(DbAutoProvideSqlCommand dbAutoProvideSqlCommand)
        {
            _dbAutoProvideSql = dbAutoProvideSqlCommand;
        }

        public string UserAction => _dbAutoProvideSql.GetActionUser();

        public bool IsChoise(string userName) => _dbAutoProvideSql.ChekChoiseStatus(userName);

        public void BlockChoise(string userName) => _dbAutoProvideSql.BlockChoise(userName);

        public void AddUserToChat(string userName) => _dbAutoProvideSql.AddNewUser(userName);

        public void DeleteUser(string userName) => _dbAutoProvideSql.DeleteUser(userName);

        public void CompleteAction() => _dbAutoProvideSql.CompleteAction();
    }
}