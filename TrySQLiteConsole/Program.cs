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
            var user = user_repository.FindById(12);
            user.Show();

            Console.ReadLine();
        }
    }
}