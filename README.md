# NanisuruAPI (version 1.0)

This is a Backend API is for my personal Bucket list app (Nanisuru, still private)


Features:
- JWT Auth token to make API calls.
- Database connection information is stored in AWS Paramter Store.
- Basic CRUD operations.
- Attaching a thumbnail in reference to the bucket item.

Update plans:
- Individual user settings for profile avatar/icon

Language/Framework/Database:
- C#
- ASP.Net Core 6
- MongoDB

Sensitive data stored in AWS Parameter Store.
Retrieved using Amazon.Extentions.Configuration.SystemsManager(4.0.0) package.

===================================

# NanisuruAPI　(なにするAPI) (バージョン 1.0)

これは個人用のバケットリストアプリ(Nanisuru)のためのバックエンドAPI。
Nanisuruのコードはまだ非公開。

機能:
- JWT認証トークン
- データベース接続情報はAWS Parameter Storeで保管
- 基本CRUDオペレーション
- Bucketアイテムに関連画像を一枚までアップロード

今後のアップデート:
- ユーザー毎のアバター設定

言語/フレームワーク/データベース:
- C#
- ASP.Net Core 6
- MongoDB

データベース情報などはAmazonのAWS Parameter Storeへ保管し、以下のパッケージで取得しています。
Amazon.Extentions.Configuration.SystemsManager(4.0.0) package.
