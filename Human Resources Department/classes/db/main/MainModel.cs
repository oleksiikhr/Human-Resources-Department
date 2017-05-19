using System.Collections.Generic;

using Human_Resources_Department.classes.db;

namespace Human_Resources_Department.classes.employees.db
{
    class MainModel : Database
    {
        public const string nameFile = "main.sqlite";

        public IEnumerable<MainTable> QueryEmployees(string q, object[] args = null)
        {
            try
            {
                if ( args == null )
                    return con.Query<MainTable>(q);

                return con.Query<MainTable>(q, args);
            }
            catch
            {
                return null;
            }
        }

        public void CreateTableEmployees()
        {
            try
            {
                CreateTable<MainTable>();
            }
            catch { }
        }

        public IEnumerable<MainTable> GetAllData(bool allEmployees = false)
        {
            if (allEmployees)
                return QueryEmployees("SELECT * FROM " + typeof(MainTable).Name
                    + " WHERE IsActivity = 1");

            return QueryEmployees("SELECT * FROM " + typeof(MainTable).Name);
        }

        public IEnumerable<MainTable> GetOneData(int id)
        {
            return QueryEmployees("SELECT * FROM " + typeof(MainTable).Name
                + " WHERE id = ?", new object[] { id });
        }
    }
}
