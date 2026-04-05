# Todoist API C# クライアント

Todoist API v1 向けの非公式 C# クライアントライブラリです。

## 主な機能

現在このライブラリで対応している機能:

- OAuth トークン交換・失効（`AuthToken`）
- タスク（`Get` / `List` / `Create` / `Update` / `Close` / `Reopen` / `Delete` / `Quick Add`）
- プロジェクト（`Get` / `List` / `Create` / `Update` / `Delete`）
- プロジェクト共同編集者（`List`）
- セクション（`Get` / `List` / `Create` / `Update` / `Delete`）
- ラベル（`Get` / `List` / `Create` / `Update` / `Delete`）
- 共有ラベル（`List` / `Rename` / `Remove`）
- コメント（`Get` / `List` / `Create` / `Update` / `Delete`）
- リマインダー（`List` のみ / 読み取り専用）
- `GetPageAsync(...)` と `PagedResult<T>.NextCursor` によるカーソルベースページング

## インストール

```bash
dotnet add package Todoist
```

## 動作要件

- .NET Standard 2.0 互換ランタイム

## クイックスタート（パーソナルアクセストークン）

```csharp
using Todoist;

var client = new TodoistClient("YOUR_ACCESS_TOKEN");

var tasks = await client.Tasks.GetAllAsync();
foreach (var task in tasks)
{
    Console.WriteLine(task.Content);
}
```

## よく使う例

### タスク作成

```csharp
using Todoist.Models;

var created = await client.Tasks.CreateAsync(new CreateTaskArgs(
    content: "Review pull request",
    priority: 4));
```

### Quick Add

```csharp
using Todoist.Models;

var quick = await client.Tasks.QuickAddAsync(new QuickAddTaskArgs(
    text: "Pay rent tomorrow 9am #Admin"));
```

### ページング

```csharp
using Todoist.Models;

string? cursor = null;
do
{
    var page = await client.Tasks.GetPageAsync(
        args: new GetTasksArgs { Filter = "today" },
        cursor: cursor);

    foreach (var item in page.Items)
    {
        Console.WriteLine(item.Content);
    }

    cursor = page.NextCursor;
}
while (!string.IsNullOrEmpty(cursor));
```

## OAuth 補助機能

Todoist OAuth URL 生成用のヘルパーを提供しています:

- `Authentication.GetAuthStateParameter()`
- `Authentication.GetAuthorizationUrl(clientId, permissions, state)`

トークン交換・失効 API は `client.AuthToken` から利用できます。

## エラーハンドリング

- API エラー時は `TodoistException` が送出されます
- `TodoistException.StatusCode` で HTTP ステータスコード（取得可能な場合）を参照できます

例:

```csharp
try
{
    var task = await client.Tasks.GetAsync("task-id");
}
catch (TodoistException ex)
{
    Console.WriteLine($"Error: {ex.StatusCode} - {ex.Message}");
}
```

## ローカルでのテスト実行

リポジトリルートで実行:

```bash
dotnet test --nologo
```

## ライセンス

MIT License。詳細は [LICENSE](LICENSE) を参照してください。
