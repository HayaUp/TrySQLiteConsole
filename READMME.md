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

#### 参考

- SQLite の NuGet パッケージ
  - https://elf-mission.net/programming/dot-net/sqlite-nuget-packages/
- System.Data.SQLite との比較
  - https://learn.microsoft.com/ja-jp/dotnet/standard/data/sqlite/compare