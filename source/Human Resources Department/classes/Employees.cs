using Human_Resources_Department.classes.DB.tables;

namespace Human_Resources_Department.classes
{
    class Employees
    {
        private Employee[] employee;
        private int count;

        Config cfg = new Config();

        const string TABLE = "employee";

        public void Load(string uri)
        {
            // Example
            uri = cfg.projectFolder + "\\Microsoft\\1.sqlite";
            // Database db = new Database(uri);
            EmployeeTable employee = new EmployeeTable(uri);
        }
    }
}
