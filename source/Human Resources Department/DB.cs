using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Human_Resources_Department
{
    class DB
    {
        /**
         * Example.
         * ID, FName, MName, LName, PhotoUrl, Age, Salary, Job, Email, Tel, Active
         * 
         * @see http://blog.tigrangasparian.com/2012/02/09/getting-started-with-sqlite-in-c-part-one/
         * @see http://www.cyberforum.ru/ado-net/thread362189.html
         */
        public DB()
        {
            SQLiteConnection.CreateFile("MyDatabase.sqlite");
            SQLiteConnection m_dbConnection;

            m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();
            string sql = "CREATE TABLE highscores (name VARCHAR(20), score INT)";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            sql = "insert into highscores (name, score) values ('Me', 3000)";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            sql = "insert into highscores (name, score) values ('Myself', 6000)";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            sql = "insert into highscores (name, score) values ('And I', 9001)";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            sql = "select * from highscores order by score desc";
            command = new SQLiteCommand(sql, m_dbConnection);

            SQLiteDataReader reader = command.ExecuteReader();

            sql = "select * from highscores order by score desc";
            command = new SQLiteCommand(sql, m_dbConnection);
            reader = command.ExecuteReader();
            while (reader.Read())
                Console.WriteLine("Name: " + reader["name"] + "\tScore: " + reader["score"]);
        }
    }
}
