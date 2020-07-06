// 1mだけ直進するサンプル
void KobukiMain()
{
    //=================================
    // 1m 前進 (エンコーダ値バージョン)
    //=================================
    SetSpeed(10);     // 速度:100mm/s
    Forward();        // 前進
    // エンコーダ値が1m分の値を超えたら停止させる
    // 1mmあたりのエンコーダ値が11.7なので、11700で1m
    int encoder = (RightEncoder + LeftEncoder) / 2;   // 左右エンコーダの平均値
    OutputInteger(encoder);                           // デバック用 : エンコーダ値を出力
    while(encoder < 11700)
    {
        encoder = (RightEncoder + LeftEncoder) / 2;   // 左右エンコーダの平均値
        OutputInteger(encoder);                       // デバック用 : エンコーダ値を出力
    }
    Stop();           // 停止
    // 終了
    Exit();

    /*
    //=================================
    // 1m 前進 (時間バージョン)
    //=================================
    SetSpeed(10);     // 速度:100mm/s
    Forward();        // 前進
    Sleep(10000);     // 10秒後、次のステップに移る
    Stop();           // 停止
    // 終了
    Exit();
    */
}
