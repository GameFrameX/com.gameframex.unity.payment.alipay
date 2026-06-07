<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X Payment Alipay

[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.payment.alipay)](https://github.com/GameFrameX/com.gameframex.unity.payment.alipay/blob/main/LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.payment.alipay)](https://github.com/GameFrameX/com.gameframex.unity.payment.alipay/releases)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

独立游戏前后端一体化解决方案 · 独立游戏开发者的圆梦大使

<br />

[文档](https://gameframex.doc.alianblank.com) · [快速开始](#快速开始) · QQ群: 467608841 / 233840761

<br />

[English](README.md) | **简体中文** | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | [한국어](README.ko.md)

</div>
## 项目简介

**Payment Alipay 支付宝支付组件** - 提供 Unity 支付宝支付集成。支持 Android、iOS 和 Editor 模拟模式。

### 功能特性

- 提供统一的支付接口 `IAlipayManager`
- 支持 Android 平台（通过 `com.alipay.sdk.app.PayTask`）
- 支持 iOS 平台（通过原生库调用）
- 支持 Editor 模拟测试（模拟支付成功回调）
- 自动处理线程切换，确保回调在主线程执行

## 快速开始

### 安装方式

任选其一：

1. 直接在 `manifest.json` 的文件中的 `dependencies` 节点下添加以下内容
   ```json
   {"com.gameframex.unity.payment.alipay": "https://github.com/AlianBlank/com.gameframex.unity.payment.alipay.git"}
   ```
2. 在 Unity 的 `Packages Manager` 中使用 `Git URL` 的方式添加库，地址为：https://github.com/AlianBlank/com.gameframex.unity.payment.alipay.git
3. 直接下载仓库放置到 Unity 项目的 `Packages` 目录下，会自动加载识别。

### 使用示例

```csharp
using GameFrameX.Runtime;
using GameFrameX.Payment.Alipay.Runtime;

public class PaymentExample : MonoBehaviour
{
    private void Start()
    {
        // 1. 获取支付宝管理器接口
        var alipayManager = GameFrameworkEntry.GetModule<IAlipayManager>();

        if (alipayManager != null)
        {
            // 2. 准备订单信息（通常由服务端生成）
            string orderInfo = "app_id=...&biz_content=...&sign=...";

            // 3. 发起支付
            alipayManager.Pay(orderInfo, OnPayResult);
        }
    }

    private void OnPayResult(AlipayResult result)
    {
        Debug.Log($"支付状态: {result.resultStatus}");
        Debug.Log($"支付结果: {result.result}");
        Debug.Log($"备注信息: {result.memo}");

        if (result.resultStatus == "9000")
        {
            Debug.Log("支付成功");
        }
        else
        {
            Debug.LogError("支付失败或取消");
        }
    }
}
```

确保场景中存在 `AlipayComponent` 组件。通常该组件会作为 GameFrameX 框架的一部分自动加载，或者手动挂载在某个 GameObject 上。

## 平台支持

| 平台 | 支持 |
|------|------|
| Android | 是 |
| iOS | 是 |
| Editor（模拟） | 是 |

## 文档与资源

- [文档](https://gameframex.doc.alianblank.com)
- [GitHub 仓库](https://github.com/GameFrameX/com.gameframex.unity.payment.alipay)

## 社区与支持

- QQ群：通过 [二维码](https://qm.qq.com/cgi-bin/qm/qr?k=ikT9gA5m2sKwOyNOfYmQvSAPK_c3GmD6) 加入

## 开源协议

本项目基于 [LICENSE](LICENSE) 文件中定义的条款授权。
