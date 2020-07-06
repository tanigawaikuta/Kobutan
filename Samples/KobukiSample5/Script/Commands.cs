//======================================
// �ړ��R�}���h
//======================================
// Kobuki�Ɍ��X�p�ӂ���Ă��� Base Control �R�}���h�𒼐ڎg��
// speed  : ���x [mm/s]
// radius : �Ȃ���Ԋu [mm]
protected void BaseControl(short speed, short radius)
{
    SpeedParam = speed;
    RadiusParam = radius;
}

// �O�i
protected void Forward()
{
    BaseControl((short)(Speed * 10), 0);
}

// ��i
protected void Backward()
{
    BaseControl((short)(-(Speed * 10)), 0);
}

// ������
protected void TurnLeft()
{
    BaseControl((short)(Speed * 10), 1);
}

// �E����
protected void TurnRight()
{
    BaseControl((short)(Speed * 10), -1);
}

// �~�߂�
protected void Stop()
{
    BaseControl(0, 0);
}

//======================================
// �ݒ�R�}���h
//======================================
// �����̐ݒ� (0�`100)
protected void SetSpeed(int speed)
{
    // ���E�l�𒴂������͍̂ő�A�ŏ��l�ɍ��킹��
    if (speed > 100)
        speed = 100;
    if (speed < 0)
        speed = 0;
    // �p�����[�^�̐ݒ�
    Speed = speed;
}

// ���񑬓x�̐ݒ� (0�`100)
protected void SetTurnSpeed(int speed)
{
    // ���E�l�𒴂������͍̂ő�A�ŏ��l�ɍ��킹��
    if (speed > 100)
        speed = 100;
    if (speed < 0)
        speed = 0;
    // �p�����[�^�̐ݒ�
    TurnSpeed = speed;
}

// LED�̐F�ݒ� color�� N(����), R(��), G(��), Y(��)
protected void SetLEDColor(int num, char color)
{
    // �_��������LED�̐ݒ�
    int led = 0;
    if ((num == 1) || (num == 2))
        led = num - 1;
    else
        return;
    // �F�̌���
    int tmp = 0;
    if (color == 'N')
        tmp = 0;
    if (color == 'R')
        tmp = 1;
    if (color == 'G')
        tmp = 2;
    if (color == 'Y')
        tmp = 3;
    // �ύX����
    LEDParam = (LEDParam & (0x0C >> (2 * led))) | (tmp << (2 * led));
}

//======================================
// �T�E���h�R�}���h
//======================================
// ��
private void Sound(ushort note, byte duration)
{
    SoundFlg = true;
    SoundNote = note;
    SoundDuration = duration;
}

// �h�̉���炷
protected void Sound_DO()
{
    Sound(1390, 0xff);
}

// �h#�̉���炷
protected void Sound_DO_Sharp()
{
    Sound(1312, 0xff);
}

// ���̉���炷
protected void Sound_RE()
{
    Sound(1237, 0xff);
}

// ��#�̉���炷
protected void Sound_RE_Sharp()
{
    Sound(1169, 0xff);
}

// �~�̉���炷
protected void Sound_MI()
{
    Sound(1103, 0xff);
}

// �t�@�̉���炷
protected void Sound_FA()
{
    Sound(1041, 0xff);
}

// �t�@#�̉���炷
protected void Sound_FA_Sharp()
{
    Sound(983, 0xff);
}

// �\�̉���炷
protected void Sound_SO()
{
    Sound(928, 0xff);
}

// �\#�̉���炷
protected void Sound_SO_Sharp()
{
    Sound(876, 0xff);
}

// ���̉���炷
protected void Sound_RA()
{
    Sound(826, 0xff);
}

// ��#�̉���炷
protected void Sound_RA_Sharp()
{
    Sound(780, 0xff);
}

// �V�̉���炷
protected void Sound_SI()
{
    Sound(736, 0xff);
}

// �h�̉���炷
protected void Sound_DO_2()
{
    Sound(695, 0xff);
}

//======================================
// �V�X�e���R�}���h
//======================================
// �w�肵���~���b�ԃX���[�v
protected void Sleep(int ms)
{
    if (ms > 0)
        Thread.Sleep(ms);
}

// �v���O�������I������
protected void Exit()
{
    Stop();
    OnDataSending();
    KobukiMainThreadLoopFlg = false;
    throw new Exception();
}

// �ڑ�����
protected long ConnectTime { get { return Stopwatch.ElapsedMilliseconds; } }
