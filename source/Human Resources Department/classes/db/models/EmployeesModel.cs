using Human_Resources_Department.classes.db.tables;

namespace Human_Resources_Department.classes.db.models
{
    class EmployeesModel : Database
    {
        public const string nameFile = "employees.sqlite";

        public EmployeesModel(string uri) : base(uri)
        {

        }

        public object Query(string q)
        {
            return con.Query<EmployeesTable>(q);
        }
    }
}
