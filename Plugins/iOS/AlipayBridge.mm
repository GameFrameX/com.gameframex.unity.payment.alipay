#import <Foundation/Foundation.h>
#import <AlipaySDK/AlipaySDK.h>

NSString *g_AlipayScheme = nil;

// 导出函数：初始化
extern "C" void __gameframex_alipay_init(const char* appId, bool isSandbox) {
    if (appId) {
        // 注意：这里的 appId 应与 Info.plist 中的 URL Scheme 一致
        // 如果你的 Scheme 有前缀（如 'ali' + appId），请在此处拼接
        g_AlipayScheme = [NSString stringWithUTF8String:appId];
        NSLog(@"[AlipayBridge] Initialized with scheme: %@", g_AlipayScheme);
    }
}

// 导出函数：支付
extern "C" void __gameframex_alipay_pay(const char* orderInfo) {
    if (orderInfo == NULL) {
        NSLog(@"[AlipayBridge] Order info is null");
        return;
    }
    
    NSString *orderStr = [NSString stringWithUTF8String:orderInfo];
    
    // 调用支付宝 SDK
    // 注意：fromScheme 必须与 Info.plist 中配置的一致，否则无法跳转回 App
    [[AlipaySDK defaultService] payOrder:orderStr fromScheme:g_AlipayScheme callback:^(NSDictionary *resultDic) {
        // 这个 block 主要用于 H5 支付回调或未安装支付宝 App 的情况
        NSLog(@"[AlipayBridge] payOrder callback called");
        // 将结果字典转换为 JSON 字符串
        NSError *error;
        NSData *jsonData = [NSJSONSerialization dataWithJSONObject:resultDic options:0 error:&error];
        NSString *jsonString = @"";
        if (!error) {
            jsonString = [[NSString alloc] initWithData:jsonData encoding:NSUTF8StringEncoding];
        }
        // 发送消息给 Unity
        UnitySendMessage("AliPayLinkBridge", "OnMessage", [jsonString UTF8String]);
    }];
}
