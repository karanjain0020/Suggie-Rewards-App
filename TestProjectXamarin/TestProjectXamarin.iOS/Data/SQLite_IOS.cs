using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TestProjectXamarin.Data;
using TestProjectXamarin.iOS.Data;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_IOS))]

namespace TestProjectXamarin.iOS.Data
{
    public class SQLite_IOS : ISQLite
    {
        public SQLite_IOS() { }
        public SQLite.SQLiteConnection GetConnection()
        {
            var fileName = "TestDB.db3";
            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentPath, "..", "Library");
            var path = Path.Combine(libraryPath, fileName);
            var conn = new SQLite.SQLiteConnection(path);

            return conn;
        }

    }
}
