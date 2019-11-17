using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramSimpleBot.Models.Helpers
{
    public static class KeyButtonBotHelper
    {
        //Bot is asked, what need to do, and decide who will be do it.
        public static ReplyKeyboardMarkup GetKeyBoardForAction()
        {
            var urnButton = new KeyboardButton("\uD83D\uDDD1Дело есть!");
            var okButton = new KeyboardButton("Пока все тихо...");

            var listButton = new KeyboardButton("Дай-ка список глянуть.");

            var keyBoardButton = new[]
            {
                new[] { urnButton, okButton },
                new[] { listButton }
            };

            return new ReplyKeyboardMarkup { Keyboard = keyBoardButton, ResizeKeyboard = true, OneTimeKeyboard = true };
        }

        //User is complete action and want to share this with other Users
        public static ReplyKeyboardMarkup GetKeyBoardForUserCompleteAction()
        {
            var passedButton = new KeyboardButton("Ez4 ENCE!");

         
            var keyBoardButton = new[] { new[] { passedButton } };

            return new ReplyKeyboardMarkup { Keyboard = keyBoardButton , Selective = true,
                OneTimeKeyboard = true , ResizeKeyboard = true};
        }

        public static ReplyKeyboardRemove GetRemoveKeyboard() => new ReplyKeyboardRemove {Selective = false };

    }
}