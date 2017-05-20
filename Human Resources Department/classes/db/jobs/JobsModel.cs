using System.Collections.Generic;

namespace Human_Resources_Department.classes.db.jobs
{
    class JobsModel : Database
    {
        public static IEnumerable<JobsTable> QueryJobs(string q, object[] args = null)
        {
            try
            {
                if (args == null)
                    return con.Query<JobsTable>(q);

                return con.Query<JobsTable>(q, args);
            }
            catch
            {
                return null;
            }
        }

        public static IEnumerable<JobsTable> GetAllJobs()
        {
            return QueryJobs("SELECT * FROM " + typeof(JobsTable).Name);
        }

        public static IEnumerable<JobsTable> GetJobsByTitle(string title)
        {
            return QueryJobs("SELECT * FROM " + typeof(JobsTable).Name
                + " WHERE Title = ?", new object[] { title });
        }
    }
}
