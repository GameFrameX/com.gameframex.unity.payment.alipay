<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X Payment Alipay

[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.payment.alipay)](https://github.com/GameFrameX/com.gameframex.unity.payment.alipay/blob/main/LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.payment.alipay)](https://github.com/GameFrameX/com.gameframex.unity.payment.alipay/releases)
[![Unity Version](https://img.shields.io/badge/Unity-2019.4-black?logo=unity)](https://unity.com/)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

인디 게임 개발자를 위한 올인원 솔루션 · 인디 개발자의 꿈을 실현

<br />

[문서](https://gameframex.doc.alianblank.com) · [빠른 시작](#빠른-시작) · QQ 그룹: 467608841 / 233840761

<br />

[English](README.md) | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | **한국어**

</div>

## 프로젝트 개요

**Payment Alipay 컴포넌트** - Unity용 Alipay(支付宝) 결제 통합을 제공합니다. `IPaymentManager` 채널 구현으로서 `PaymentComponent`에 연결되며 별도 컴포넌트가 필요하지 않습니다. Android와 iOS를 지원합니다.

### 기능

- `IPaymentManager`의 Alipay 채널 구현. `PaymentComponent`의 플랫폼 결제 컴포넌트에서 `AlipayManager`를 선택하기만 하면 활성화됩니다
- 서버에서 서명한 주문 문자열을 `AlipayPurchaseParams`로 전달하여 결제를 시작하고, 결과는 `OnPurchaseSuccess` / `OnPurchaseFailed` 이벤트로 통합 전달됩니다
- Android 지원 (`com.alipay.sdk.app.PayTask` 통해)
- iOS 지원 (네이티브 라이브러리 호출 통해, `AppId`는 Info.plist의 URL Scheme과 일치해야 합니다)
- 콜백이 메인 스레드에서 실행되도록 자동 스레드 전환
- 시작 시 결제 채널 레지스트리(PaymentChannelRegistry)에 자동 등록되며, 이 패키지가 설치되지 않으면 등록도 발생하지 않습니다. `GetAvailableChannels()`로 사용 가능한 채널을 조회할 수 있습니다

### 사용 예시

```csharp
// PaymentComponent의 플랫폼 결제 컴포넌트에서 GameFrameX.Payment.Alipay.Runtime.AlipayManager 선택
// 서버에서 주문을 생성한 후 서명된 주문 문자열로 결제를 시작합니다
GameApp.Payment.Buy(new AlipayPurchaseParams(productId, orderId, orderInfo)
{
    AppId = "Alipay 앱 ID", // iOS에서는 필수이며 Info.plist의 URL Scheme과 일치해야 합니다. Android에서는 불필요
});

// 사용 가능한 결제 수단 조회(UI 표시용, 구매 매개변수는 alipay 채널로 자동 라우팅됨)
foreach (var channel in GameApp.Payment.GetAvailableChannels())
{
    // channel.ChannelId / channel.DisplayName / channel.IsAvailable
}

GameApp.Payment.OnPurchaseSuccess += (sender, e) => { // 결제 결과는 서버 측 주문 검증을 기준으로 함 };
GameApp.Payment.OnPurchaseFailed += (sender, e) => { };
```


## 빠른 시작

### 설치

다음 방법 중 하나를 선택하세요:

1. Unity 프로젝트의 `Packages/manifest.json`을 편집하여 `scopedRegistries` 섹션을 추가하세요:
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
     ],
     "dependencies": {
       "com.gameframex.unity.payment.alipay": "1.0.0"
     }
   }
   ```

   `scopes`는 이 레지스트리를 통해 어떤 패키지를 해석할지 제어합니다. `com.gameframex`로 시작하는 패키지만 이 레지스트리에서 가져옵니다.

2. `manifest.json`의 `dependencies`에 직접 추가:
   ```json
   {
      "com.gameframex.unity.payment.alipay": "https://github.com/gameframex/com.gameframex.unity.payment.alipay.git"
   }
   ```
3. Unity의 **Package Manager**에서 **Git URL**을 사용하여 추가: `https://github.com/gameframex/com.gameframex.unity.payment.alipay.git`
4. 리포지토리를 Unity 프로젝트의 `Packages` 디렉토리에 클론하세요. 자동으로 로드됩니다.
## 플랫폼 지원

| 플랫폼 | 지원 |
|--------|------|
| Android | 예 |
| iOS | 예 |
| Editor | 아니요 (로그만 출력) |

## 문서 및 자료

- [문서](https://gameframex.doc.alianblank.com)
- [GitHub 리포지토리](https://github.com/GameFrameX/com.gameframex.unity.payment.alipay)

## 커뮤니티 및 지원

- QQ 그룹: [QR 코드](https://qm.qq.com/cgi-bin/qm/qr?k=ikT9gA5m2sKwOyNOfYmQvSAPK_c3GmD6)에서 가입


## 의존성

| 패키지 | 설명 |
|--------|------|
| `com.gameframex.unity` | 1.1.1 |
| `com.gameframex.unity.payment` | 2.0.0 |

## 변경 로그

[Releases](https://github.com/GameFrameX/gameframex/com.gameframex.unity.payment.alipay/releases)에서 변경 로그를 확인하세요.
## 라이선스

이 프로젝트는 [LICENSE](LICENSE) 파일에 정의된 조건에 따라 라이선스가 부여됩니다.
