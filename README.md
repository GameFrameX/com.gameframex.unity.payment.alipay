# HOMEPAGE

GameFrameX 的 支付宝支付 组件

**Game Frame X Payment Alipay** - 提供 支付宝支付 相关的接口和实现。

# 使用文档

## 功能特性

- 提供统一的支付接口 `IAlipayManager`
- 支持 Android 平台 (通过 `com.alipay.sdk.app.PayTask`)
- 支持 iOS 平台 (通过原生库调用)
- 支持 Editor 模拟测试 (模拟支付成功回调)
- 自动处理线程切换，确保回调在主线程执行

## 安装方式(任选其一)

1. 直接在 `manifest.json` 的文件中的 `dependencies` 节点下添加以下内容
   ```json
      {"com.gameframex.unity.payment.alipay": "https://github.com/gameframex/com.gameframex.unity.payment.alipay.git"}
    ```
2. 在Unity 的`Packages Manager` 中使用`Git URL` 的方式添加库,地址为：https://github.com/gameframex/com.gameframex.unity.payment.alipay.git

3. 直接下载仓库放置到Unity 项目的`Packages` 目录下。会自动加载识别

## 使用示例

### 1. 获取接口并调用支付

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
            // 2. 准备订单信息 (通常由服务端生成)
            string orderInfo = "app_id=2015052600090779&biz_content=%7B%22timeout_express%22%3A%2230m%22%2C%22product_code%22%3A%22QUICK_MSECURITY_PAY%22%2C%22total_amount%22%3A%220.01%22%2C%22subject%22%3A%221%22%2C%22body%22%3A%22%E6%88%91%E6%98%AF%E6%B5%8B%E8%AF%95%E6%95%B0%E6%8D%AE%22%2C%22out_trade_no%22%3A%22IQJZSRC1YMQB5HU%22%7D&charset=utf-8&format=json&method=alipay.trade.app.pay&notify_url=http%3A%2F%2Fdomain.com%2Fnotify_url&sign_type=RSA2&timestamp=2016-08-25%2020%3A26%3A31&version=1.0&sign=cYmuUnKi5QdBsoZEAb%2BBt%2BzqFitrh5OxO49Kuw13XqYSyMAPLo2jXauHeL4WCg62gpF2T3fqP2jHSHLO6b3WRT%2B5UP5gOBCgXJT5s8lriaYkueqJ5sS8DUBAH8%2F%2Fjx77E71p6hAOHWDq61W%2F2s%2FqaB1n3nJoPEg%2FzQw6L959wK%2F8M%2B4S9f4mlM8M%2FKm5X9aA5uO%2F7%2F0%2F4%2F";

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

### 2. 在场景中配置

确保场景中存在 `AlipayComponent` 组件。通常该组件会作为 GameFrameX 框架的一部分自动加载，或者手动挂载在某个 GameObject 上。

- 在 Hierarchy 中创建一个 GameObject (推荐命名为 `GameFramework`)。
- 添加 `AlipayComponent` 组件。
