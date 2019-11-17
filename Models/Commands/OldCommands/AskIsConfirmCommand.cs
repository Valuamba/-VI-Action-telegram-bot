using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TelegramSimpleBot.SqlModelDI.SqlService;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramSimpleBot.Models.Commands
{
    public class AskIsConfirmCommand : Command
    {
        public int _passedSeccss;

        public override string Name => "/passed";

        private DbAutoProvideSqlCommand _dbAutoProvideCommand;
        public AskIsConfirmCommand(DbAutoProvideSqlCommand _dbAutoProvideCommand)
        {
            this._dbAutoProvideCommand = _dbAutoProvideCommand;
        }

        public override void Execute(Message message, TelegramBotClient client)
        {
            var msg = message.From;

            _passedSeccss++;

            if (_passedSeccss >= 2)
            {
                var user = _dbAutoProvideCommand.GetActionUser();
                _dbAutoProvideCommand.CompleteAction();
                client.EditMessageTextAsync(message.Chat.Id, message.MessageId, user + ",ну всееее!!!!");
            }

        }

        public void UserDownButtonLimit(User user, Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            if (_dbAutoProvideCommand.ChekChoiseStatus(user.Username)
                && user.Username != _dbAutoProvideCommand.GetActionUser())
            {
                _passedSeccss++;
                _dbAutoProvideCommand.BlockChoise(user.Username);
                if (_passedSeccss >= 2)
                {
                    var userAct = _dbAutoProvideCommand.GetActionUser();
                    _dbAutoProvideCommand.CompleteAction();
                    client.EditMessageTextAsync(message.Chat.Id, message.MessageId, userAct + ",ну всееее!!!!");
                }
            }
        }



    }
}