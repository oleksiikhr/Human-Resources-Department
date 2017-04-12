using System;

namespace Human_Resources_Department.classes.employees.db
{
    class EmployeesModel : Database
    {
        public const string nameFile = "employees.sqlite";

        public EmployeesModel(string uriFile) : base(uriFile) { }

        public object QueryEmployees(string q)
        {
            try
            {
                return con.Query<EmployeesTable>(q);
            }
            catch
            {
                return "";
            }
        }

        public void CreateTable()
        {
            try
            {
                CreateTable<EmployeesTable>();
            }
            catch { }
        }

        public object GetAllData()
        {
            try
            {
                return QueryEmployees("SELECT * FROM " + typeof(EmployeesTable).Name);
            }
            catch
            {
                return "";
            }
        }
    }
}
