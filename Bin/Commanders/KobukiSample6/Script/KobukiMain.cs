// 90度曲がるサンプル
void KobukiMain()
{
    // 90度旋回
    TurnLeft();       // 旋回
    // 左右エンコーダ値の差は開始地点から曲がった角度を表す
    short leftEnc = (short)LeftEncoder;        // 左エンコーダを符号付きに変換
    short rightEnc = (short)RightEncoder;      // 右エンコーダを符号付きに変換
    int angle = rightEnc - leftEnc;            // 角度
    // 90度に達するまで曲がる
    // ここでは、1度につき47.5として計算している (実際に動かして測った値)
    while(angle < 4275)
    {
        leftEnc = (short)LeftEncoder;          // 左エンコーダを符号付きに変換
        rightEnc = (short)RightEncoder;        // 右エンコーダを符号付きに変換
        angle = rightEnc - leftEnc;            // 角度
        OutputInteger(angle);                  // デバッグ用
    }
    Stop();           // 停止
    // 終了
    Exit();
}
