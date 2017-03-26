using Human_Resources_Department.classes.DB.tables;

namespace Human_Resources_Department.classes
{
    class Employees
    {
        private Employee[] employee;
        private int count;

        const string TABLE = "employee";

        public void Load(string uri)
        {
            EmployeeTable emTable = new EmployeeTable(uri);

            
        }
    }
}
