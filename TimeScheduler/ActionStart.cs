using Ninject;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TelegramSimpleBot.Models;
using TelegramSimpleBot.Models.Commands;

namespace TelegramSimpleBot.TimeScheduler
{
    public class ActionStart : IJob
    {
        private GeneralCommandFactory _generalCommands;

        public async Task Execute(IJobExecutionContext context)
        {
            var client = await Bot.Get();
            var krenel = new StandardKernel(new BindGeneralModule());
            //krenel.Load(Assembly.GetExecutingAssembly());
            _generalCommands = krenel.Get<GeneralCommandFactory>();

            await client.SendTextMessageAsync(-1001296912204, "Чикиряу патау");
        }
    }
}