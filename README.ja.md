<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X Payment Alipay

[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.payment.alipay)](https://github.com/GameFrameX/com.gameframex.unity.payment.alipay/blob/main/LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.payment.alipay)](https://github.com/GameFrameX/com.gameframex.unity.payment.alipay/releases)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

インディゲーム開発者向けオールインワンソリューション · インディ開発者の夢を支援

<br />

[ドキュメント](https://gameframex.doc.alianblank.com) · [クイックスタート](#クイックスタート) · QQグループ: 467608841 / 233840761

<br />

[English](README.md) | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | **日本語** | [한국어](README.ko.md)

</div>
## プロジェクト概要

**Payment Alipay コンポーネント** - Unity 向け Alipay（支付宝）決済統合を提供します。Android、iOS、および Editor シミュレーションモードをサポートします。

### 機能

- `IAlipayManager` を通じた統一決済インターフェース
- Android サポート（`com.alipay.sdk.app.PayTask` 経由）
- iOS サポート（ネイティブライブラリコール経由）
- Editor シミュレーションテスト（成功コールバックのシミュレーション）
- コールバックがメインスレッドで実行されるよう自動スレッド切り替え

## クイックスタート

### インストール

以下のいずれかの方法を選択してください：

1. プロジェクトの `manifest.json` の `dependencies` セクションに以下を追加：
   ```json
   {"com.gameframex.unity.payment.alipay": "https://github.com/AlianBlank/com.gameframex.unity.payment.alipay.git"}
   ```
2. Unity の `Package Manager` で `Git URL` を使用して追加：https://github.com/AlianBlank/com.gameframex.unity.payment.alipay.git
3. リポジトリをダウンロードして Unity プロジェクトの `Packages` ディレクトリに配置（自動的に読み込まれます）。

### 使用例

```csharp
using GameFrameX.Runtime;
using GameFrameX.Payment.Alipay.Runtime;

public class PaymentExample : MonoBehaviour
{
    private void Start()
    {
        // 1. Alipay マネージャーインターフェースを取得
        var alipayManager = GameFrameworkEntry.GetModule<IAlipayManager>();

        if (alipayManager != null)
        {
            // 2. 注文情報を準備（通常はサーバーで生成）
            string orderInfo = "app_id=...&biz_content=...&sign=...";

            // 3. 決済を開始
            alipayManager.Pay(orderInfo, OnPayResult);
        }
    }

    private void OnPayResult(AlipayResult result)
    {
        Debug.Log($"決済ステータス: {result.resultStatus}");
        Debug.Log($"決済結果: {result.result}");
        Debug.Log($"メモ: {result.memo}");

        if (result.resultStatus == "9000")
        {
            Debug.Log("決済成功");
        }
        else
        {
            Debug.LogError("決済失敗またはキャンセル");
        }
    }
}
```

シーンに `AlipayComponent` が存在することを確認してください。通常、GameFrameX フレームワークの一部として自動的にロードされるか、GameObject に手動でアタッチします。

## プラットフォーム対応

| プラットフォーム | 対応 |
|-----------------|------|
| Android | はい |
| iOS | はい |
| Editor（シミュレーション） | はい |

## ドキュメントとリソース

- [ドキュメント](https://gameframex.doc.alianblank.com)
- [GitHub リポジトリ](https://github.com/GameFrameX/com.gameframex.unity.payment.alipay)

## コミュニティとサポート

- QQグループ：[QRコード](https://qm.qq.com/cgi-bin/qm/qr?k=ikT9gA5m2sKwOyNOfYmQvSAPK_c3GmD6)から参加

## ライセンス

このプロジェクトは [LICENSE](LICENSE) ファイルに定義された条件に基づいてライセンスされています。
