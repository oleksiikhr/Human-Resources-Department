using SQLite;

namespace Human_Resources_Department.classes.db
{
    public abstract class Database
    {
        protected SQLiteConnection con;
        
        public Database(string uriFile)
        {
            try
            {
                con = new SQLiteConnection(uriFile);
            }
            catch { }
        }

        public void CreateTable<T>()
        {
            try
            {
                con.CreateTable<T>();
            }
            catch { }
        }

        public int Insert(object ob)
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

        public int Update(string q, object[] args)
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

        public void CloseConnection()
        {
            con.Close();
        }
    }
}
