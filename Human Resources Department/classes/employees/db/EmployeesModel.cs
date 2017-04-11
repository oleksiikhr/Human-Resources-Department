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

        public void UpdateActivity(int id, bool value)
        {
            try
            {
                con.Execute("UPDATE " + typeof(EmployeesTable).Name
                     + " SET IsActivity = ?, UpdateAt = ? WHERE id = ?", value, DateTime.Today, id);
            }
            catch { }
        }

        public void UpdateFromPanelTextBox(object[] args)
        {
            try
            {
                con.Execute("UPDATE " + typeof(EmployeesTable).Name
                    + " SET FName = ?, MName = ?, LName = ?, Job = ?, City = ?, Email = ?, Tel = ?,"
                    + " Family = ?, Salary = ?, IsFulltime = ?, Birthday = ?,"
                    + " SetCompany = ?, UpdateAt = ? WHERE id = ?", args).ToString();
            }
            catch { }
        }
    }
}
