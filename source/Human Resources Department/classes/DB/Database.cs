using SQLite;

namespace Human_Resources_Department.classes.db
{
    class Database
    {
        protected SQLiteConnection con;

        /// <see cref="http://www.sergechel.info/ru/content/using-sqllite-with-c-sharp-part-4-sqlite-net"/>
        /// <seealso cref="https://github.com/praeclarum/sqlite-net"/>
        public Database(string uriFile)
        {
            con = new SQLiteConnection(uriFile, true);

            /*
            var employee = new EmployeesTable
            {
                FName = "123"
            };

            con.Insert(employee);

            var employees = con.Table<EmployeesTable>();
            foreach (var a in employees)
            {
                MessageBox.Show(a.FName);
            }
            */
        }

        public void CreateTable<T>()
        {
            con.CreateTable<T>();
        }

        public void Insert<T>(object ob)
        {
            con.Insert(ob);
        }

        public void CloseConnection()
        {
            con.Close();
        }
    }
}
