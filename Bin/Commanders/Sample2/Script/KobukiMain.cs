﻿// 速度を指定して、前進、旋回する
protected override void KobukiMain()
{
    // 速さを指定して前進
    SetSpeed(40);        // 速さの設定 (400 mm/s)
    Forward();           // 前進
    Sleep(1000);         // 次のステップに移るのを1秒間待つ
    Stop();              // ストップ
    // 旋回速度を指定して前進
    SetTurnSpeed(20);    // 旋回速度の設定 (200 ??/s)
    TurnLeft();          // 左旋回
    Sleep(1000);         // 次のステップに移るのを1秒間待つ
    Stop();              // ストップ

    // 終了
    Exit();
}
