using System.IO;
using UnityEditor;
using UnityEditor.Callbacks;
#if UNITY_IOS
using UnityEditor.iOS.Xcode;
#endif

namespace GameFrameX.Payment.Alipay.Editor
{
    public static class AlipayBuildPostProcessor
    {
        [PostProcessBuild(999)]
        public static void OnPostProcessBuild(BuildTarget target, string pathToBuiltProject)
        {
            if (target != BuildTarget.iOS)
            {
                return;
            }

#if UNITY_IOS
            // 1. 修改 Info.plist 以添加白名单
            string plistPath = Path.Combine(pathToBuiltProject, "Info.plist");
            PlistDocument plist = new PlistDocument();
            plist.ReadFromString(File.ReadAllText(plistPath));

            PlistElementDict rootDict = plist.root;

            // 添加 LSApplicationQueriesSchemes 白名单
            const string lsKey = "LSApplicationQueriesSchemes";
            PlistElementArray schemesArray;
            if (rootDict.values.ContainsKey(lsKey))
            {
                schemesArray = rootDict.values[lsKey].AsArray();
            }
            else
            {
                schemesArray = rootDict.CreateArray(lsKey);
            }

            // 避免重复添加
            bool hasAlipay = false;
            bool hasAlipayShare = false;
            foreach (var value in schemesArray.values)
            {
                string str = value.AsString();
                if (str == "alipay")
                {
                    hasAlipay = true;
                }

                if (str == "alipayshare")
                {
                    hasAlipayShare = true;
                }
            }

            if (!hasAlipay)
            {
                schemesArray.AddString("alipay");
            }

            if (!hasAlipayShare)
            {
                schemesArray.AddString("alipayshare");
            }


            // 写入文件
            File.WriteAllText(plistPath, plist.WriteToString());

            // 注意：URL Scheme 配置
            // 支付宝支付需要配置 URL Scheme 以便从支付宝 App 跳转回游戏。
            // 由于 AppID 在 Runtime 组件中配置，构建时无法自动获取，建议开发者手动在 Xcode 设置
            // 或者在此处硬编码添加。
            // 
            // 示例代码：
            // string appId = "your_alipay_app_id";
            // AddUrlScheme(pathToBuiltProject, appId);
#endif
        }

#if UNITY_IOS
        private static void AddUrlScheme(string pathToBuiltProject, string scheme)
        {
            string projectPath = PBXProject.GetPBXProjectPath(pathToBuiltProject);
            PBXProject project = new PBXProject();
            project.ReadFromString(File.ReadAllText(projectPath));

            // 获取主 Target
            string targetGuid = project.GetUnityMainTargetGuid();

            // 这里需要更复杂的逻辑来操作 Info.plist 中的 URL Types，
            // 通常建议修改 Info.plist 而不是 PBXProject，或者使用 plist.root.CreateArray("CFBundleURLTypes")
            // 具体实现略。
        }
#endif
    }
}