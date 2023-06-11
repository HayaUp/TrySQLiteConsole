# C# �R���\�[���A�v���P�[�V������ SQLite ������

## ��邱��

- Nuget �� SQLite ���g����悤�ɏ�������
- �f�[�^�x�[�X�t�@�C�����쐬����
- �e�[�u�����쐬����
- �쐬�����e�[�u���Ƀ��R�[�h��ǉ�����
  - INSERT
- �ǉ��������R�[�h����������
  - SELECT
  - WHERE
- �ǉ��������R�[�h���X�V����
  - UPDATE
- �ǉ��������R�[�h���폜����
  - DELETE

## ��Ɣ��Y�^

### Nuget �� SQLite ���g����悤�ɏ�������

`System.Data.SQLite.Core`���C���X�g�[������B

### �f�[�^�x�[�X�t�@�C�����쐬����

```cs
// ���́A�g���q�͂��D�݂�
SQLiteConnection.CreateFile("sample_database.db");

// ������ł��쐬�ł���
using(var connection = new SQLiteConnection("Data Source=sample_database.db"))
{
    connection.Open();
}
```

#### �Q�l

- SQLite �� NuGet �p�b�P�[�W
  - https://elf-mission.net/programming/dot-net/sqlite-nuget-packages/
- System.Data.SQLite �Ƃ̔�r
  - https://learn.microsoft.com/ja-jp/dotnet/standard/data/sqlite/compare
- Microsoft.Data.Sqlite �T�v
  - https://learn.microsoft.com/ja-jp/dotnet/standard/data/sqlite/?tabs=netcore-cli

### �f�[�^�x�[�X�t�@�C�����쐬����

#### �Q�l

- �yC#�zSQLite�ō������f�[�^�x�[�X���g�����@�ƃT���v�����Љ�
  - https://marunaka-blog.com/use-sqlite-sample/1025/
- C#��SQLite3���g���Ă݂�
  - https://qiita.com/koshian2/items/63938474001c510d0b15
- �y�����Ɏg����zC#��SQLite���������߂̉���ƃT���v���W
  - https://resanaplaza.com/2020/09/21/%E3%80%90%E3%81%99%E3%81%90%E3%81%AB%E4%BD%BF%E3%81%88%E3%82%8B%E3%80%91c%E3%81%A7sqlite%E3%82%92%E6%89%B1%E3%81%86%E3%81%9F%E3%82%81%E3%81%AE%E5%85%B7%E4%BD%93%E4%BE%8B/