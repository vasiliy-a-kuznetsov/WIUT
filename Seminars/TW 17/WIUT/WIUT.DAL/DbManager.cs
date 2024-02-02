using System.Data.SQLite;

namespace WIUT.DAL
{
    public class DbManager
    {
        protected SQLiteConnection Connection
        {
            get
            {
                return new SQLiteConnection(Properties.Settings.Default.ConnectionString);
            }
        }
    }
}
