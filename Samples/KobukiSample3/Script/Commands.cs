//======================================
// 移動コマンド
//======================================
// Kobukiに元々用意されている Base Control コマンドを直接使う
// speed  : 速度 [mm/s]
// radius : 曲がる間隔 [mm]
protected void BaseControl(short speed, short radius)
{
    SpeedParam = speed;
    RadiusParam = radius;
}

// 前進
protected void Forward()
{
    BaseControl((short)(Speed * 10), 0);
}

// 後進
protected void Backward()
{
    BaseControl((short)(-(Speed * 10)), 0);
}

// 左旋回
protected void TurnLeft()
{
    BaseControl((short)(Speed * 10), 1);
}

// 右旋回
protected void TurnRight()
{
    BaseControl((short)(Speed * 10), -1);
}

// 止める
protected void Stop()
{
    BaseControl(0, 0);
}

//======================================
// 設定コマンド
//======================================
// 速さの設定 (0～100)
protected void SetSpeed(int speed)
{
    // 境界値を超えたものは最大、最小値に合わせる
    if (speed > 100)
        speed = 100;
    if (speed < 0)
        speed = 0;
    // パラメータの設定
    Speed = speed;
}

// 旋回速度の設定 (0～100)
protected void SetTurnSpeed(int speed)
{
    // 境界値を超えたものは最大、最小値に合わせる
    if (speed > 100)
        speed = 100;
    if (speed < 0)
        speed = 0;
    // パラメータの設定
    TurnSpeed = speed;
}

// LEDの色設定 colorは N(無し), R(赤), G(緑), Y(黄)
protected void SetLEDColor(int num, char color)
{
    // 点灯させるLEDの設定
    int led = 0;
    if ((num == 1) || (num == 2))
        led = num - 1;
    else
        return;
    // 色の決定
    int tmp = 0;
    if (color == 'N')
        tmp = 0;
    if (color == 'R')
        tmp = 1;
    if (color == 'G')
        tmp = 2;
    if (color == 'Y')
        tmp = 3;
    // 変更処理
    LEDParam = (LEDParam & (0x0C >> (2 * led))) | (tmp << (2 * led));
}

//======================================
// サウンドコマンド
//======================================
// 音
private void Sound(ushort note, byte duration)
{
    SoundFlg = true;
    SoundNote = note;
    SoundDuration = duration;
}

// ドの音を鳴らす
protected void Sound_DO()
{
    Sound(1390, 0xff);
}

// ド#の音を鳴らす
protected void Sound_DO_Sharp()
{
    Sound(1312, 0xff);
}

// レの音を鳴らす
protected void Sound_RE()
{
    Sound(1237, 0xff);
}

// レ#の音を鳴らす
protected void Sound_RE_Sharp()
{
    Sound(1169, 0xff);
}

// ミの音を鳴らす
protected void Sound_MI()
{
    Sound(1103, 0xff);
}

// ファの音を鳴らす
protected void Sound_FA()
{
    Sound(1041, 0xff);
}

// ファ#の音を鳴らす
protected void Sound_FA_Sharp()
{
    Sound(983, 0xff);
}

// ソの音を鳴らす
protected void Sound_SO()
{
    Sound(928, 0xff);
}

// ソ#の音を鳴らす
protected void Sound_SO_Sharp()
{
    Sound(876, 0xff);
}

// ラの音を鳴らす
protected void Sound_RA()
{
    Sound(826, 0xff);
}

// ラ#の音を鳴らす
protected void Sound_RA_Sharp()
{
    Sound(780, 0xff);
}

// シの音を鳴らす
protected void Sound_SI()
{
    Sound(736, 0xff);
}

// ドの音を鳴らす
protected void Sound_DO_2()
{
    Sound(695, 0xff);
}

//======================================
// システムコマンド
//======================================
// 指定したミリ秒間スリープ
protected void Sleep(int ms)
{
    if (ms > 0)
        Thread.Sleep(ms);
}

// プログラムを終了する
protected void Exit()
{
    Stop();
    OnDataSending();
    KobukiMainThreadLoopFlg = false;
    throw new Exception();
}

// 接続時間
protected long ConnectTime { get { return Stopwatch.ElapsedMilliseconds; } }
