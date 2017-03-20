using System;
using System.Data;
using System.Data.SQLite;

namespace Human_Resources_Department.classes
{
    class DB
    {
        private SQLiteConnection con = null;
        private string table;

        /// <see cref="https://www.tutorialspoint.com/sqlite/index.htm"/>
        /// <seealso cref="https://habrahabr.ru/post/149356/"/>
        public DB(string table, string uri = "")
        {
            this.table = table;
            this.con = new SQLiteConnection("Data Source=" + uri);
            this.con.Open();
            
            TableCreate();
            InsertCustomData();
            GetCustomData();
        }

        public void TableCreate()
        {
            string sql = "CREATE TABLE IF NOT EXISTS '@table' (" +
                    "id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "fName        VARCHAR(100) NOT NULL, " +
                    "mName        VARCHAR(100) NULL," +
                    "lName        VARCHAR(100) NULL," +
                    "job          VARCHAR(100) NULL," +
                    "city         VARCHAR(50)  NULL," +
                    "email        VARCHAR(50)  NULL," +
                    "tel          VARCHAR(20)  NULL," +
                    "family       VARCHAR(20)  NULL," +
                    "salary       INT          NULL," +
                    "is_active    BOOLEAN      NULL DEFAULT true," +
                    "is_fulltime  BOOLEAN      NULL," +
                    "birthday     TIMESTAMP    NULL," +
                    "joinCompany  TIMESTAMP    NULL DEFAULT CURRENT_TIMESTAMP," +
                    "leaveCompany TIMESTAMP    NULL" +
                ")";

            using ( SQLiteCommand cmd = new SQLiteCommand(sql, this.con) )
            {
                cmd.Parameters.AddWithValue("@table", this.table);
                cmd.ExecuteNonQuery();
            }
        }

        public SQLiteDataReader GetCustomData()
        {
            string sql = "SELECT * FROM '@table'";

            using ( SQLiteCommand cmd = new SQLiteCommand(sql, this.con) )
            {
                cmd.Parameters.AddWithValue("@table", this.table);
                SQLiteDataReader reader = cmd.ExecuteReader();

                return reader;
            }
        }

        public void InsertCustomData()
        {
            string sql = "INSERT INTO '@table' (fName, lName, city, job, salary) " +
                "VALUES ('MyName', 'MyLastName', 'MyCity', 'MyJob', '1000')";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, this.con))
            {
                cmd.Parameters.AddWithValue("@table", this.table);
                cmd.ExecuteNonQuery();
            }
        }

        public void CloseConnect()
        {
            this.con.Close();
            this.table = null;
        }
    }
}
