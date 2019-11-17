using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramSimpleBot.Models.Helpers
{
    public class InlineKeyBoardButtonBotHelper
    {
        public static InlineKeyboardMarkup GetInlineKeyBoardButtonForConfirmComplete()
        {
            var passedButton = new InlineKeyboardButton
            {
                Text = "Респект таким!",
                CallbackData = "passed"
            };
            var failedButton = new InlineKeyboardButton
            {
                Text = "БАН",
                CallbackData = "failed"
            };

            return new InlineKeyboardMarkup(new[]
                {
                new[]
                {
                    passedButton,
                    failedButton
                }
            });

             
        }
    }
}