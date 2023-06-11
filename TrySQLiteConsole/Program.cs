using System;
using System.Data.SQLite;
using System.IO;

namespace TrySQLiteConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            const string DATABASE_NAME = "sample_database.db";

            var sample_sqlite = new SampleSQLite(DATABASE_NAME);
            sample_sqlite.CreateDatabase(DATABASE_NAME);

            var create_table_sql = @"
CREATE TABLE IF NOT EXISTS User
(
    Id INTEGER NOT NULL,
    Name TEXT NOT NULL
);";
            sample_sqlite.ExecuteSQL(create_table_sql);

            Console.ReadLine();
        }

        public class SampleSQLite
        {
            public readonly string DATABASE_NAME;

            public SampleSQLite(string database_name)
            {
                DATABASE_NAME = database_name;
            }

            public string CreateConnectionString()
            {
                return $"Data Source={DATABASE_NAME}";
            }

            /// <summary>
            /// データベースファイルを作成する
            /// </summary>
            /// <param name="database_path">データベースファイルのパス、ファイル名のみでも可</param>
            /// <returns>true = 作成した, false = 作成済み</returns>
            public bool CreateDatabase(string database_path)
            {
                // 既にデータベースファイルを作成してある場合、テーブルやレコードが消えてしまう
                if(File.Exists(database_path))
                {
                    return false;
                }

                // データベースファイル名だけの場合、作成場所は Debug または Release ディレクトリ内になる
                SQLiteConnection.CreateFile(database_path);

                return File.Exists(database_path);
            }

            /// <summary>
            /// SQLを実行する
            /// </summary>
            /// <param name="sql"></param>
            /// <returns></returns>
            public void ExecuteSQL(string sql)
            {
                if(string.IsNullOrWhiteSpace(sql))
                {
                    return;
                }

                var connection_string = CreateConnectionString();
                using(var connection = new SQLiteConnection(connection_string))
                {
                    connection.Open();

                    using(var command = connection.CreateCommand())
                    {
                        command.CommandText = sql;
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
