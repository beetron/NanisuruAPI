# NanisuruAPI (version 1.0)

This is a Backend API is for a personal ToDo list.
The frontend is using Blazor Webassembly.  Repo will be changed from private to public soon..

Features:
- JWT Auth token to make API calls.
- User credentials to obtain Token are hardcoded and stored securely via AWS Paramter Store.
- Basic CRUD operations.

Update plans:
- Remove hardcoded user, and have user/pass combo searched in the database.
- Add new model(string) in MongodDB to store URL data. (For shop/restaurant links)
- Add new model(binary?string?) in MongoDB to store Image files to attach a single image to completed ToDo items.

Language/Framework/Database:
- C#
- ASP.Net Core 6
- MongoDB

Sensitive data stored in AWS Parameter Store.
Retrieved using Amazon.Extentions.Configuration.SystemsManager(4.0.0) package.

===================================

# NanisuruAPI　(なにするAPI) (バージョン 1.0)

これは個人用のToDoアプリのためのバックエンドAPIです。
フロントエンドのウェブアプリはAsp.netのBlazor Webassemblyを使用。
Repositoryのリンクはタッチアップが終わり次第後悔予定です。

機能:
- JWT認証トークン
- ユーザログイン情報は暫定的にハードコードしていますが、データはAWS Parameter Storeへ保管
- 基本CRUDオペレーション

今後のアップデート:
- ユーザログイン情報をコードから削除。データベース内でのUser+Passの照合を導入。
- URLを保管するためのModelをMongoDBへ新規に追加。ToDoアイテムに関連しているリンクを紐づける用。
- 画像データを保管するためのModelをMongoDBへ新規に追加。完了済みのToDoアイテムへ画像を一枚貼り付ける用。

言語/フレームワーク/データベース:
- C#
- ASP.Net Core 6
- MongoDB

データベース情報などはAmazonのAWS Parameter Storeへ保管し、以下のパッケージで取得しています。
Amazon.Extentions.Configuration.SystemsManager(4.0.0) package.
