using System;
using System.Data.SQLite;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;

namespace TrySQLiteConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var user_repository = new UserRepository();
            var users = user_repository.Select();

            users.ForEach(user => user.Show());

            Console.ReadLine();
        }
    }
}