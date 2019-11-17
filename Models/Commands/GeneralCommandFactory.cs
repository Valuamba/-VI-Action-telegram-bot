using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TelegramSimpleBot.Services;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.ReplyMarkups;
using System.Threading;

namespace TelegramSimpleBot.Models.Commands
{
    public class GeneralCommandFactory : IGeneralCommandFactory
    {
        private IUserData _userData;
        public GeneralCommandFactory(IUserData userData)
        {
            _userData = userData;
        }

        //public Action ActionCommand(QueueMessage message, TelegramBotClient client)
        //{
        //    return () =>
        //    {
        //        client.SendTextMessageAsync(message.ChatId, message.Text,
        //            replyMarkup: message.ReplyMarkup);
        //    };
        //}

        public void ActionCommand(QueueMessage message, TelegramBotClient client)
        {
                client.SendTextMessageAsync(message.ChatId, message.Text,
                    replyMarkup: message.ReplyMarkup);
         
        }
        //Выбор пользователя который будет рабоать
        public void AskIsSelectCommand(QueueMessage[] queMessage,Message message, TelegramBotClient client)
        {
            var answer = message.Text;
            bool? isAction = null;

            var acceptMessage = queMessage[0];
            var cancelMessage = queMessage[1];

            if (string.Compare(answer, "\uD83D\uDDD1Дело есть!") == 0) isAction = true;

            if (string.Compare(answer, "Пока все тихо...") == 0) isAction = false;

            //Добавить сюда базу данных и выбрать пользователя, который будет работать

            

            if (isAction.HasValue && isAction.Value)
            {
                client.SendTextMessageAsync(acceptMessage.ChatId, _userData.UserAction + acceptMessage.Text,
                    replyMarkup: acceptMessage.ReplyMarkup);

            }
            if (isAction.HasValue && !isAction.Value)
            {
                client.SendTextMessageAsync(cancelMessage.ChatId, cancelMessage.Text,
                    replyMarkup: cancelMessage.ReplyMarkup);
            }
        }
        //Подтверждение выполненой работы
        public void AnswerIsConfirmActionCommand(QueueMessage queMessage, Message message, TelegramBotClient client)
        {
            var answer = message.Text;
            bool? isConfirm = null;

            if (string.Compare(answer, "Ez4 ENCE!") == 0) isConfirm = true;

            //Просто голосовалка, когда проголосуют тогда можно его обнулять
            if (isConfirm.HasValue && isConfirm.Value)
            {
                //Delete KeyboardButton
                client.SendTextMessageAsync(queMessage.ChatId, queMessage.Text,
                    replyMarkup: queMessage.InlineReplyMarkup);
                //Edit InlineButtons
                //client.EditMessageReplyMarkupAsync(queMessage.ChatId, message.MessageId + 2,
                //        queMessage.InlineReplyMarkup as InlineKeyboardMarkup);

            }
        }
        //Подтверждение другим пользователем выполненой работы
        public void ConfirmCallBackCommand(QueueMessage queMessage,Message message, User user, TelegramBotClient client)
        {
            var userName = _userData.UserAction;
            //&& user.Username != _userData.UserAction
            if (_userData.IsChoise(user.Username)
                )
            {
                client.EditMessageTextAsync(queMessage.ChatId, message.MessageId, _userData.UserAction + queMessage.Text);
                _userData.CompleteAction();
            }
        }

        public void Change(QueueMessage queMessage, Message message, TelegramBotClient client)
        {
            if (string.Compare(queMessage.Text, message.Text) == 0)
            {
                client.EditMessageReplyMarkupAsync(queMessage.ChatId, message.MessageId,
                        queMessage.InlineReplyMarkup as InlineKeyboardMarkup);
            }
        }
    }
}