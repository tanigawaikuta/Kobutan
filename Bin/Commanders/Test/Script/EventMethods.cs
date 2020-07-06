// �A�N�e�B�x�[�g���Ɏ��s����郁�\�b�h
public override void OnActivated()
{
}

// �f�B�A�N�e�B�x�[�g���Ɏ��s����郁�\�b�h
public override void OnDeactivating()
{
}

// �ڑ����Ɏ��s����郁�\�b�h
public override void OnConnected()
{
    // �T���v���X���b�h
    KobukiMainThreadReference = new Thread(new ThreadStart(KobukiMainThread));
    KobukiMainThreadReference.IsBackground = true;
    KobukiMainThreadLoopFlg = true;
    KobukiMainThreadReference.Start();
    // �X�g�b�v�E�H�b�`�̃X�^�[�g
    Stopwatch.Reset();
    Stopwatch.Start();
}

// �ؒf���Ɏ��s����郁�\�b�h
public override void OnDisconnecting()
{
    // �T���v���X���b�h�̏I��
    KobukiMainThreadReference.Abort();
    Stop();
    OnDataSending();
    KobukiMainThreadLoopFlg = false;
    // �X�g�b�v�E�H�b�`�̒�~
    Stopwatch.Stop();
    Stopwatch.Reset();
}

// �f�[�^�𑗂�^�C�~���O���������Ɏ��s����郁�\�b�h
public override void OnDataSending()
{
    // Exit ����ĂȂ���Α���
    if (KobukiMainThreadLoopFlg)
    {
        // �w�b�_
        ObjectBase.CommandManager.SendBuf[0] = 0xAA;
        ObjectBase.CommandManager.SendBuf[1] = 0x55;
        // �y�C���[�h�̒���
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

        // �T�E���h
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

        // �`�F�b�N�T��
        ObjectBase.CommandManager.SendBuf[13 + offset] = CalcChecksum(ObjectBase.CommandManager.SendBuf, (13 + offset));

        // ���M
        ObjectBase.CommandManager.Send(0, (14 + offset));
    }
}

// �f�[�^����M���ꂽ���Ɏ��s����郁�\�b�h
public override void OnDataReceived()
{
    // ��M�f�[�^�̓ǂݍ���
    int size = ObjectBase.CommandManager.BytesToRead;
    ObjectBase.CommandManager.Receive(0, size);
    for (int i = 0; i < size; ++i)
    {
        // ��M�f�[�^�����
        InputReceivedData(ObjectBase.CommandManager.ReceiveBuf[i]);
    }
}
