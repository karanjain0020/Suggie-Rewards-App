using System;
using SQLite;
using TestProjectXamarin.Models;
using Xamarin.Forms;

namespace TestProjectXamarin.Data
{
    public class TokenDatabaseController
    {
        static object locker = new object();

        SQLiteConnection database;

        public TokenDatabaseController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<Token>();
        }
        public Token GetToken()
        {
            lock (locker)
            {
                if (database.Table<TokenDatabaseController>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return database.Table<Token>().First();
                }
            }
        }
        public int SaveToken(Token token)
        {
            lock (locker)
            {
                if (token.ID != 0)
                {
                    database.Update(token);
                    return token.ID;
                }
                else
                {
                    return database.Insert(token);
                }
            }
        }
        public int DeleteToken(int id)
        {
            lock (locker)
            {
                return database.Delete<Token>(id);
            }
        }
    }
}

