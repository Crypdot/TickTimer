using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TickTimer.DAO
{
    class LocalDAO
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<LocalDAO> Instance = new AsyncLazy<LocalDAO>(async () =>
        {
            var instance = new LocalDAO();
            CreateTableResult result = await Database.CreateTableAsync<ProcessTimer>()
            return instance;
        });

        public LocalDAO()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

    }
}
