<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X Payment Alipay

[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.payment.alipay)](https://github.com/GameFrameX/com.gameframex.unity.payment.alipay/blob/main/LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.payment.alipay)](https://github.com/GameFrameX/com.gameframex.unity.payment.alipay/releases)
[![Unity Version](https://img.shields.io/badge/Unity-2019.4-black?logo=unity)](https://unity.com/)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

獨立遊戲前後端一體化解決方案 · 獨立遊戲開發者的圓夢大使

<br />

[文檔](https://gameframex.doc.alianblank.com) · [快速開始](#快速開始) · QQ群: 467608841 / 233840761

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

### 安裝

編輯 Unity 專案的 `Packages/manifest.json`，添加 `scopedRegistries` 部分：

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
  ]
}
```

`scopes` 控制哪些套件透過此註冊表解析。只有以 `com.gameframex` 開頭的套件才會從這個註冊表取得。

Then add the package to `dependencies`:

```json
{
  "dependencies": {
    "com.gameframex.unity.payment.alipay": "1.0.0"
  }
}
```


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


## 依賴

| 套件 | 說明 |
|------|------|
| `com.gameframex.unity` | 1.1.1 |

## 更新日誌

查看 [Releases](https://github.com/GameFrameX/gameframex/com.gameframex.unity.payment.alipay/releases) 了解更新日誌。
## 開源協議

本專案基於 [LICENSE](LICENSE) 文件中定義的條款授權。
