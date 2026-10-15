<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X Payment Alipay

[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.payment.alipay)](https://github.com/GameFrameX/com.gameframex.unity.payment.alipay/blob/main/LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.payment.alipay)](https://github.com/GameFrameX/com.gameframex.unity.payment.alipay/releases)
[![Unity Version](https://img.shields.io/badge/Unity-2019.4-black?logo=unity)](https://unity.com/)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

All-in-One Solution for Indie Game Development · Empowering Indie Developers' Dreams

<br />

[Documentation](https://gameframex.doc.alianblank.com) · [Quick Start](#quick-start) · QQ Group: 467608841 / 233840761

<br />

**English** | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | [한국어](README.ko.md)

</div>

## Project Overview

**Payment Alipay Component** - Provides Alipay payment integration for Unity as an `IPaymentManager` channel implementation plugged into `PaymentComponent`, with no separate component required. Supports Android and iOS.

### Features

- Implements the `IPaymentManager` Alipay channel; enable it by selecting `AlipayManager` as the platform payment manager on `PaymentComponent`
- Starts a payment with the server-signed order string via `AlipayPurchaseParams`; results are reported through the unified `OnPurchaseSuccess` / `OnPurchaseFailed` events
- Android support (via `com.alipay.sdk.app.PayTask`)
- iOS support (via native library calls; `AppId` must match the URL Scheme in Info.plist)
- Automatic thread switching to ensure callbacks run on the main thread
- Self-registers into the payment channel registry (PaymentChannelRegistry) at startup; the registration simply does not happen when this package is absent. Query available channels via `GetAvailableChannels()`

### Usage

```csharp
// Select GameFrameX.Payment.Alipay.Runtime.AlipayManager as the platform payment manager on PaymentComponent
// After the server creates the order, pay with the signed order string
GameApp.Payment.Buy(new AlipayPurchaseParams(productId, orderId, orderInfo)
{
    AppId = "your alipay app id", // Required on iOS, must match the URL Scheme in Info.plist; not needed for Android
});

// Query available payment methods (for UI display; purchase params are automatically bound to the alipay channel route)
foreach (var channel in GameApp.Payment.GetAvailableChannels())
{
    // channel.ChannelId / channel.DisplayName / channel.IsAvailable
}

GameApp.Payment.OnPurchaseSuccess += (sender, e) => { /* Verify the payment result against the server order */ };
GameApp.Payment.OnPurchaseFailed += (sender, e) => { };
```


## Quick Start

### Installation

Choose one of the following methods:

1. Edit your Unity project's `Packages/manifest.json` and add the `scopedRegistries` section:
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

   `scopes` controls which packages are resolved through this registry. Only packages whose names start with `com.gameframex` will be fetched from it.

2. Add to `manifest.json` dependencies:
   ```json
   {
      "com.gameframex.unity.payment.alipay": "https://github.com/gameframex/com.gameframex.unity.payment.alipay.git"
   }
   ```
3. Use **Package Manager** in Unity with **Git URL**: `https://github.com/gameframex/com.gameframex.unity.payment.alipay.git`
4. Clone the repository into your Unity project's `Packages` directory. It will be loaded automatically.
## Platform Support

| Platform | Supported |
|----------|-----------|
| Android | Yes |
| iOS | Yes |
| Editor | No (log only) |

## Documentation & Resources

- [Documentation](https://gameframex.doc.alianblank.com)
- [GitHub Repository](https://github.com/GameFrameX/com.gameframex.unity.payment.alipay)

## Community & Support

- QQ Group: Join via [QR Code](https://qm.qq.com/cgi-bin/qm/qr?k=ikT9gA5m2sKwOyNOfYmQvSAPK_c3GmD6)


## Dependencies

| Package | Description |
|---------|-------------|
| `com.gameframex.unity` | 1.1.1 |
| `com.gameframex.unity.payment` | 2.0.0 |

## Changelog

See [Releases](https://github.com/GameFrameX/gameframex/com.gameframex.unity.payment.alipay/releases) for changelog.
## License

See [LICENSE.md](LICENSE.md) for license information.
