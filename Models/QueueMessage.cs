using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramSimpleBot.Models
{
    public class QueueMessage
    {
        public QueueMessage(long chatId, int incomeMessageId)
        {
            ChatId = chatId;
            IncomeMessageId = incomeMessageId;
        }

        public long ChatId { get; set; }

        public int IncomeMessageId { get; set; }

        public string Text { get; set; }

        public IReplyMarkup ReplyMarkup { get; set; }

        public IReplyMarkup InlineReplyMarkup { get; set; }
    }
}