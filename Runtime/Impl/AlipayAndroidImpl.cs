// ==========================================================================================
//  GameFrameX 组织及其衍生项目的版权、商标、专利及其他相关权利
//  GameFrameX organization and its derivative projects' copyrights, trademarks, patents, and related rights
//  均受中华人民共和国及相关国际法律法规保护。
//  are protected by the laws of the People's Republic of China and relevant international regulations.
// 
//  使用本项目须严格遵守相应法律法规及开源许可证之规定。
//  Usage of this project must strictly comply with applicable laws, regulations, and open-source licenses.
// 
//  本项目采用 MIT 许可证与 Apache License 2.0 双许可证分发，
//  This project is dual-licensed under the MIT License and Apache License 2.0,
//  完整许可证文本请参见源代码根目录下的 LICENSE 文件。
//  please refer to the LICENSE file in the root directory of the source code for the full license text.
// 
//  禁止利用本项目实施任何危害国家安全、破坏社会秩序、
//  It is prohibited to use this project to engage in any activities that endanger national security, disrupt social order,
//  侵犯他人合法权益等法律法规所禁止的行为！
//  or infringe upon the legitimate rights and interests of others, as prohibited by laws and regulations!
//  因基于本项目二次开发所产生的一切法律纠纷与责任，
//  Any legal disputes and liabilities arising from secondary development based on this project
//  本项目组织与贡献者概不承担。
//  shall be borne solely by the developer; the project organization and contributors assume no responsibility.
// 
//  GitHub 仓库：https://github.com/GameFrameX
//  GitHub Repository: https://github.com/GameFrameX
//  Gitee  仓库：https://gitee.com/GameFrameX
//  Gitee Repository:  https://gitee.com/GameFrameX
//  官方文档：https://gameframex.doc.alianblank.com/
//  Official Documentation: https://gameframex.doc.alianblank.com/
// ==========================================================================================


#if UNITY_ANDROID
using System;
using UnityEngine;

namespace GameFrameX.Payment.Alipay.Runtime
{
    [UnityEngine.Scripting.Preserve]
    public sealed class AlipayAndroidImpl : IAlipayImpl
    {
        private const string JavaClassName = "com.gameframex.unity.payment.alipay.AlipayMainActivity";

        private AndroidJavaClass _javaClass;

        [UnityEngine.Scripting.Preserve]
        private AndroidJavaClass ClassInstance
        {
            get { return _javaClass ??= new AndroidJavaClass(JavaClassName); }
        }

        /// <summary>
        /// 初始化支付宝支付
        /// </summary>
        /// <param name="appId">支付宝分配的应用ID</param>
        /// <param name="isSandbox">是否为沙箱环境</param>
        [UnityEngine.Scripting.Preserve]
        public void Init(string appId, bool isSandbox)
        {
            ClassInstance.CallStatic("init", appId, isSandbox);
        }

        /// <summary>
        /// 唤起支付
        /// </summary>
        /// <param name="orderInfo">服务端返回的订单签名串</param>
        /// <param name="callback">支付结果回调</param>
        [UnityEngine.Scripting.Preserve]
        public void Pay(string orderInfo, Action<AlipayResult> callback)
        {
            // 更新回调 Action
            // 注意：这会覆盖之前的回调。如果在极短时间内发起多次支付，只有最后一次的回调会被触发。
            // 考虑到支付通常是模态的，这通常不是问题。
            AliPayLinkBridge.Instance.OnResultAction = callback;

            // 调用 Java 端
            try
            {
                ClassInstance.CallStatic("pay", orderInfo);
            }
            catch (Exception e)
            {
                Debug.LogError("[AlipayAndroid] Failed to call AlipayMainActivity.pay: " + e.Message);
            }
        }
    }
}
#endif