using Quartz;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramSimpleBot.Models;
using TelegramSimpleBot.Models.Commands;
using TelegramSimpleBot.SqlModelDI;
using TelegramSimpleBot.Services;
using TelegramSimpleBot.Models.Helpers;
using Ninject;
using System.Reflection;

namespace TelegramSimpleBot.Controllers
{
    public class MessageController : ApiController
    {

        IKernel krenel;
        GeneralCommandFactory GenerealCommands;
        QueueMessageBotHelper queue;

        public MessageController()
        {
            krenel = new StandardKernel(new BoundGeneralModule());
            //krenel.Load(Assembly.GetExecutingAssembly());
            GenerealCommands = krenel.Get<GeneralCommandFactory>();
        }

        private ActionUser _user = new ActionUser();
        private static string pathSql = @"Data Source=DESKTOP-QEJJ1L4;Initial Catalog=DataLogin;Integrated Security=True";

        [Route(@"api/message/update")] //webhook uri part
        public async Task<OkResult> Update([FromBody]Update update)
        {
            var commands = Bot.Commands;
            var message = update.Message;
            var client = await Bot.Get();

            if (message != null)
                queue = new QueueMessageBotHelper(message);

            else if (update.CallbackQuery.Message != null)
            {
                message = update.CallbackQuery.Message;
                queue = new QueueMessageBotHelper(message);
            }

            switch (update.Type)
            {
                case UpdateType.Message:

                    if (string.Compare("/go", message.Text) == 0)
                    {
                        GenerealCommands.ActionCommand(queue.MorningControlMessage, client);
                    }

                    if (_user.Name == null)
                        GenerealCommands.
                            AskIsSelectCommand(
                                new[]
                                {
                                    queue.UserActionMessage,
                                    queue.CancelActionMessage
                                }, 
                                message, 
                                client);

                    if (_user.isComplete == null)     
                        GenerealCommands.
                            AnswerIsConfirmActionCommand(
                                queue.UserConfirmCompleteActionMessage, 
                                message, 
                                client);

                    //if (_user.isConfirm == null)
                    //    new AskIsConfirmCommand(new ReadDataOfMySQL(new SqlConnectionFactory(pathSql))).Execute(message, client);

                    //if(message.Text == "Ля какой, ну что ж давайте посмотрим?")
                    //await client.EditMessageReplyMarkupAsync(message.Chat.Id, message.MessageId,
                    //     new InlineKeyboardMarkup(new[]
                    //     {
                    //        new[]
                    //        {
                    //            new InlineKeyboardButton{ Text = "KEKE", CallbackData = "kukiscj"},
                    //            new InlineKeyboardButton{ Text = "LOL", CallbackData = "lolik"}
                    //        }
                    //     }));           

                    break;

                case UpdateType.CallbackQuery:

                    message = update.CallbackQuery.Message;

                    if(update.CallbackQuery.Data == "failed")
                       new AnswerIsNotConfirmActionCommand().Execute(message, client);

                    if (update.CallbackQuery.Data == "passed")
                         GenerealCommands.
                            ConfirmCallBackCommand(
                                 queue.CompleteActionMessage,
                                 message,
                                 update.CallbackQuery.From,
                                 client);

                    break;

            }

            //switch (update.Type)
            //{


            //    case UpdateType.CallbackQuery:


            //        await client.AnswerCallbackQueryAsync(update.CallbackQuery.Id, "Ищем крысу");


            //        if (update.CallbackQuery.Data == "passed")

            //        {
            //            foreach (var command in commands)
            //            {
            //                if (command.Contains("/passed"))
            //                {
            //                    var cm = command as MissionPassedCommand;
            //                    cm.UserDownButtonLimit(update.CallbackQuery.From, update.CallbackQuery.Message, client);

            //                    break;
            //                }
            //            }

            //            return Ok();
            //        }
            //        if (update.CallbackQuery.Data == "failed")
            //        {
            //            await client.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, "test");
            //            return Ok();
            //        }
            //        break;

            //}

            //if (message.NewChatMembers != null)
            //{
            //    message.Text = "/addnewuser";
            //}
            //if (message.LeftChatMember != null)
            //{
            //    message.Text = "/delete_user";
            //}
            //foreach (var command in commands)
            //{
            //    if (command.Contains(message.Text))
            //    {
            //        command.Execute(message, client);
            //        message.Text = null;
            //        break;
            //    }
            //}

            return Ok();
        }

        public void StartJob(Message message, TelegramBotClient client)
        {
            if (DateTime.Now.ToString("HH:mm:ss") == "17:16:00")
            {
                client.SendTextMessageAsync(message.Chat.Id, "Проблемы?");
            }
        }
    }

    
}