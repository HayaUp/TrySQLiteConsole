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

            user_repository.Update(new User { Id = 22, Name = "UpdatePerson"});

            var user = user_repository.FindById(22);
            user.Show();

            Console.ReadLine();
        }
    }
}