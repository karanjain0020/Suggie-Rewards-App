using System;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectXamarin.Data
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
