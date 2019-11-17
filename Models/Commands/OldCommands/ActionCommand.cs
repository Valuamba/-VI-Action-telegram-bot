using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramSimpleBot.Models.Helpers;
using TelegramSimpleBot.Models.Dictionaries;

namespace TelegramSimpleBot.Models.Commands
{
    //Реализовать команду, которая будет появляться и писать утром и вечером
    public class ActionCommand : Command
    {
        public override string Name => "/action";

        public override void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;

            client.SendTextMessageAsync(chatId, MessageDictionary.MorningControlMessage,
                replyMarkup: KeyButtonBotHelper.GetKeyBoardForAction());
        }
    }
}