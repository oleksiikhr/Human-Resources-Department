using System.Collections.Generic;

namespace Human_Resources_Department.classes.employees.db
{
    class EmployeesModel : Database
    {
        public const string nameFile = "employees.sqlite";

        public EmployeesModel(string uriFile) : base(uriFile) { }

        public IEnumerable<EmployeesTable> QueryEmployees(string q, object[] args = null)
        {
            try
            {
                if ( args == null )
                    return con.Query<EmployeesTable>(q);

                return con.Query<EmployeesTable>(q, args);
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
                CreateTable<EmployeesTable>();
            }
            catch { }
        }

        public IEnumerable<EmployeesTable> GetAllData(bool allEmployees = false)
        {
            if (allEmployees)
                return QueryEmployees("SELECT * FROM " + typeof(EmployeesTable).Name
                    + " WHERE IsActivity = 1");

            return QueryEmployees("SELECT * FROM " + typeof(EmployeesTable).Name);
        }

        public IEnumerable<EmployeesTable> GetOneData(int id)
        {
            return QueryEmployees("SELECT * FROM " + typeof(EmployeesTable).Name
                + " WHERE id = ?", new object[] { id });
        }
    }
}
