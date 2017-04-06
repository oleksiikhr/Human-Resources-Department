namespace Human_Resources_Department.classes.employees.db
{
    class EmployeesModel : Database
    {
        public const string nameFile = "employees.sqlite";

        public EmployeesModel(string uriFile) : base(uriFile) { }

        public object QueryEmployees(string q)
        {
            return con.Query<EmployeesTable>(q);
        }

        public void CreateTableEmployees()
        {
            CreateTable<EmployeesTable>();
        }

        public object GetAllData()
        {
            return QueryEmployees("SELECT * FROM " + typeof(EmployeesTable).Name);
        }
    }
}
