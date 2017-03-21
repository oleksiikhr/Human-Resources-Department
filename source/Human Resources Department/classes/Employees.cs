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
            // Example
            uri = "C:\\Users\\Alexey\\Documents\\Human Resources Department\\Microsoft\\1.sqlite";
            DB db = new DB(TABLE, uri);

            var data = db.GetCustomData();

            int count = data.FieldCount;
            while ( data.Read() )
            {
                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine(data.GetValue(i) + " - " + data.GetValue(i).GetType());
                }
                Console.WriteLine();

                /*
                employee[0].Add(
                    data["fName"], data["mName"], data["lName"], data["job"],
                    data["city"], data["email"], data["tel"], data["family"],
                    data["salary"], data["is_active"], data["is_fulltime"],
                    data["birthday"], data["set"], data["update_at"]
                );
                */
            }

            return true;
        }
    }
}
