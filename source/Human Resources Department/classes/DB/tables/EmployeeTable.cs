namespace Human_Resources_Department.classes.DB.tables
{
    class EmployeeTable : Database
    {
        private const string TABLE_NAME = "employee";

        public EmployeeTable(string uri) : base(uri)
        {
            //
        }

        public void CreateTable()
        {
            string sql = "CREATE TABLE IF NOT EXISTS " + TABLE_NAME + " (" +
                    "id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "fName        VARCHAR(100) NOT NULL, " +
                    "mName        VARCHAR(100) NULL," +
                    "lName        VARCHAR(100) NULL," +
                    "job          VARCHAR(100) NULL," +
                    "city         VARCHAR(50)  NULL," +
                    "email        VARCHAR(50)  NULL," +
                    "tel          VARCHAR(20)  NULL," +
                    "family       VARCHAR(20)  NULL," +
                    "salary       INT          NULL," +
                    "is_active    BOOLEAN      NULL DEFAULT true," +
                    "is_fulltime  BOOLEAN      NULL," +
                    "birthday     TIMESTAMP    NULL," +
                    "setCompany   TIMESTAMP    NULL DEFAULT CURRENT_TIMESTAMP" +
                ")";

            base.ExecuteNonQuery(sql);
        }
    }
}
