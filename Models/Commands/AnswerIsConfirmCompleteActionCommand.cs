using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramSimpleBot.Models.Dictionaries;
using TelegramSimpleBot.Models.Helpers;

namespace TelegramSimpleBot.Models.Commands
{
    public class AnswerIsConfirmCompleteActionCommand : Command
    {
        public override string Name => "/conf";

        public override void Execute(Message message, TelegramBotClient client)
        {
            var answer = message.Text;
            bool? isConfirm = null;

            if (string.Compare(answer, "Ez4 ENCE!") == 0) isConfirm = true;

            //Просто голосовалка, когда проголосуют тогда можно его обнулять
            if (isConfirm.HasValue && isConfirm.Value)
            {
                client.SendTextMessageAsync(message.Chat.Id, MessageDictionary.UserCompleteActionMessage,
                   replyMarkup: InlineKeyBoardButtonBotHelper.GetInlineKeyBoardButtonForConfirmComplete());

                //client.EditMessageReplyMarkupAsync(message.Chat.Id, 1578,
                //    replyMarkup: InlineKeyBoardButtonBotHelper.GetInlineKeyBoardButtonForConfirmComplete());
            }
        }
    }
}