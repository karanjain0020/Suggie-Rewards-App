﻿using System;
using SQLite;
using RewardsApp_CrossPlatform.Models;
using Xamarin.Forms;

namespace RewardsApp_CrossPlatform.Data
{
    public class TokenDatabaseController
    {
        static object locker = new object();

        SQLiteConnection database;

        public TokenDatabaseController()
        {
           
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

