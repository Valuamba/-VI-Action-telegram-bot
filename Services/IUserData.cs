using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramSimpleBot.Services
{
    public interface IUserData
    {
        string UserAction { get; }

        bool IsChoise(string userName);

        void BlockChoise(string userName);

        void AddUserToChat(string userName);

        void DeleteUser(string userName);

        void CompleteAction();
    }
}
