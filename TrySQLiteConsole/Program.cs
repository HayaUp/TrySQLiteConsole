using System;
using System.Data.SQLite;
using System.IO;
using System.Diagnostics;

namespace TrySQLiteConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            const string DATABASE_NAME = "sample_database.db";

            var sample_sqlite = new SampleSQLite(DATABASE_NAME);
            sample_sqlite.CreateDatabase(DATABASE_NAME);

            var user = new User
            {
                Id = 1,
                Name = "Alice",
            };

            sample_sqlite.Insert(user.InsertSQL);

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
            /// データベースにテーブルを作成する
            /// </summary>
            /// <param name="sql"></param>
            /// <returns>命令を受けたレコード数</returns>
            public int CreateTable(string sql)
            {
                if(string.IsNullOrWhiteSpace(sql))
                {
                    return 0;
                }

                var result = 0;

                try
                {
                    var connection_string = CreateConnectionString();
                    using(var connection = new SQLiteConnection(connection_string))
                    {
                        connection.Open();

                        using(var command = connection.CreateCommand())
                        {
                            command.CommandText = sql;
                            result = command.ExecuteNonQuery();
                        }
                    }
                }
                catch(Exception exception)
                {
                    Debug.WriteLine(exception.Message);
                }

                return result;
            }

            /// <summary>
            /// レコードを追加する
            /// </summary>
            /// <param name="sql"></param>
            /// <returns>命令を受けたレコード数</returns>
            public int Insert(string sql)
            {
                if(string.IsNullOrWhiteSpace(sql))
                {
                    return 0;
                }

                var result = 0;

                var connection_string = CreateConnectionString();
                using(var connection = new SQLiteConnection(connection_string))
                {
                    connection.Open();

                    try
                    {
                        using(var transaction = connection.BeginTransaction())
                        using(var command = connection.CreateCommand())
                        {
                            command.CommandText = sql;
                            result = command.ExecuteNonQuery();

                            transaction.Commit();
                        }
                    }
                    catch(Exception exception)
                    {
                        Debug.WriteLine(exception.Message);
                    }
                }

                return result;
            }
        }
    }
}
