using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using TestProjectXamarin.Models;
using Xamarin.Forms;

namespace TestProjectXamarin.Data
{
    public class UserDatabaseController
    {
        static object locker = new object();

        SQLiteConnection database;

        public UserDatabaseController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<User>();
        }
        public User GetUser()
        {
            lock (locker)
            {
                if (database.Table<UserDatabaseController>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return database.Table<User>().First();
                }
            }
        }
        public int SaveUser(User user)
        {
            lock (locker)
            {
                if(user.ID != 0)
                {
                    database.Update(user);
                    return user.ID;
                }
                else
                {
                    return database.Insert(user);
                }
            }
        }
        public int DeleteUser(int id)
        {
            lock (locker)
            {
                return database.Delete<User>(id);
            }
        }
    }
}
