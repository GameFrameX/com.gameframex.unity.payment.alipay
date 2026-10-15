#import <Foundation/Foundation.h>
#import <AlipaySDK/AlipaySDK.h>

// 导出函数：支付
// orderInfo: 服务端生成的签名订单串
// scheme: 与 Info.plist 中 URL Scheme 一致的支付宝应用ID，用于支付完成后跳回 App
extern "C" void __gameframex_alipay_pay(const char* orderInfo, const char* scheme) {
    if (orderInfo == NULL) {
        NSLog(@"[AlipayBridge] Order info is null");
        return;
    }

    NSString *orderStr = [NSString stringWithUTF8String:orderInfo];
    NSString *schemeStr = scheme ? [NSString stringWithUTF8String:scheme] : nil;

    // 调用支付宝 SDK
    // 注意：fromScheme 必须与 Info.plist 中配置的一致，否则无法跳转回 App
    [[AlipaySDK defaultService] payOrder:orderStr fromScheme:schemeStr callback:^(NSDictionary *resultDic) {
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
