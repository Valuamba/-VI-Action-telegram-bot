using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TelegramSimpleBot.SqlModelDI.SqlService
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();

    }
}
