using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Human_Resources_Department
{
    class DB : classes.db.DBInterface
    {
        private bool is_connect = false;
        private SQLiteConnection sql_con = null;

        public void createTableUsers()
        {
            string sql = "CREATE TABLE users (" +
                "id           BIGINT (20)  AUTO_INCREMENT, UNIQUE" +
                "fName        VARCHAR(100) NOT NULL," +
                "mName        VARCHAR(100) NULL" +
                "lName        VARCHAR(100) NOT NULL" +
                "job          VARCHAR(100) NOT NULL" +
                "city         VARCHAR(50)  NULL" +
                "email        VARCHAR(50)  NULL" +
                "tel          VARCHAR(20)  NULL" +
                "family       VARCHAR(20)  NULL" +
                "salary       INT(20)      NOT NULL" +
                "is_active    BOOLEAN      NOT NULL DEFAULT true" +
                "is_fulltime  BOOLEAN      NOT NULL" +
                "birthday     TIMESTAMP    NULL" +
                "joinCompany  TIMESTAMP    NULL DEFAULT CURRENT_TIMESTAMP" +
                "leaveCompany TIMESTAMP    NULL" +
            ")";

            SQLiteCommand command = this.sql_con.CreateCommand();
            command.ExecuteNonQuery();
        }

        public bool load(string name)
        {
            try
            {
                this.sql_con = new SQLiteConnection("Data Source=" + name);
                Console.WriteLine("ok");
                this.sql_con.Open();
                Console.WriteLine("ok");
                Console.WriteLine("ok");
                this.is_connect = true;
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool save(string name)
        {
            return true;
        }

        public void close()
        {
            this.sql_con.Close();
            this.is_connect = false;
        }

        public object select()
        {
            return "";
        }

        public object insert()
        {
            return "";
        }

        public object update()
        {
            return "";
        }

        public object delete()
        {
            return "";
        }

        public bool is_connected()
        {
            return this.is_connect;
        }

        public void simpleData()
        {
            string sql = "INSERT INTO ";
        }
    }
}
