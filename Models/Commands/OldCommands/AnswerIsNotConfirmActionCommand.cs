using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramSimpleBot.Models.Dictionaries;
using TelegramSimpleBot.Models.Helpers;

namespace TelegramSimpleBot.Models.Commands
{
    public class AnswerIsNotConfirmActionCommand : Command
    {
        public override string Name => "/nconfirm";

        public override void Execute(Message message, TelegramBotClient client)
        {
            client.SendTextMessageAsync(message.Chat.Id,"@Valuamba" + MessageDictionary.FailedActionMessage,
                replyMarkup: KeyButtonBotHelper.GetKeyBoardForUserCompleteAction());
        }
    }
}