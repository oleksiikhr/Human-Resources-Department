using System;

namespace Human_Resources_Department.classes
{
    class Employees
    {
        private Employee[] employee;
        private int count;

        const string TABLE = "employee";

        public bool Load(string uri)
        {
            DB db = new DB(TABLE, uri);
            var data = db.GetCustomData();

            return true;
        }
    }
}
