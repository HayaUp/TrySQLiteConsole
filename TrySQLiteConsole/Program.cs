using System;
using System.Data.SQLite;
using System.IO;

namespace TrySQLiteConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var sample_sqlite = new SampleSQLite();
            sample_sqlite.CreateDatabase("sample_database.db");

            Console.ReadLine();
        }

        public class SampleSQLite
        {
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
        }
    }
}
