using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Diagnostics;

namespace TrySQLiteConsole
{
    /// <summary>
    /// SQLite の基底クラス
    /// </summary>
    public class RepositoryBase
    {
        public readonly string DATABASE_NAME;

        public RepositoryBase()
        {
#warning データベース名は決め打ちでよさそう
            DATABASE_NAME = "sample_database.db";
        }

        public string ConnectionString
        {
            get
            {
                var string_builder = new SQLiteConnectionStringBuilder
                {
                    DataSource = DATABASE_NAME,
                    Version = 3,
                };

                return string_builder.ToString();
            }
        }

        /// <summary>
        /// データベースファイルを作成する
        /// </summary>
        /// <param name="is_overwrite">同じ名称のデータベースファイルが存在する場合、上書きするか</param>
        /// <returns>true = 作成した, false = 作成済み</returns>
        public bool CreateDatabase(bool is_overwrite = false)
        {
            // 既にデータベースファイルを作成してある場合、テーブルやレコードが消えてしまう
            if(!is_overwrite)
            {
                return false;
            }

            // データベースファイル名だけの場合、作成場所は Debug または Release ディレクトリ内になる
            SQLiteConnection.CreateFile(DATABASE_NAME);

            return File.Exists(DATABASE_NAME);
        }

        /// <summary>
        /// SQLを実行する
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>命令を受けたレコード数</returns>
        public int Execute(string sql)
        {
            if(string.IsNullOrWhiteSpace(sql))
            {
                return 0;
            }

            var result = 0;

            using(var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                using(var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using(var command = connection.CreateCommand())
                        {
                            command.CommandText = sql;
                            result = command.ExecuteNonQuery();

                            transaction.Commit();
                        }
                    }
                    catch(Exception exception)
                    {
                        transaction.Rollback();
                        Debug.WriteLine(exception.Message);
                    }
                }
            }

            return result;
        }
    }
}
