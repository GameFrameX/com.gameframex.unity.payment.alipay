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

**Payment Alipay Component** - Provides Alipay payment integration for Unity. Supports Android, iOS, and Editor simulation mode.

### Features

- Unified payment interface via `IAlipayManager`
- Android support (via `com.alipay.sdk.app.PayTask`)
- iOS support (via native library calls)
- Editor simulation testing (simulates successful payment callback)
- Automatic thread switching to ensure callbacks run on the main thread

## Quick Start

### Installation

Edit your Unity project's `Packages/manifest.json` and add the `scopedRegistries` section:

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

`scopes` controls which packages are resolved through this registry. Only packages whose names start with `com.gameframex` will be fetched from it.

Then add the package to `dependencies`:

```json
{
  "dependencies": {
    "com.gameframex.unity.payment.alipay": "1.0.0"
  }
}
```

## Platform Support

| Platform | Supported |
|----------|-----------|
| Android | Yes |
| iOS | Yes |
| Editor (Simulation) | Yes |

## Documentation & Resources

- [Documentation](https://gameframex.doc.alianblank.com)
- [GitHub Repository](https://github.com/GameFrameX/com.gameframex.unity.payment.alipay)

## Community & Support

- QQ Group: Join via [QR Code](https://qm.qq.com/cgi-bin/qm/qr?k=ikT9gA5m2sKwOyNOfYmQvSAPK_c3GmD6)


## Dependencies

| Package | Description |
|---------|-------------|
| `com.gameframex.unity` | 1.1.1 |

## Changelog

See [Releases](https://github.com/GameFrameX/gameframex/com.gameframex.unity.payment.alipay/releases) for changelog.
## License

See [LICENSE.md](LICENSE.md) for license information.
