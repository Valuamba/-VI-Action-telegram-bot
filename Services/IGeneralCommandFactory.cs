using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramSimpleBot.Models;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramSimpleBot.Services
{
    public interface IGeneralCommandFactory
    {
        void ActionCommand(QueueMessage nexMessage, TelegramBotClient client);

        void AskIsSelectCommand(QueueMessage[] queMessage, Message message, TelegramBotClient client);

        void AnswerIsConfirmActionCommand(QueueMessage queMessage, Message message, TelegramBotClient client);

        void ConfirmCallBackCommand(QueueMessage queMessage, Message message, User user, TelegramBotClient client);

        void AddNewMemberCommand(User[] Users);

        void DeleteMemberCommand(User user);
    }
}
