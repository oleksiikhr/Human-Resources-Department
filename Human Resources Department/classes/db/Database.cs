using SQLite;

using Human_Resources_Department.classes.db.tables;

namespace Human_Resources_Department.classes.db
{
    public class Database
    {
        protected SQLiteConnection con;

        /// <see cref="http://www.sergechel.info/ru/content/using-sqllite-with-c-sharp-part-4-sqlite-net"/>
        /// <seealso cref="https://github.com/praeclarum/sqlite-net"/>
        public Database(string uriFile)
        {
            con = new SQLiteConnection(uriFile);
        }

        public void CreateTable<T>()
        {
            con.CreateTable<T>();
        }

        public void Insert(object ob)
        {
            con.Insert(ob);
        }

        public void Update(object ob)
        {
            con.Update(ob);
        }

        public object QueryEmployees(string q)
        {
            return con.Query<EmployeesTable>(q);
        }

        public void CloseConnection()
        {
            con.Close();
        }
    }
}
