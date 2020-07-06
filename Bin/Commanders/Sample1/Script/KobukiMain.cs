// 直進後に左旋回し、更に直進するサンプル
protected override void KobukiMain()
{
    // 1秒間 前進
    Forward();        // 前進
    Sleep(1000);      // 次のステップに移るまで1秒待つ
    Stop();           // ストップ
    // 2.5秒間 左旋回
    TurnLeft();       // 左旋回
    Sleep(2500);      // 次のステップに移るまで2.5秒待つ
    Stop();           // ストップ
    // 1秒間 前進
    Forward();        // 前進
    Sleep(1000);      // 次のステップに移るまで1秒待つ
    Stop();           // ストップ

    // 終了
    Exit();
}
