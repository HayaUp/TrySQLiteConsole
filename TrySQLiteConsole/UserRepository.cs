using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Diagnostics;

namespace TrySQLiteConsole
{
    /// <summary>
    /// Users テーブルのみを扱うクラス
    /// </summary>
    public class UserRepository : RepositoryBase
    {
        public readonly string TABLE_NAME;

        public UserRepository()
        {
            TABLE_NAME = "Users";
        }

        public void CreateTable()
        {
            var user = new User();

            var sql = @$"
                CREATE TABLE IF NOT EXISTS {TABLE_NAME}
                (
                    {nameof(user.Id)} INTEGER NOT NULL,
                    {nameof(user.Name)} TEXT NOT NULL
                );";

            Execute(sql);
        }

        /// <summary>
        /// テーブルに指定した User を挿入する
        /// </summary>
        /// <param name="user"></param>
        /// <returns>true = 挿入成功, false = 挿入失敗</returns>
        public bool Insert(User user)
        {
            if(user == null)
            {
                return false;
            }

            var sql = @$"
                        INSERT INTO {TABLE_NAME} ({nameof(user.Id)}, {nameof(user.Name)})
                        VALUES({user.Id}, '{user.Name}');
                        ";

            var result = Execute(sql);

            return result > 0;
        }

        public void Update()
        {

        }

        /// <summary>
        /// テーブルにある User を参照する
        /// </summary>
        /// <returns></returns>
        public List<User> Select()
        {
            var users = new List<User>();

            try
            {
                using(var connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    using(var command = connection.CreateCommand())
                    {
                        command.CommandText = $"SELECT * FROM {TABLE_NAME};";

                        using(var reader = command.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                var user = new User
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Name = reader["Name"].ToString()
                                };

                                users.Add(user);
                            }
                        }
                    }
                }
            }
            catch(Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }

            return users;
        }

        /// <summary>
        /// User の Id を指定してレコードを参照する
        /// </summary>
        /// <param name="id">User クラスの Id</param>
        /// <returns>指定した Id に一致する User, 該当しなければ初期値の User</returns>
        public User FindById(int id)
        {
            var user = new User();

            try
            {
                using(var connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    using(var command = connection.CreateCommand())
                    {
                        command.CommandText = @$"
                                                SELECT * FROM {TABLE_NAME}
                                                WHERE {nameof(User.Id)} = {id}
                                                ;";

                        using(var reader = command.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                user.Id = int.Parse(reader["Id"].ToString());
                                user.Name = reader["Name"].ToString();
                            }
                        }
                    }
                }
            }
            catch(Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }

            return user;
        }

        public void Delete()
        {

        }

        /// <summary>
        /// ダミーデータを作成しテーブルへ挿入する
        /// </summary>
        public void InsertDummyData()
        {
            var names = new string[]
            {
                "Alice",
                "Bob",
                "Carol",
                "Charlie",
                "Dave",
                "Ellen",
                "Frank",
                "Gari",
                "Haiku",
                "Issac",
                "Ivan",
                "Justin",
                "Katana",
                "Last",
                "Mallory",
                "Marvin",
                "Mallet",
                "Matilda",
                "Ninja",
                "Oscar",
                "Pat",
                "Peggy",
                "Plod",
                "Quantum",
                "Ramen",
                "Steve",
                "Trent",
                "Trudy",
                "Udon",
                "Victor",
                "Walter",
                "Xanadu",
                "Yakitori",
                "Zoe",
            };

            var users = new List<User>();

            for(int i = 0; i < names.Length; i++)
            {
                users.Add(new User { Id = i + 1, Name = names[i] });
            }

            users.ForEach(user => Insert(user));
        }
    }
}
