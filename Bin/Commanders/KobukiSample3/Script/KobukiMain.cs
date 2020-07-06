// ボタン0が押されていればLEDを付け、押されてなければLEDを消す
void KobukiMain()
{
    // ボタン0が押されたらLED1を黄色にする
    if (Button0 == 1)
    {
        SetLEDColor(1, 'Y');
    }
    // ボタン0が押されてなければLED1を消すにする
    else if (Button0 == 0)
    {
        SetLEDColor(1, 'N');
    }

    // Exitを呼び出ださなければ、処理終了後に先頭に戻る
    //Exit();
}
