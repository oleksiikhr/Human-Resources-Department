using SQLite;

using Human_Resources_Department.classes.employees.db;
using Human_Resources_Department.classes.db.pass;
using Human_Resources_Department.classes.db.jobs;
using Human_Resources_Department.classes.db.army;
using Human_Resources_Department.classes.db.edu;

namespace Human_Resources_Department.classes.db
{
    public class Database
    {
        public const string FILE_NAME = "db.sqlite";

        private static bool instanse = false;

        protected static SQLiteConnection con;

        public static void SetFile(string uriToFile)
        {
            if (instanse)
                return;

            try
            {
                con = new SQLiteConnection(uriToFile);
                instanse = true;
            }
            catch { }
        }

        public static void CreateTable<T>()
        {
            try
            {
                con.CreateTable<T>();
            }
            catch { }
        }

        public static int Insert(object ob)
        {
            try
            {
                return con.Insert(ob);
            }
            catch
            {
                return 0;
            }
        }

        public static int Update(string q, object[] args)
        {
            try
            {
                return con.Execute(q, args);
            }
            catch
            {
                return 0;
            }
        }

        public static int DeleteObject<T>(object id)
        {
            try
            {
                return con.Delete<T>(id);
            }
            catch
            {
                return 0;
            }
        }

        public static void CreateDatabases(string uriToFile)
        {
            SetFile(uriToFile);

            CreateTable<MainTable>();
            CreateTable<PassTable>();
            CreateTable<JobsTable>();
            CreateTable<ArmyTable>();
            CreateTable<EduTable>();
            // ..
            instanse = true;
        }

        public static void CloseConnection()
        {
            con.Close();
            instanse = false;
        }
    }
}
