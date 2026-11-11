using System;
using Npgsql;

namespace STAR
{
    public static class Database
    {

        private const string ConnectionString =
            "Host=SQLstudv2;Port=5432;Database=24ipp9;Username=24ipp9;Password=24ipp9;Search Path=star";

        
        public static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(ConnectionString);
        }


        public static string TestConnection()
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand("SELECT version();", conn))
                    {
                        return "Подключение успешно!" ;
                    }
                }
            }
            catch (Exception ex)
            {
                return "Ошибка подключения:\n" + ex.Message;
            }
        }
    }
}