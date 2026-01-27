using System;

namespace GameFrameX.Payment.Alipay.Runtime
{
    /// <summary>
    /// 支付宝支付接口实现
    /// </summary>
    [UnityEngine.Scripting.Preserve]
    public interface IAlipayImpl
    {
        /// <summary>
        /// 初始化支付宝支付
        /// </summary>
        /// <param name="appId">支付宝分配的应用ID</param>
        /// <param name="isSandbox">是否为沙箱环境</param>
        [UnityEngine.Scripting.Preserve]
        void Init(string appId, bool isSandbox);

        /// <summary>
        /// 唤起支付
        /// </summary>
        /// <param name="orderInfo">服务端返回的订单签名串</param>
        /// <param name="callback">支付结果回调</param>
        [UnityEngine.Scripting.Preserve]
        void Pay(string orderInfo, Action<AlipayResult> callback);
    }
}