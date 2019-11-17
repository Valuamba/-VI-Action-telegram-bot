using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TelegramSimpleBot.Data;
using TelegramSimpleBot.Models.Commands;
using TelegramSimpleBot.Services;
using TelegramSimpleBot.SqlModelDI;
using TelegramSimpleBot.SqlModelDI.SqlService;

namespace TelegramSimpleBot.Models
{
    public class BoundGeneralModule : NinjectModule
    {
        private static string pathSql = @"Data Source=DESKTOP-QEJJ1L4;Initial Catalog=DataLogin;Integrated Security=True";

        public override void Load()
        {
            //Bind<IGeneralCommandFactory>().To<GeneralCommandFactory>();

            Bind<IUserData>().To<UserData>();

            Bind<DbAutoProvideSqlCommand>().To<ReadDataOfMySQL>();

            Bind<IDbConnectionFactory>().To<SqlConnectionFactory>()
                .WithConstructorArgument("connectionString", pathSql);
        }
    }
}