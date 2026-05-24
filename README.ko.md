<p align="center">
  <img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="GameFrameX Logo" width="160" />
</p>

<h1 align="center">Game Frame X Payment Alipay</h1>

<p align="center">
  <a href="https://github.com/GameFrameX/com.gameframex.unity.payment.alipay/releases">
    <img src="https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.payment.alipay" alt="Version" />
  </a>
  <a href="https://github.com/GameFrameX/com.gameframex.unity.payment.alipay/blob/main/LICENSE">
    <img src="https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.payment.alipay" alt="License" />
  </a>
  <a href="https://gameframex.doc.alianblank.com">
    <img src="https://img.shields.io/badge/Documentation-online-blue" alt="Documentation" />
  </a>
</p>

<p align="center">
  인디 게임 개발자를 위한 올인원 솔루션 · 인디 개발자의 꿈을 실현
</p>

<p align="center">
  <a href="https://gameframex.doc.alianblank.com">문서</a> ·
  <a href="#빠른-시작">빠른 시작</a> ·
  <a href="https://qm.qq.com/cgi-bin/qm/qr?k=ikT9gA5m2sKwOyNOfYmQvSAPK_c3GmD6">QQ 그룹</a> ·
  언어: <a href="README.md">English</a> | <a href="README.zh-CN.md">简体中文</a> | <a href="README.zh-TW.md">繁體中文</a> | <a href="README.ja.md">日本語</a> | <strong>한국어</strong>
</p>

---

## 프로젝트 개요

**Payment Alipay 컴포넌트** - Unity용 Alipay(支付宝) 결제 통합을 제공합니다. Android, iOS 및 Editor 시뮬레이션 모드를 지원합니다.

### 기능

- `IAlipayManager`를 통한 통합 결제 인터페이스
- Android 지원 (`com.alipay.sdk.app.PayTask` 통해)
- iOS 지원 (네이티브 라이브러리 호출 통해)
- Editor 시뮬레이션 테스트 (성공 콜백 시뮬레이션)
- 콜백이 메인 스레드에서 실행되도록 자동 스레드 전환

## 빠른 시작

### 설치

다음 방법 중 하나를 선택하세요:

1. 프로젝트의 `manifest.json` 파일의 `dependencies` 섹션에 다음 내용을 추가:
   ```json
   {"com.gameframex.unity.payment.alipay": "https://github.com/AlianBlank/com.gameframex.unity.payment.alipay.git"}
   ```
2. Unity의 `Package Manager`에서 `Git URL`을 사용하여 추가: https://github.com/AlianBlank/com.gameframex.unity.payment.alipay.git
3. 리포지토리를 다운로드하여 Unity 프로젝트의 `Packages` 디렉토리에 배치 (자동으로 로드됩니다).

### 사용 예시

```csharp
using GameFrameX.Runtime;
using GameFrameX.Payment.Alipay.Runtime;

public class PaymentExample : MonoBehaviour
{
    private void Start()
    {
        // 1. Alipay 매니저 인터페이스 가져오기
        var alipayManager = GameFrameworkEntry.GetModule<IAlipayManager>();

        if (alipayManager != null)
        {
            // 2. 주문 정보 준비 (보통 서버에서 생성)
            string orderInfo = "app_id=...&biz_content=...&sign=...";

            // 3. 결제 시작
            alipayManager.Pay(orderInfo, OnPayResult);
        }
    }

    private void OnPayResult(AlipayResult result)
    {
        Debug.Log($"결제 상태: {result.resultStatus}");
        Debug.Log($"결제 결과: {result.result}");
        Debug.Log($"메모: {result.memo}");

        if (result.resultStatus == "9000")
        {
            Debug.Log("결제 성공");
        }
        else
        {
            Debug.LogError("결제 실패 또는 취소");
        }
    }
}
```

씬에 `AlipayComponent`가 있는지 확인하세요. 보통 GameFrameX 프레임워크의 일부로 자동 로드되거나 GameObject에 수동으로 추가합니다.

## 플랫폼 지원

| 플랫폼 | 지원 |
|--------|------|
| Android | 예 |
| iOS | 예 |
| Editor (시뮬레이션) | 예 |

## 문서 및 자료

- [문서](https://gameframex.doc.alianblank.com)
- [GitHub 리포지토리](https://github.com/GameFrameX/com.gameframex.unity.payment.alipay)

## 커뮤니티 및 지원

- QQ 그룹: [QR 코드](https://qm.qq.com/cgi-bin/qm/qr?k=ikT9gA5m2sKwOyNOfYmQvSAPK_c3GmD6)에서 가입

## 라이선스

이 프로젝트는 [LICENSE](LICENSE) 파일에 정의된 조건에 따라 라이선스가 부여됩니다.
