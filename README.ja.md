<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X Payment Alipay

[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.payment.alipay)](https://github.com/GameFrameX/com.gameframex.unity.payment.alipay/blob/main/LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.payment.alipay)](https://github.com/GameFrameX/com.gameframex.unity.payment.alipay/releases)
[![Unity Version](https://img.shields.io/badge/Unity-2019.4-black?logo=unity)](https://unity.com/)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

インディゲーム開発者向けオールインワンソリューション · インディ開発者の夢を支援

<br />

[ドキュメント](https://gameframex.doc.alianblank.com) · [クイックスタート](#クイックスタート) · QQグループ: 467608841 / 233840761

<br />

[English](README.md) | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | **日本語** | [한국어](README.ko.md)

</div>

## プロジェクト概要

**Payment Alipay コンポーネント** - Unity 向け Alipay（支付宝）決済統合を提供します。`IPaymentManager` のチャネル実装として `PaymentComponent` に組み込まれ、専用コンポーネントは不要です。Android と iOS に対応します。

### 機能

- `IPaymentManager` の Alipay チャネル実装。本パッケージをインストールすると起動時に `alipay` チャネルとして自動登録され（実機 Android / iOS のみ）、`AlipayPurchaseParams` が自動ルーティングします。`PaymentComponent` の設定は不要です
- サーバーが署名した注文文字列を `AlipayPurchaseParams` で渡して決済を開始し、結果は `OnPurchaseSuccess` / `OnPurchaseFailed` イベントで統一的に通知されます
- Android サポート（`com.alipay.sdk.app.PayTask` 経由）
- iOS サポート（ネイティブライブラリコール経由、`AppId` は Info.plist の URL Scheme と一致させる必要があります）
- コールバックがメインスレッドで実行されるよう自動スレッド切り替え
- 起動時に決済チャネルレジストリ（PaymentChannelRegistry）へ自動登録されます。本パッケージが未導入の場合は登録も行われません。利用可能なチャネルは `GetAvailableChannels()` で照会できます

### 使用例

```csharp
// 本パッケージのインストールで alipay チャネルが自動登録されます。PaymentComponent の設定は不要
// サーバーで注文を作成した後、署名済み注文文字列で決済を開始します
GameApp.Payment.Buy(new AlipayPurchaseParams(productId, orderId, orderInfo)
{
    AppId = "Alipay アプリID", // iOS では必須。Info.plist の URL Scheme と一致させること。Android では不要
});

// 利用可能な決済方法の照会（UI 表示用。購入パラメータは自動的に alipay チャネルへルーティングされます）
foreach (var channel in GameApp.Payment.GetAvailableChannels())
{
    // channel.ChannelId / channel.DisplayName / channel.IsAvailable
}

GameApp.Payment.OnPurchaseSuccess += (sender, e) => { // 決済結果はサーバー側の注文検証を優先 };
GameApp.Payment.OnPurchaseFailed += (sender, e) => { };
```


## クイックスタート

### インストール

以下のいずれかの方法を選択してください：

1. Unity プロジェクトの `Packages/manifest.json` を編集し、`scopedRegistries` セクションを追加してください：
   ```json
   {
     "scopedRegistries": [
       {
         "name": "GameFrameX",
         "url": "https://gameframex.upm.alianblank.uk",
         "scopes": [
           "com.gameframex"
         ]
       }
     ],
     "dependencies": {
       "com.gameframex.unity.payment.alipay": "1.0.0"
     }
   }
   ```

   `scopes` は、どのパッケージをこのレジストリから解決するかを制御します。`com.gameframex` で始まるパッケージのみがこのレジストリから取得されます。

2. `manifest.json` の `dependencies` に直接追加：
   ```json
   {
      "com.gameframex.unity.payment.alipay": "https://github.com/gameframex/com.gameframex.unity.payment.alipay.git"
   }
   ```
3. Unity の **Package Manager** で **Git URL** を使用して追加：`https://github.com/gameframex/com.gameframex.unity.payment.alipay.git`
4. リポジトリを Unity プロジェクトの `Packages` ディレクトリにクローンしてください。自動的に読み込まれます。
## プラットフォーム対応

| プラットフォーム | 対応 |
|-----------------|------|
| Android | はい |
| iOS | はい |
| Editor | いいえ（ログのみ） |

## ドキュメントとリソース

- [ドキュメント](https://gameframex.doc.alianblank.com)
- [GitHub リポジトリ](https://github.com/GameFrameX/com.gameframex.unity.payment.alipay)

## コミュニティとサポート

- QQグループ：[QRコード](https://qm.qq.com/cgi-bin/qm/qr?k=ikT9gA5m2sKwOyNOfYmQvSAPK_c3GmD6)から参加


## 依存関係

| パッケージ | 説明 |
|----------|------|
| `com.gameframex.unity` | 1.1.1 |
| `com.gameframex.unity.payment` | 2.0.0 |

## 変更履歴

[Releases](https://github.com/GameFrameX/gameframex/com.gameframex.unity.payment.alipay/releases) で変更履歴を確認してください。
## ライセンス

このプロジェクトは [LICENSE](LICENSE) ファイルに定義された条件に基づいてライセンスされています。
