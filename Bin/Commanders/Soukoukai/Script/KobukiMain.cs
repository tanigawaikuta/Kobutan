//======================================================
// メイン
//
// 概要: プログラムの本体。
//======================================================
// 定数
const short FORWARD_SPEED = 200;        // 前進速度 [mm/s]
const short TURN_SPEED = 200;           // 旋回速度
const int LENGTH_OF_SIDE_A = 14040;     // 辺Aの長さ 120cm (1mmにつき11.7 以下同様)
const int LENGTH_OF_SIDE_B = 9360;      // 辺Bの長さ 80cm
const int DIAMETER_OF_KOBUKI = 4095;    // Kobukiの直径 35cm
const int MARGIN = 234;                 // 余裕 2cm

// 状態を表す列挙型
enum State
{
    ForwardA,         // 辺Aを前進
    ForwardB,         // 辺Bを前進
    Turn,             // 旋回
    End,              // 終了
}
// 状態変数
State _State = State.ForwardA;           // 状態
int _TurnCounter = 0;                    // 曲がった回数
// エンコーダ
Encoder _RightEnc;    // 右エンコーダ
Encoder _LeftEnc;     // 左エンコーダ

// エントリポイント
void KobukiMain()
{
    // エンコーダ値の初期化
    Encoder_Initialize(ref _RightEnc, RightEncoder);    // 右エンコーダ
    Encoder_Initialize(ref _LeftEnc, LeftEncoder);      // 左エンコーダ

    // 終了状態になるまでループ
    while (_State != State.End)
    {
        // エンコーダ値の更新
        Encoder_Update(ref _RightEnc, RightEncoder);    // 右エンコーダ
        Encoder_Update(ref _LeftEnc, LeftEncoder);      // 左エンコーダ
        // 距離と角度を求める
        int distance = (_RightEnc.Value + _LeftEnc.Value) / 2;    // 距離 (1mmにつき11.7)
        int angle = _RightEnc.Value - _LeftEnc.Value;             // 角度 (1度につき47.5)

        // 状態に応じた処理
        switch (_State)
        {
            case State.ForwardA:
                if (distance >= (LENGTH_OF_SIDE_A + DIAMETER_OF_KOBUKI + (MARGIN * 2)))
                {
                    // 停止
                    Stop();
                    // エンコーダ値のリセット
                    Encoder_Initialize(ref _RightEnc, RightEncoder);    // 右エンコーダ
                    Encoder_Initialize(ref _LeftEnc, LeftEncoder);      // 左エンコーダ
                    // 旋回状態に移行
                    _State = State.Turn;
                }
                else
                {
                    // 前進
                    //BaseControl(FORWARD_SPEED, 0);
                    GoStraight(FORWARD_SPEED, _RightEnc.Value, _LeftEnc.Value);
                }
                break;
            case State.ForwardB:
                if (distance >= (LENGTH_OF_SIDE_B + DIAMETER_OF_KOBUKI + (MARGIN * 2)))
                {
                    // 停止
                    Stop();
                    // エンコーダ値のリセット
                    Encoder_Initialize(ref _RightEnc, RightEncoder);    // 右エンコーダ
                    Encoder_Initialize(ref _LeftEnc, LeftEncoder);      // 左エンコーダ
                    // 状態遷移
                    if (_TurnCounter >= 3)
                        _State = State.End;
                    else
                        _State = State.Turn;
                }
                else
                {
                    // 前進
                    //BaseControl(FORWARD_SPEED, 0);
                    GoStraight(FORWARD_SPEED, _RightEnc.Value, _LeftEnc.Value);
                }
                break;
            case State.Turn:
                if (angle >= 4275)
                {
                    // 停止
                    Stop();
                    // エンコーダ値のリセット
                    Encoder_Initialize(ref _RightEnc, RightEncoder);    // 右エンコーダ
                    Encoder_Initialize(ref _LeftEnc, LeftEncoder);      // 左エンコーダ
                    // 状態遷移
                    ++_TurnCounter;                                     // 曲がった回数をインクリメント
                    if ((_TurnCounter % 2) == 0)
                        _State = State.ForwardA;
                    else
                        _State = State.ForwardB;
                }
                else
                {
                    // 旋回
                    BaseControl(TURN_SPEED, 1);
                }
                break;
            case State.End:
                Stop();
                break;
            default:
                _State = State.End;
                Stop();
                break;
        }
    }

    // プログラムの終了
    Exit();
}

//======================================================
// エンコーダ
//
// 概要:
//   生のエンコーダ値をそのまま使うと2バイト分しかないためすぐあふれるといった問題や、
//   途中でエンコーダ値をリセットすることができないといった問題がある。
//   そのため、エンコーダ値をint型に拡張し、リセット機能も追加した。
//======================================================
// 定数
const short OVERFLOW = (short)(ushort.MaxValue / 2);     // オーバーフロー検知の境界値

// エンコーダ値を格納する構造体
// 構造体の定義では、各要素にpublicを付ける(とりあえず今はおまじないと思ってください)
struct Encoder
{
    // 現在の値
    public int Value;
    // 前回の入力値
    public ushort LastInput;
}

// エンコーダ値の更新
//   encoder: エンコーダ値を格納する構造体のポインタ (ポインタ渡しには refを付ける)
//   value:   生のエンコーダ値
void Encoder_Update(ref Encoder encoder, ushort value)
{
    // 前回の入力値からの差分を計算
    int offset = (int)(value - encoder.LastInput);
    // オーバーフローの検知と修正
    if (offset >= OVERFLOW)
    {
        offset = (int)(-(ushort.MaxValue - offset + 1));
    }
    else if(offset <= -OVERFLOW)
    {
        offset = (int)(ushort.MaxValue + offset + 1);
    }

    // 差分を反映
    encoder.Value += offset;

    // 次回のために現在の入力値を確保
    encoder.LastInput = value;
}

// エンコーダ値の初期化
//   encoder: エンコーダ値を格納する構造体のポインタ (ポインタ渡しには refを付ける)
//   value:   生のエンコーダ値
void Encoder_Initialize(ref Encoder encoder, ushort value)
{
    encoder.LastInput = value;
    encoder.Value = 0;
}

//======================================================
// まっすぐ直進
//
// 概要:
//   Forwardのみでは、思ったようにまっすぐ進んではくれない。
//   そのため、ずれた分を補正しながら進む必要がある。
//   ここでは、エンコーダ値からずれを検知し、ずれの分曲がることで元の位置に修正する
//======================================================
// 定数
const short MAX_RADIUS = 1000;       // BaseControlのradiusの最高値
                                     // この値を大きくするほど、位置修正の際に曲がる量が小さくなる

// 直進
//   speed:        速度
//   rightEncoder: 右エンコーダ
//   leftEncoder:  左エンコーダ
void GoStraight(short speed, int rightEncoder, int leftEncoder)
{
    // 左右エンコーダからずれ(角度)を求める
    int angle = (rightEncoder - leftEncoder);
    if (angle > MAX_RADIUS) angle = MAX_RADIUS - 1;
    if (angle < -MAX_RADIUS) angle = -MAX_RADIUS + 1;

    // ずれた分を曲がり、前進する
    short radius = 0;          // BaseControlコマンドに渡すradius
    if (angle < 0)
    {
        radius = (short)(MAX_RADIUS + angle);
    }
    else if (angle > 0)
    {
        radius = (short)(-MAX_RADIUS + angle);
    }

    // コマンド実行
    BaseControl(speed, radius);
}
