// ==========================================================================================
//   GameFrameX 组织及其衍生项目的版权、商标、专利及其他相关权利
//   GameFrameX organization and its derivative projects' copyrights, trademarks, patents, and related rights
//   均受中华人民共和国及相关国际法律法规保护。
//   are protected by the laws of the People's Republic of China and relevant international regulations.
//   使用本项目须严格遵守相应法律法规及开源许可证之规定。
//   Usage of this project must strictly comply with applicable laws, regulations, and open-source licenses.
//   本项目采用 MIT 许可证与 Apache License 2.0 双许可证分发，
//   This project is dual-licensed under the MIT License and Apache License 2.0,
//   完整许可证文本请参见源代码根目录下的 LICENSE 文件。
//   please refer to the LICENSE file in the root directory of the source tree for the full license text.
//   禁止利用本项目实施任何危害国家安全、破坏社会秩序、
//   It is prohibited to use this project to engage in any activities that endanger national security, disrupt social order,
//   侵犯他人合法权益等法律法规所禁止的行为！
//   or infringe upon the legitimate rights and interests of others, as prohibited by laws and regulations.
//   因基于本项目二次开发所产生的一切法律纠纷与责任，
//   Any legal disputes and liabilities arising from secondary development based on this project
//   本组织及贡献者概不承担。
//   shall be borne solely by the developer; the project organization and contributors assume no responsibility.
// ==========================================================================================

using System;
using GameFrameX.Payment.Runtime;
using GameFrameX.Runtime;

namespace GameFrameX.Payment.Alipay.Runtime
{
    /// <summary>
    /// 支付宝支付管理器实现
    /// </summary>
    /// <remarks>
    /// 作为 <see cref="IPaymentManager"/> 的渠道实现，通过 PaymentComponent 的平台实现配置选中，
    /// 不再提供独立的 Component。
    /// </remarks>
    [UnityEngine.Scripting.Preserve]
    public sealed class AlipayManager : BasePaymentManager
    {
        /// <summary>
        /// 支付宝渠道唯一标识
        /// </summary>
        public const string ChannelId = "alipay";

        private IAlipayImpl _impl;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="isDebug">是否是沙盒模式（支付宝收单由服务端下单环境决定，客户端不支持切换）</param>
        /// <param name="isClientVerify">是否执行客户端验证购买成功</param>
        [UnityEngine.Scripting.Preserve]
        public override void Init(bool isDebug = false, bool isClientVerify = false)
        {
            // 支付宝收单模式：订单串由服务端签名生成，客户端无需初始化。
            // 不调用原生 init：Android 端会强制切换到沙箱环境，iOS 端忽略沙盒参数。
        }

        /// <summary>
        /// 支付系统是否准备好
        /// </summary>
        /// <returns>准备好返回true，否则返回false</returns>
        [UnityEngine.Scripting.Preserve]
        public override bool IsReady()
        {
#if UNITY_ANDROID || UNITY_IOS
            return true;
#else
            return false;
#endif
        }

        /// <summary>
        /// 设置预加载的预定义商品ID,用于预加载缓存,注意：此方法必须在Initialize()之前调用
        /// </summary>
        /// <param name="inAppProductIds">内购商品ID列表</param>
        /// <param name="subsProductIds">订阅商品ID列表</param>
        [UnityEngine.Scripting.Preserve]
        public override void SetPredefinedProductIds(System.Collections.Generic.List<string> inAppProductIds, System.Collections.Generic.List<string> subsProductIds)
        {
        }

        /// <summary>
        /// 查询购买记录
        /// </summary>
        /// <param name="productType">产品类型</param>
        [UnityEngine.Scripting.Preserve]
        public override void QueryPurchases(PaymentProductType productType)
        {
            Log.Warning("支付宝支付不支持查询购买记录");
        }

        /// <summary>
        /// 消耗购买
        /// </summary>
        /// <param name="purchaseToken">购买令牌</param>
        [UnityEngine.Scripting.Preserve]
        public override void ConsumePurchase(string purchaseToken)
        {
            Log.Warning("支付宝支付不支持消耗购买");
        }

        /// <summary>
        /// 购买 一次性商品
        /// </summary>
        [UnityEngine.Scripting.Preserve]
        [Obsolete("请使用 Buy(PurchaseParams) 替代")]
        public override void BuyInApp(string productId, string orderId, string offerToken = "", string customData = "")
        {
            throw new NotImplementedException("请使用 Buy(PurchaseParams) 传入 AlipayPurchaseParams 来支付");
        }

        /// <summary>
        /// 购买 订阅商品
        /// </summary>
        [UnityEngine.Scripting.Preserve]
        [Obsolete("请使用 Buy(PurchaseParams) 替代")]
        public override void BuySubs(string productId, string orderId, string offerToken = "", string customData = "")
        {
            throw new NotImplementedException("支付宝支付不支持购买订阅商品");
        }

        /// <summary>
        /// 购买
        /// </summary>
        [UnityEngine.Scripting.Preserve]
        [Obsolete("请使用 Buy(PurchaseParams) 替代")]
        public override void Buy(string productId, PaymentProductType productType, string orderId, string offerToken = "", string customData = "")
        {
            throw new NotImplementedException("请使用 Buy(PurchaseParams) 传入 AlipayPurchaseParams 来支付");
        }

        /// <summary>
        /// 购买（推荐使用）
        /// </summary>
        /// <param name="purchaseParams">购买参数，必须使用 AlipayPurchaseParams</param>
        [UnityEngine.Scripting.Preserve]
        public override void Buy(PurchaseParams purchaseParams)
        {
            if (!(purchaseParams is AlipayPurchaseParams alipayParams))
            {
                throw new ArgumentException("支付宝支付请使用 AlipayPurchaseParams", nameof(purchaseParams));
            }

            if (string.IsNullOrEmpty(alipayParams.OrderInfo))
            {
                throw new ArgumentException("OrderInfo 不能为空，订单串需由服务端签名生成", nameof(purchaseParams));
            }

            if (_impl == null)
            {
                _impl = CreateImpl();
            }

            if (_impl == null)
            {
                Log.Error("当前平台不支持支付宝支付");
                return;
            }

            var productId = alipayParams.ProductId;
            var orderId = alipayParams.OrderId;
            _impl.Pay(alipayParams, result => OnPayResult(productId, orderId, result));
        }

        private static IAlipayImpl CreateImpl()
        {
#if UNITY_ANDROID
            return new AlipayAndroidImpl();
#elif UNITY_IOS
            return new AlipayIOSImpl();
#else
            return null;
#endif
        }

        private void OnPayResult(string productId, string orderId, AlipayResult result)
        {
            var eventArgs = new PaymentEventArgs
            {
                ProductId = productId,
                OrderId = orderId,
                ResultCode = result == null ? PaymentResultCode.Unknown : MapResultCode(result.resultStatus),
                ErrorMessage = result == null ? "Alipay result is null." : result.memo,
                PurchaseData = result == null ? null : result.result,
            };

            if (eventArgs.ResultCode == PaymentResultCode.Success)
            {
                RaisePurchaseSuccess(eventArgs);
            }
            else
            {
                RaisePurchaseFailed(eventArgs);
            }
        }

        /// <summary>
        /// 支付宝结果码映射
        /// </summary>
        private static PaymentResultCode MapResultCode(string resultStatus)
        {
            switch (resultStatus)
            {
                case "9000": // 订单支付成功
                    return PaymentResultCode.Success;
                case "6001": // 用户中途取消
                    return PaymentResultCode.Cancelled;
                case "6002": // 网络连接出错
                    return PaymentResultCode.NetworkError;
                case "8000": // 正在处理中
                case "6004": // 支付结果未知（以服务端核实为准）
                    return PaymentResultCode.Unknown;
                default:
                    return PaymentResultCode.Failed;
            }
        }
    }
}
