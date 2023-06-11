# C# コンソールアプリケーションで SQLite を試す

## やること

- Nuget で SQLite を使えるように準備する
- データベースファイルを作成する
- テーブルを作成する
- 作成したテーブルにレコードを追加する
  - INSERT
- 追加したレコードを検索する
  - SELECT
  - WHERE
- 追加したレコードを更新する
  - UPDATE
- 追加したレコードを削除する
  - DELETE

## 作業備忘録

### Nuget で SQLite を使えるように準備する

`System.Data.SQLite.Core`をインストールする。

### データベースファイルを作成する

```cs
// 名称、拡張子はお好みで
SQLiteConnection.CreateFile("sample_database.db");

// こちらでも作成できる
using(var connection = new SQLiteConnection("Data Source=sample_database.db"))
{
    connection.Open();
}
```

#### 参考

- SQLite の NuGet パッケージ
  - https://elf-mission.net/programming/dot-net/sqlite-nuget-packages/
- System.Data.SQLite との比較
  - https://learn.microsoft.com/ja-jp/dotnet/standard/data/sqlite/compare
- Microsoft.Data.Sqlite 概要
  - https://learn.microsoft.com/ja-jp/dotnet/standard/data/sqlite/?tabs=netcore-cli

### データベースファイルを作成する

#### 参考

- 【C#】SQLiteで今すぐデータベースを使う方法とサンプルを紹介
  - https://marunaka-blog.com/use-sqlite-sample/1025/
- C#でSQLite3を使ってみる
  - https://qiita.com/koshian2/items/63938474001c510d0b15
- 【すぐに使える】C#でSQLiteを扱うための解説とサンプル集
  - https://resanaplaza.com/2020/09/21/%E3%80%90%E3%81%99%E3%81%90%E3%81%AB%E4%BD%BF%E3%81%88%E3%82%8B%E3%80%91c%E3%81%A7sqlite%E3%82%92%E6%89%B1%E3%81%86%E3%81%9F%E3%82%81%E3%81%AE%E5%85%B7%E4%BD%93%E4%BE%8B/