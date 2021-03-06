﻿// KobukiMainスレッド
private void KobukiMainThread()
{
    // 接続が切られるまでループ
    while (KobukiMainThreadLoopFlg)
    {
        try
        {
            KobukiMain();
        }
        catch (Exception) { }
    }
}

// 受信データを入力
private int _ReceiveState = 0;
private int _ReceiveStateCounter = 0;
private byte[] _Buf = new byte[256];
private void InputReceivedData(byte data)
{
    switch (_ReceiveState)
    {
        case 0:
            if (data == 0xAA)
            {
                _Buf[0] = data;
                _ReceiveState = 1;
            }
            break;
        case 1:
            if (data == 0x55)
            {
                _Buf[1] = data;
                _ReceiveState = 2;
            }
            else
                _ReceiveState = 0;
            break;
        case 2:
            _Buf[2] = data;
            _ReceiveStateCounter = 0;
            _ReceiveState = 3;
            break;
        case 3:
            int index = 3 + _ReceiveStateCounter;
            _Buf[index] = data;
            if (_ReceiveStateCounter >= _Buf[2])
            {
                if (CalcChecksum(_Buf, index) == _Buf[index])
                {
                    for (int i = 0; i < _Buf[2]; i += (_Buf[4 + i] + 2))
                    {
                        if (_Buf[3 + i] == 0x01)
                        {
                            RightBumper = (_Buf[7 + i] & 0x01) != 0 ? 1 : 0;
                            CentralBumper = (_Buf[7 + i] & 0x02) != 0 ? 1 : 0;
                            LeftBumper = (_Buf[7 + i] & 0x04) != 0 ? 1 : 0;
                            RightWheelDrop = (_Buf[8 + i] & 0x01) != 0 ? 1 : 0;
                            LeftWheelDrop = (_Buf[8 + i] & 0x02) != 0 ? 1 : 0;
                            LeftEncoder = (ushort)((_Buf[11 + i] << 8) | _Buf[10 + i]);
                            RightEncoder = (ushort)((_Buf[13 + i] << 8) | _Buf[12 + i]);
                            Button0 = (_Buf[16 + i] & 0x01) != 0 ? 1 : 0;
                            Button1 = (_Buf[16 + i] & 0x02) != 0 ? 1 : 0;
                            Button2 = (_Buf[16 + i] & 0x04) != 0 ? 1 : 0;
                            break;
                        }
                    }
                }
                _ReceiveState = 0;
            }
            ++_ReceiveStateCounter;
            break;
        default:
            _ReceiveState = 0;
            break;
    }
}

// チェックサムを計算するメソッド
private byte CalcChecksum(byte[] buf, int index)
{
    byte sum = 0;
    for(int i = 2; i < index; ++i)
    {
        sum ^= buf[i];
    }
    return sum;
}
