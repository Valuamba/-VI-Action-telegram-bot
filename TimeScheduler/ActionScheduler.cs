using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelegramSimpleBot.TimeScheduler
{
    public class ActionScheduler
    {
        public static async void Start()
        {
            IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            await scheduler.Start();

            IJobDetail job = JobBuilder.Create<ActionStart>().Build();

            TimeSpan sp = new TimeSpan(0,0,15);
            sp.Add(new TimeSpan(0, 2, 0));
            sp.Add(new TimeSpan(0, 1, 0));
            sp.Add(new TimeSpan(0, 0, 30));
            sp.Add(new TimeSpan(0, 0, 15));
            ITrigger trigger = TriggerBuilder.Create()  // создаем триггер
                .WithIdentity("trigger1", "group1")     // идентифицируем триггер с именем и группой
                .StartNow()                            // запуск сразу после начала выполнения
                .WithSimpleSchedule(x => x            // настраиваем выполнение действия
                    .WithRepeatCount(4)          // через 1 минуту
                    .WithInterval(sp))                   // бесконечное повторение
                .Build();                               // создаем триггер

            await scheduler.ScheduleJob(job, trigger);        // начинаем выполнение работы
        }
    }
}