using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot.Types;
using TelegramSimpleBot.Models.Dictionaries;

namespace TelegramSimpleBot.Models.Helpers
{
    public class QueueMessageBotHelper
    {
        private readonly Message _message;

        private long ChatId => _message.Chat.Id;

        private int MessageId => _message.MessageId;

        public QueueMessageBotHelper(Message message)
        {
            _message = message;
        }

        //Morning controll
        public QueueMessage MorningControlMessage =>
            new QueueMessage(ChatId, MessageId)
            {
                Text = MessageDictionary.MorningControlMessage,
                ReplyMarkup = KeyButtonBotHelper.GetKeyBoardForAction()
            };

        //Find user who will complete task
        public QueueMessage UserActionMessage =>
            new QueueMessage(ChatId, MessageId)
            {
                Text = MessageDictionary.ActionReplyMessage,
                ReplyMarkup = KeyButtonBotHelper.GetKeyBoardForUserCompleteAction()
            };
        //Cancel Action
        public QueueMessage CancelActionMessage =>
            new QueueMessage(ChatId, MessageId)
            {
                Text = MessageDictionary.CancelReplyMessage,
                ReplyMarkup = KeyButtonBotHelper.GetRemoveKeyboard()
            };
        //User is already complete action and want to confirm it!
        public QueueMessage UserConfirmCompleteActionMessage =>
            new QueueMessage(ChatId, MessageId)
            {
                Text = MessageDictionary.UserCompleteActionMessage,
                ReplyMarkup = KeyButtonBotHelper.GetRemoveKeyboard(),
                InlineReplyMarkup = InlineKeyBoardButtonBotHelper.GetInlineKeyBoardButtonForConfirmComplete()
            };

        //User complete action and confirm it.
        public QueueMessage CompleteActionMessage =>
            new QueueMessage(ChatId, MessageId)
            {
                Text = MessageDictionary.CompleteActionMessage,
                ReplyMarkup = KeyButtonBotHelper.GetRemoveKeyboard(),
            };

        //User isn't complete action!
        public QueueMessage UserFailedActionMessage =>
            new QueueMessage(ChatId, MessageId)
            {
                Text = MessageDictionary.FailedActionMessage,
                ReplyMarkup = KeyButtonBotHelper.GetRemoveKeyboard(),
                InlineReplyMarkup = InlineKeyBoardButtonBotHelper.GetInlineKeyBoardButtonForConfirmComplete()
            };
    }
}