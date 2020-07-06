// エントリポイント
// ここに処理を追加する
void KobukiMain()
{
    while (true)
        OutputString(RawDataOf3DGyro_FrameId + "    " + RawDataOf3DGyro_DataLength);

    // 終了
    Exit();
}
