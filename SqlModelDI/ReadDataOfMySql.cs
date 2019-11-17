using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TelegramSimpleBot.SqlModelDI.SqlService;

namespace TelegramSimpleBot.SqlModelDI
{
    class ReadDataOfMySQL : DbAutoProvideSqlCommand
    {

        private IDbConnectionFactory _connectionFactory;
        public ReadDataOfMySQL(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        //Get UserName who in action
        public string GetActionUser()
        {
            string str = null;
            using (var dbConnection = _connectionFactory.CreateConnection())
            {
                var dbCon = (SqlConnection)dbConnection;

                string command = @"Declare @datetime DATE = GETDATE()
                                    Declare @num int = (Select count(urnStatus)
					                from UserData 
					                Where urnStatus = 1
					                Group by urnStatus
					                Having count(urnStatus) = 1)


                                if(@num = 1)
                                begin
	                                Select username 
	                                from UserData
	                                Where urnStatus = 1
                                end
                                else
                                begin
	                                Update UserData
	                                Set urnStatus = 1
	                                Where dateLastAction = (Select MIN(dateLastAction) from UserData);

	                                Select username 
	                                from UserData
	                                Where urnStatus = 1

                                end";



                using (var sq = new SqlCommand(command, dbCon))
                {
                    using (var dataReader = sq.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            str = dataReader[0].ToString();
                        }
                    }
                }
            }
            return str;
        }

        public void CompleteAction()
        {
            using (var dbConnection = _connectionFactory.CreateConnection())
            {
                var dbCon = (SqlConnection)dbConnection;

                using (var cmd = dbCon.CreateCommand())
                {
                    cmd.CommandText = @"Update UserData 
                                        Set urnStatus = @BoolStatus, dateLastAction = @DateNow 
                                        Where dateLastAction = (Select Min(dateLastAction) from UserData);

                                        Update UserData
                                        Set choiseStatus = 0";

                    cmd.Parameters.AddWithValue("@BoolStatus", 0);
                    cmd.Parameters.AddWithValue("@DateNow", DateTime.Now);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AddNewUser(string userName)
        {
            using (var dbConnection = _connectionFactory.CreateConnection())
            {
                var dbCon = (SqlConnection)dbConnection;

                using (var cmd = dbCon.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO UserData (username, urnStatus, urnBehaivior,dateLastAction)
                                        values(@userName, @urnStatus, @urnBehaivior, @dateLastAction)";

                    cmd.Parameters.AddWithValue("@userName", "@" + userName);
                    cmd.Parameters.AddWithValue("@urnStatus", 0);
                    cmd.Parameters.AddWithValue("@urnBehaivior", 1);
                    cmd.Parameters.AddWithValue("@dateLastAction", DateTime.Now);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteUser(string userName)
        {
            using (var dbConnection = _connectionFactory.CreateConnection())
            {
                var dbCon = (SqlConnection)dbConnection;
                
                using (var cmd = dbCon.CreateCommand())
                {
                    cmd.CommandText = @"DELETE FROM UserData 
                                        WHERE username=@userName";

                    cmd.Parameters.AddWithValue("@userName", "@" + userName);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool ChekChoiseStatus(string userName)
        {
            string i = "";

            using (var dbConnection = _connectionFactory.CreateConnection())
            {
                var dbCon = (SqlConnection)dbConnection;

                using (var cmd = dbCon.CreateCommand())
                {
                    cmd.CommandText = @"Select choiseStatus
                                        from UserData
                                        Where username = @userName";

                    cmd.Parameters.AddWithValue("@userName", "@" + userName);
                    cmd.ExecuteNonQuery();
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            i = dataReader[0].ToString();
                        }

                        
                    }
                }
            }
            if (i == "False")
                return true;
            if (i == "True")
                return false;

            return false;
        }

        public void BlockChoise(string userName)
        {
            using (var dbConnection = _connectionFactory.CreateConnection())
            {
                var dbCon = (SqlConnection)dbConnection;

                using (var cmd = dbCon.CreateCommand())
                {
                    cmd.CommandText = @"Update UserData
                                        Set choiseStatus = 1
                                        Where username = @username";

                    cmd.Parameters.AddWithValue("@userName", "@" + userName);
                    cmd.ExecuteNonQuery();
                }
            }
        }


    }
}