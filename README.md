# TutorialMoneyAdmin
家計簿アプリを作成。

## 使用ライブラリ
フレームワークは ASP.NET MVC 5 を利用する。MVCの理解を深める目的がある。  

### フロント
Razer, Bootstrap, jQuery。  
ajaxはaxios。  

### O/Rマッパー
Dapper を利用する。  
標準は Entity Framework だが大げさかつ動作が遅いので利用しない。  
変わりに軽量な Dapper を利用する。ちなみに Dapper は厳密にはORMではないが気にしない。  
SqlKata というクエリビルダはとてもいいらしいの導入を検討する。

### DIコンテナ
Autofac を検討する。  

### ログ出力
Log4Net を検討する。

### テストコード
MSTest を利用する。

### 静的解析
FxCopAnalyzerを検討する

### CI/CD
github+AWS CodeBuild を検討する。

### コード文書化
XML Documentation を DocFX か Sandcastle で整形する予定。  
https://docs.microsoft.com/ja-jp/dotnet/csharp/codedoc