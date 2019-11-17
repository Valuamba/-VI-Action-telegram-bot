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
    public class AskIsControllCommand : Command
    {
        public override string Name => "/ask";
         
        public override void Execute(Message message, TelegramBotClient client)
        {
            var answer = message.Text;
            bool? isAction = null;

            if (string.Compare(answer, "\uD83D\uDDD1Дело есть!") == 0) isAction = true;

            if (string.Compare(answer, "Пока все тихо...") == 0) isAction = false;

            //Добавить сюда базу данных и выбрать пользователя, который будет работать
            
            if (isAction.HasValue && isAction.Value)
            {
                client.SendTextMessageAsync(message.Chat.Id, "@Valuamba" + MessageDictionary.ActionReplyMessage, 
                    replyMarkup: KeyButtonBotHelper.GetKeyBoardForUserCompleteAction());
                
            }
            if (isAction.HasValue && !isAction.Value)
            {
                client.SendTextMessageAsync(message.Chat.Id, MessageDictionary.CancelReplyMessage,
                    replyMarkup: KeyButtonBotHelper.GetRemoveKeyboard());
            }
        }
    }
}