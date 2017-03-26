﻿using System;
using System.Data.SQLite;

namespace Human_Resources_Department.classes.DB
{
    abstract class Database
    {
        private SQLiteConnection con;

        Config cfg = new Config();

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
                new Files().WriteToFile( e.ToString(), cfg.currentFolder + "\\errors.txt" );
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

        public static void CreateDatabase(string uri, string table)
        {
            SQLiteConnection.CreateFile(uri + "\\" + table + ".sqlite");
        }
    }
}