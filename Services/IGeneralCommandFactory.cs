using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramSimpleBot.Models;
using Telegram.Bot;
namespace TelegramSimpleBot.Services
{
    public interface IGeneralCommandFactory
    {
        void ActionCommand(QueueMessage nexMessage, TelegramBotClient client);
    }
}
