using SQLite;
using System;

namespace Human_Resources_Department.classes
{
    public abstract class Database
    {
        protected SQLiteConnection con;

        /// <see cref="http://www.sergechel.info/ru/content/using-sqllite-with-c-sharp-part-4-sqlite-net"/>
        /// <seealso cref="https://github.com/praeclarum/sqlite-net"/>
        public Database(string uriFile)
        {
            try
            {
                con = new SQLiteConnection(uriFile);
            }
            catch (Exception ex)
            {
                Files.WriteToFile(ex.ToString(), Files.errorFile);
            }
        }

        public void CreateTable<T>()
        {
            try
            {
                con.CreateTable<T>();
            }
            catch (Exception ex)
            {
                Files.WriteToFile(ex.ToString(), Files.errorFile);
            }
        }

        public int Insert(object ob)
        {
            try
            {
                return con.Insert(ob);
            }
            catch (Exception ex)
            {
                Files.WriteToFile(ex.ToString(), Files.errorFile);
                return 0;
            }
        }

        public void Update(string q, object[] args)
        {
            try
            {
                con.Execute(q, args);
            }
            catch (Exception ex)
            {
                Files.WriteToFile(ex.ToString(), Files.errorFile);
            }
        }

        public void CloseConnection()
        {
            con.Close();
        }
    }
}
