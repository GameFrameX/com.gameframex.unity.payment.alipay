<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X Payment Alipay

[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.payment.alipay)](https://github.com/GameFrameX/com.gameframex.unity.payment.alipay/blob/main/LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.payment.alipay)](https://github.com/GameFrameX/com.gameframex.unity.payment.alipay/releases)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

獨立遊戲前後端一體化解決方案 · 獨立遊戲開發者的圓夢大使

<br />

[文檔](https://gameframex.doc.alianblank.com) · [快速開始](#快速開始) · [QQ群](https://qm.qq.com/cgi-bin/qm/qr?k=ikT9gA5m2sKwOyNOfYmQvSAPK_c3GmD6)

<br />

[English](README.md) | [简体中文](README.zh-CN.md) | **繁體中文** | [日本語](README.ja.md) | [한국어](README.ko.md)

</div>
## 項目簡介

**Payment Alipay 支付寶支付組件** - 提供 Unity 支付寶支付整合。支援 Android、iOS 和 Editor 模擬模式。

### 功能特性

- 提供統一的支付介面 `IAlipayManager`
- 支援 Android 平台（透過 `com.alipay.sdk.app.PayTask`）
- 支援 iOS 平台（透過原生庫呼叫）
- 支援 Editor 模擬測試（模擬支付成功回呼）
- 自動處理執行緒切換，確保回呼在主執行緒執行

## 快速開始

### 安裝方式

任選其一：

1. 直接在 `manifest.json` 的文件中的 `dependencies` 節點下新增以下內容
   ```json
   {"com.gameframex.unity.payment.alipay": "https://github.com/AlianBlank/com.gameframex.unity.payment.alipay.git"}
   ```
2. 在 Unity 的 `Packages Manager` 中使用 `Git URL` 的方式新增庫，地址為：https://github.com/AlianBlank/com.gameframex.unity.payment.alipay.git
3. 直接下載倉庫放置到 Unity 專案的 `Packages` 目錄下，會自動載入識別。

### 使用範例

```csharp
using GameFrameX.Runtime;
using GameFrameX.Payment.Alipay.Runtime;

public class PaymentExample : MonoBehaviour
{
    private void Start()
    {
        // 1. 取得支付寶管理器介面
        var alipayManager = GameFrameworkEntry.GetModule<IAlipayManager>();

        if (alipayManager != null)
        {
            // 2. 準備訂單資訊（通常由伺服器產生）
            string orderInfo = "app_id=...&biz_content=...&sign=...";

            // 3. 發起支付
            alipayManager.Pay(orderInfo, OnPayResult);
        }
    }

    private void OnPayResult(AlipayResult result)
    {
        Debug.Log($"支付狀態: {result.resultStatus}");
        Debug.Log($"支付結果: {result.result}");
        Debug.Log($"備註資訊: {result.memo}");

        if (result.resultStatus == "9000")
        {
            Debug.Log("支付成功");
        }
        else
        {
            Debug.LogError("支付失敗或取消");
        }
    }
}
```

確保場景中存在 `AlipayComponent` 組件。通常該組件會作為 GameFrameX 框架的一部分自動載入，或者手動掛載在某個 GameObject 上。

## 平台支援

| 平台 | 支援 |
|------|------|
| Android | 是 |
| iOS | 是 |
| Editor（模擬） | 是 |

## 文檔與資源

- [文檔](https://gameframex.doc.alianblank.com)
- [GitHub 倉庫](https://github.com/GameFrameX/com.gameframex.unity.payment.alipay)

## 社區與支援

- QQ群：透過 [二維碼](https://qm.qq.com/cgi-bin/qm/qr?k=ikT9gA5m2sKwOyNOfYmQvSAPK_c3GmD6) 加入

## 開源協議

本專案基於 [LICENSE](LICENSE) 文件中定義的條款授權。
