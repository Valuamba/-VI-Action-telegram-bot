using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramSimpleBot.SqlModelDI.SqlService
{
    public interface DbAutoProvideSqlCommand
    {
        void CompleteAction();

        string GetActionUser();

        void AddNewUser(string userName);

        void DeleteUser(string userName);

        bool ChekChoiseStatus(string userName);

        void BlockChoise(string userName);
    }
}
