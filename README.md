# Todoist API C# Client

This is the unofficial C# API client for the Todoist REST API.


## Installation

```sh
dotnet add package Todoist
```


## Usage

An example of initializing the API client and fetching a user's tasks:

```cs
using Todoist;

var client = new TodoistClient("YOURTOKEN");

var tasks = await client.Tasks.GetAllAsync();

foreach (var task in tasks)
{
    Console.WriteLine(task.Content);
}
```

## Todoist API v1 移行プラン（実装直前レベル）

Todoist API v1（`https://developer.todoist.com/api/v1/`）への移行に向けて、現行実装（`rest/v2` + 一部 `sync/v8` 定数）からの最小リスク移行を以下の手順で進めます。

### 0. 事前確認（着手前チェック）

- [ ] 公式 v1 ドキュメントの「Migration Guide」「Reference」で以下を確定  
  - base path（`/api/v1` か `/rest/v1` か）  
  - OAuth token endpoint の変更有無  
  - 各リソース（tasks/projects/sections/labels/comments/shared labels/collaborators）の URL・HTTP メソッド・レスポンスコード  
  - ページング仕様・エラー仕様
- [ ] 互換性方針を決定  
  - **破壊的変更許容**（v2 を v1 で置換）  
  - もしくは **後方互換維持**（v2/v1 切替可能）

### 1. エンドポイント集約層の切替

対象: `/home/runner/work/Todoist/Todoist/src/Todoist/Endpoints.cs`

1. `API_REST_BASE_URI = "/rest/v2/"` を v1 の base path に変更
2. 使われていない `sync/v8` 関連（`API_SYNC_BASE_URI`, `GetSyncBaseUri`, `ENDPOINT_SYNC_QUICK_ADD`）の扱いを決定  
   - v1 で不要なら削除  
   - 将来利用予定なら obsolete 化
3. 認証系 endpoint（`ENDPOINT_GET_TOKEN`, `ENDPOINT_REVOKE_TOKEN`）を v1 仕様で再確認し、必要なら更新

### 2. 各 Client 実装の仕様差分吸収

対象: `/home/runner/work/Todoist/Todoist/src/Todoist/Clients/*.cs`

- `TasksClient`, `ProjectsClient`, `SectionsClient`, `LabelsClient`, `SharedLabelsClient`, `CommentsClient`, `CollaboratorsClient`, `AuthTokenClient`
- 変更手順:
  1. 各メソッドの request URI を v1 仕様に合わせる
  2. v1 で HTTP メソッド変更があるもの（例: POST→PATCH 等）があれば `HttpClientExtensions` に最小拡張を追加
  3. v1 で 204/200 の扱いが変わるエンドポイントは `DeserializeAsync` 呼び出し有無を調整（NoContentで本文前提にならないようにする）
  4. クエリ形式（`ids` など）が v1 で変更された場合に `GetTasksArgs` / `GetCommentsArgs` の組み立てを更新

### 3. リクエスト/レスポンスモデル整合

対象: `/home/runner/work/Todoist/Todoist/src/Todoist/Models/Request/*.cs`, `/home/runner/work/Todoist/Todoist/src/Todoist/Models/Response/*.cs`

1. v1 で追加/変更/廃止されたフィールドを反映（nullable/型を含む）
2. JSON プロパティ名に差異がある場合は既存シリアライズ方針に合わせて最小修正
3. 破壊的変更が大きい場合のみ v1 専用 DTO の追加を検討（既存型の大規模改変は避ける）

### 4. テスト更新（URL固定値 + 仕様差分）

対象: `/home/runner/work/Todoist/Todoist/test/Todoist.Tests/*.cs`

1. まず URL アサーションを v1 base path に更新  
   - `TasksApiTest`, `ProjectsApiTest`, `SectionsApiTest`, `LabelsApiTest`, `SharedLabelsApiTest`, `CommentsApiTest`
2. 認証 endpoint 変更がある場合は `TokenApiTest` を更新
3. ステータスコード/レスポンス形式差分があるケース（特に Update/Delete/Close/Reopen）を個別に調整
4. 既存挙動の回帰確認として `dotnet test` を実行

### 5. 実装順序（最小差分で安全に進める順）

1. `Endpoints.cs` のみ変更して全テストの失敗点を可視化  
2. 失敗テストを単位に Client を修正  
3. モデル差分が必要な箇所だけ DTO を調整  
4. README の usage 表記を v1 ベースに更新  
5. 最終で `dotnet test` 全件確認

### 6. 受け入れ条件（Definition of Done）

- [ ] すべての API 呼び出しが Todoist API v1 公式仕様と一致
- [ ] 既存公開インターフェース（`ITodoistClient` と各 `I*Client`）を可能な限り維持
- [ ] テストがすべてグリーン（少なくとも現行テスト + 仕様差分の追加検証）
- [ ] README に v1 前提であることを明記
