using System;
using System.Windows.Forms;

namespace Human_Resources_Department.classes.employees.db
{
    class EmployeesModel : Database
    {
        public const string nameFile = "employees.sqlite";

        public EmployeesModel(string uriFile) : base(uriFile) { }

        public object QueryEmployees(string q)
        {
            object res;

            try
            {
                res = con.Query<EmployeesTable>(q);
                return res;
            }
            catch (Exception ex)
            {
                Files.WriteToFile(ex.ToString(), Files.errorFile);
                return "";
            }
        }

        public void CreateTable()
        {
            try
            {
                CreateTable<EmployeesTable>();
            }
            catch (Exception ex)
            {
                Files.WriteToFile(ex.ToString(), Files.errorFile);
            }
        }

        public object GetAllData()
        {
            object data;

            try
            {
                data = QueryEmployees("SELECT * FROM " + typeof(EmployeesTable).Name);
                return data;
            }
            catch (Exception ex)
            {
                Files.WriteToFile(ex.ToString(), Files.errorFile);
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
            catch (Exception ex)
            {
                Files.WriteToFile(ex.ToString(), Files.errorFile);
            }
        }

        public void UpdateFromPanelTextBox(object[] args)
        {
            MessageBox.Show( con.Execute("UPDATE " + typeof(EmployeesTable).Name
                + " SET FName = ?, MName = ?, LName = ?, Job = ?, City = ?, Email = ?, Tel = ?,"
                + " Family = ?, Salary = ?, IsFulltime = ?, Birthday = ?,"
                + " SetCompany = ?, UpdateAt = ? WHERE id = ?", args).ToString() );
        }
    }
}
