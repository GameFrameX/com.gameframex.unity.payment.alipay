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

using GameFrameX.Payment.Runtime;

namespace GameFrameX.Payment.Alipay.Runtime
{
    /// <summary>
    /// 支付宝购买参数
    /// </summary>
    public sealed class AlipayPurchaseParams : PurchaseParams
    {
        /// <summary>
        /// 服务端生成的签名订单串
        /// </summary>
        [UnityEngine.Scripting.Preserve]
        public string OrderInfo { get; set; }

        /// <summary>
        /// 支付宝应用ID
        /// <para>iOS 端作为 fromScheme 使用，必须与 Info.plist 中配置的 URL Scheme 一致；Android 端收单支付不需要。</para>
        /// </summary>
        [UnityEngine.Scripting.Preserve]
        public string AppId { get; set; }

        [UnityEngine.Scripting.Preserve]
        public AlipayPurchaseParams(string productId, string orderId, string orderInfo)
            : base(productId, orderId, PaymentProductType.InApp)
        {
            OrderInfo = orderInfo;
            ChannelId = AlipayManager.ChannelId;
        }
    }
}
