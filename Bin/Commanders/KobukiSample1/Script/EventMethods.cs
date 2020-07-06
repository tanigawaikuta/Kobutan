// アクティベート時に実行されるメソッド
public override void OnActivated()
{
}

// ディアクティベート時に実行されるメソッド
public override void OnDeactivating()
{
}

// 接続時に実行されるメソッド
public override void OnConnected()
{
    // サンプルスレッド
    KobukiMainThreadReference = new Thread(new ThreadStart(KobukiMainThread));
    KobukiMainThreadReference.IsBackground = true;
    KobukiMainThreadLoopFlg = true;
    KobukiMainThreadReference.Start();
    // ストップウォッチのスタート
    Stopwatch.Reset();
    Stopwatch.Start();
}

// 切断時に実行されるメソッド
public override void OnDisconnecting()
{
    // サンプルスレッドの終了
    KobukiMainThreadReference.Abort();
    Stop();
    OnDataSending();
    KobukiMainThreadLoopFlg = false;
    // ストップウォッチの停止
    Stopwatch.Stop();
    Stopwatch.Reset();
}

// データを送るタイミングが来た時に実行されるメソッド
public override void OnDataSending()
{
    // Exit されてなければ送る
    if (KobukiMainThreadLoopFlg)
    {
        // ヘッダ
        ObjectBase.CommandManager.SendBuf[0] = 0xAA;
        ObjectBase.CommandManager.SendBuf[1] = 0x55;
        // ペイロードの長さ
        ObjectBase.CommandManager.SendBuf[2] = 0x0A;
        // BaseControl
        ObjectBase.CommandManager.SendBuf[3] = 0x01;
        ObjectBase.CommandManager.SendBuf[4] = 0x04;
        ObjectBase.CommandManager.SendBuf[5] = (byte)(SpeedParam & 0x00ff);
        ObjectBase.CommandManager.SendBuf[6] = (byte)((SpeedParam & 0xff00) >> 8);
        ObjectBase.CommandManager.SendBuf[7] = (byte)(RadiusParam & 0x00ff);
        ObjectBase.CommandManager.SendBuf[8] = (byte)((RadiusParam & 0xff00) >> 8);
        // General Purpose Output
        ObjectBase.CommandManager.SendBuf[9] = 0x0C;
        ObjectBase.CommandManager.SendBuf[10] = 0x02;
        ObjectBase.CommandManager.SendBuf[11] = 0x00;
        ObjectBase.CommandManager.SendBuf[12] = (byte)(LEDParam);

        // サウンド
        int offset = 0;
        if (SoundFlg)
        {
            ObjectBase.CommandManager.SendBuf[13] = 0x03;
            ObjectBase.CommandManager.SendBuf[14] = 0x03;
            ObjectBase.CommandManager.SendBuf[15] = (byte)(SoundNote & 0x00ff);
            ObjectBase.CommandManager.SendBuf[16] = (byte)((SoundNote & 0xff00) >> 8);
            ObjectBase.CommandManager.SendBuf[17] = SoundDuration;
            offset = 5;
            ObjectBase.CommandManager.SendBuf[2] += (byte)offset;
            SoundFlg = false;
        }

        // チェックサム
        ObjectBase.CommandManager.SendBuf[13 + offset] = CalcChecksum(ObjectBase.CommandManager.SendBuf, (13 + offset));

        // 送信
        ObjectBase.CommandManager.Send(0, (14 + offset));
    }
}

// データが受信された時に実行されるメソッド
public override void OnDataReceived()
{
    // 受信データの読み込み
    int size = ObjectBase.CommandManager.BytesToRead;
    ObjectBase.CommandManager.Receive(0, size);
    for (int i = 0; i < size; ++i)
    {
        // 受信データを入力
        InputReceivedData(ObjectBase.CommandManager.ReceiveBuf[i]);
    }
}
