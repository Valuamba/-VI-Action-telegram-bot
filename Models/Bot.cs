using System.Collections.Generic;
using System.Threading.Tasks;

using Telegram.Bot;
using Telegram.Bot.Args;
using TelegramSimpleBot.Models.Commands;
using TelegramSimpleBot.SqlModelDI;

namespace TelegramSimpleBot.Models
{
    public static class Bot
    {
        private static TelegramBotClient client;
        private static List<Command> commandsList;
        private static string pathSql = @"Data Source=DESKTOP-QEJJ1L4;Initial Catalog=DataLogin;Integrated Security=True";

        public static IReadOnlyList<Command> Commands => commandsList.AsReadOnly();



        public static async Task<TelegramBotClient> Get()
        {
            if (client != null)
            {
                return client;
            }

            commandsList = new List<Command>();
            
            //TODO: Add more commands

            client = new TelegramBotClient(AppSettings.Key);
            var hook = string.Format(AppSettings.Url, "api/message/update");
            await client.SetWebhookAsync(hook);

            return client;
        }


        
        


    }
}