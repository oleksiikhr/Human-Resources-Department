using System;
using System.Data.SQLite;

namespace Human_Resources_Department.classes.db
{
    abstract class Database
    {
        private SQLiteConnection con;

        Config cfg = new Config();
        Files fls = new Files();

        /// <see cref="https://www.tutorialspoint.com/sqlite/index.htm"/>
        /// <seealso cref="https://habrahabr.ru/post/149356/"/>
        public Database(string uri)
        {
            try
            {
                con = new SQLiteConnection("Data Source=" + uri);
            }
            catch (Exception e)
            {
                fls.WriteToFile( "No connection to BD: " + e.ToString(), fls.errorFile );
            }
        }

        public void ExecuteNonQuery(string sql)
        {
            using ( SQLiteCommand cmd = new SQLiteCommand(sql, con) )
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public static void CreateDatabase(string uri)
        {
            SQLiteConnection.CreateFile(uri);
        }
    }
}
