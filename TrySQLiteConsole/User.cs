using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrySQLiteConsole
{
    public class User
    {
        public int Id;
        public string Name;

        public string CreateTableSQL
        {
            get => @"
                CREATE TABLE IF NOT EXISTS User
                (
                    Id INTEGER NOT NULL,
                    Name TEXT NOT NULL
                );";
        }

        public string InsertSQL
        {
            get => @$"
                INSERT INTO User (Id, Name)
                VALUES
                (
                    {Id},
                    '{Name}'
                );";
        }
    }
}
