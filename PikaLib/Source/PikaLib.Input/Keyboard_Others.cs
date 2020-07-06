using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PikaLib.Input
{
    /// <summary>
    /// キーボードのキーの種類。
    /// </summary>
    public enum Key
    {
        /// <summary>Esc キー</summary>
        Escape = 1,
        /// <summary>さまざまな文字に使用されます。キーボードによって異なる場合があります。</summary>
        D1 = 2,
        /// <summary>さまざまな文字に使用されます。キーボードによって異なる場合があります。</summary>
        D2 = 3,
        /// <summary>さまざまな文字に使用されます。キーボードによって異なる場合があります。</summary>
        D3 = 4,
        /// <summary>さまざまな文字に使用されます。キーボードによって異なる場合があります。</summary>
        D4 = 5,
        /// <summary>さまざまな文字に使用されます。キーボードによって異なる場合があります。</summary>
        D5 = 6,
        /// <summary>さまざまな文字に使用されます。キーボードによって異なる場合があります。</summary>
        D6 = 7,
        /// <summary>さまざまな文字に使用されます。キーボードによって異なる場合があります。</summary>
        D7 = 8,
        /// <summary>さまざまな文字に使用されます。キーボードによって異なる場合があります。</summary>
        D8 = 9,
        /// <summary>さまざまな文字に使用されます。キーボードによって異なる場合があります。</summary>
        D9 = 10,
        /// <summary>さまざまな文字に使用されます。キーボードによって異なる場合があります。</summary>
        D0 = 11,
        /// <summary>減算記号 (-) キー</summary>
        Minus = 12,
        /// <summary>等号 (=) キー</summary>
        Equals = 13,
        /// <summary>BackSpace キー</summary>
        BackSpace = 14,
        /// <summary>BackSpace キー</summary>
        Back = 14,
        /// <summary>Tab キー</summary>
        Tab = 15,
        /// <summary>Q キー</summary>
        Q = 16,
        /// <summary>W キー</summary>
        W = 17,
        /// <summary>E キー</summary>
        E = 18,
        /// <summary>R キー</summary>
        R = 19,
        /// <summary>T キー</summary>
        T = 20,
        /// <summary>Y キー</summary>
        Y = 21,
        /// <summary>U キー</summary>
        U = 22,
        /// <summary>I キー</summary>
        I = 23,
        /// <summary>O キー</summary>
        O = 24,
        /// <summary>P キー</summary>
        P = 25,
        /// <summary>[ キー</summary>
        LeftBracket = 26,
        /// <summary>] キー</summary>
        RightBracket = 27,
        /// <summary>Return キー (Enterキー)</summary>
        Return = 28,
        /// <summary>左Ctrl キー</summary>
        LeftControl = 29,
        /// <summary>A キー</summary>
        A = 30,
        /// <summary>S キー</summary>
        S = 31,
        /// <summary>D キー</summary>
        D = 32,
        /// <summary>F キー</summary>
        F = 33,
        /// <summary>G キー</summary>
        G = 34,
        /// <summary>H キー</summary>
        H = 35,
        /// <summary>J キー</summary>
        J = 36,
        /// <summary>K キー</summary>
        K = 37,
        /// <summary>L キー</summary>
        L = 38,
        /// <summary>セミコロン (;) キー</summary>
        SemiColon = 39,
        /// <summary>アポストロフィー (') キー</summary>
        Apostrophe = 40,
        /// <summary>グレイヴ (`) キー</summary>
        Grave = 41,
        /// <summary>左Shift キー</summary>
        LeftShift = 42,
        /// <summary>バックスラッシュ (\) キー</summary>
        BackSlash = 43,
        /// <summary>Z キー</summary>
        Z = 44,
        /// <summary>X キー</summary>
        X = 45,
        /// <summary>C キー</summary>
        C = 46,
        /// <summary>V キー</summary>
        V = 47,
        /// <summary>B キー</summary>
        B = 48,
        /// <summary>N キー</summary>
        N = 49,
        /// <summary>M キー</summary>
        M = 50,
        /// <summary>カンマ (,) キー</summary>
        Comma = 51,
        /// <summary>ピリオド (.) キー</summary>
        Period = 52,
        /// <summary>スラッシュ (/) キー</summary>
        Slash = 53,
        /// <summary>右Shift キー</summary>
        RightShift = 54,
        /// <summary>NumPadStar (*) キー</summary>
        NumPadStar = 55,
        /// <summary>乗算記号 (*) キー</summary>
        Multiply = 55,
        /// <summary>LeftMenu キー (左Alt)</summary>
        LeftMenu = 56,
        /// <summary>左Alt キー</summary>
        LeftAlt = 56,
        /// <summary>スペース キー</summary>
        Space = 57,
        /// <summary>Capital キー (CapsLock)</summary>
        Capital = 58,
        /// <summary>CapsLock キー</summary>
        CapsLock = 58,
        /// <summary>F1 キー</summary>
        F1 = 59,
        /// <summary>F2 キー</summary>
        F2 = 60,
        /// <summary>F3 キー</summary>
        F3 = 61,
        /// <summary>F4 キー</summary>
        F4 = 62,
        /// <summary>F5 キー</summary>
        F5 = 63,
        /// <summary>F6 キー</summary>
        F6 = 64,
        /// <summary>F7 キー</summary>
        F7 = 65,
        /// <summary>F8 キー</summary>
        F8 = 66,
        /// <summary>F9 キー</summary>
        F9 = 67,
        /// <summary>F10 キー</summary>
        F10 = 68,
        /// <summary>Numlock キー</summary>
        Numlock = 69,
        /// <summary>Scroll キー</summary>
        Scroll = 70,
        /// <summary>数値キーパッドの 7 キー</summary>
        NumPad7 = 71,
        /// <summary>数値キーパッドの 8 キー</summary>
        NumPad8 = 72,
        /// <summary>数値キーパッドの 9 キー</summary>
        NumPad9 = 73,
        /// <summary>数値キーパッドの 減算記号(-) キー</summary>
        NumPadMinus = 74,
        /// <summary>減算記号 (-) キー</summary>
        Subtract = 74,
        /// <summary>数値キーパッドの 4 キー</summary>
        NumPad4 = 75,
        /// <summary>数値キーパッドの 5 キー</summary>
        NumPad5 = 76,
        /// <summary>数値キーパッドの 6 キー</summary>
        NumPad6 = 77,
        /// <summary>数値キーパッドの 加算記号(+) キー</summary>
        NumPadPlus = 78,
        /// <summary>加算記号 (+) キー</summary>
        Add = 78,
        /// <summary>数値キーパッドの 1 キー</summary>
        NumPad1 = 79,
        /// <summary>数値キーパッドの 2 キー</summary>
        NumPad2 = 80,
        /// <summary>数値キーパッドの 3 キー</summary>
        NumPad3 = 81,
        /// <summary>数値キーパッドの 0 キー</summary>
        NumPad0 = 82,
        /// <summary>数値キーパッドの ピリオド(.) キー</summary>
        NumPadPeriod = 83,
        /// <summary>小数点 キー</summary>
        Decimal = 83,
        /// <summary>OEM102 キー</summary>
        OEM102 = 86,
        /// <summary>F11 キー</summary>
        F11 = 87,
        /// <summary>F12 キー</summary>
        F12 = 88,
        /// <summary>F13 キー</summary>
        F13 = 100,
        /// <summary>F14 キー</summary>
        F14 = 101,
        /// <summary>F15 キー</summary>
        F15 = 102,
        /// <summary>かな キー</summary>
        Kana = 112,
        /// <summary>AbntC1 (ブラジル) キー</summary>
        AbntC1 = 115,
        /// <summary>変換 キー</summary>
        Convert = 121,
        /// <summary>無変換 キー</summary>
        NoConvert = 123,
        /// <summary>Yen キー</summary>
        Yen = 125,
        /// <summary>AbntC2 (ブラジル) キー</summary>
        AbntC2 = 126,
        /// <summary>数値キーパッドの 等号(=) キー</summary>
        NumPadEquals = 141,
        /// <summary>サーカムフレックス (^) キー</summary>
        Circumflex = 144,
        /// <summary>PrevTrack キー</summary>
        PrevTrack = 144,
        /// <summary>At キー</summary>
        At = 145,
        /// <summary>コロン (:) キー</summary>
        Colon = 146,
        /// <summary>アンダーライン (_) キー</summary>
        Underline = 147,
        /// <summary>漢字 キー</summary>
        Kanji = 148,
        /// <summary>Stop キー</summary>
        Stop = 149,
        /// <summary>AX キー</summary>
        AX = 150,
        /// <summary>ラベルなし キー</summary>
        Unlabeled = 151,
        /// <summary>NextTrack キー</summary>
        NextTrack = 153,
        /// <summary>数値キーパッドの Enter キー</summary>
        NumPadEnter = 156,
        /// <summary>右Ctrl キー</summary>
        RightControl = 157,
        /// <summary>Mute キー</summary>
        Mute = 160,
        /// <summary>Calculator キー</summary>
        Calculator = 161,
        /// <summary>PlayPause キー</summary>
        PlayPause = 162,
        /// <summary>MediaStop キー</summary>
        MediaStop = 164,
        /// <summary>VolumeDown キー</summary>
        VolumeDown = 174,
        /// <summary>VolumeUp キー</summary>
        VolumeUp = 176,
        /// <summary>WebHome キー</summary>
        WebHome = 178,
        /// <summary>数値キーパッドの コンマ(,) キー</summary>
        NumPadComma = 179,
        /// <summary>除算記号 (/) キー</summary>
        Divide = 181,
        /// <summary>数値キーパッドの スラッシュ キー</summary>
        NumPadSlash = 181,
        /// <summary>SysRq キー</summary>
        SysRq = 183,
        /// <summary>RightMenu キー (右Alt)</summary>
        RightMenu = 184,
        /// <summary>右Alt キー</summary>
        RightAlt = 184,
        /// <summary>Pause キー</summary>
        Pause = 197,
        /// <summary>Home キー</summary>
        Home = 199,
        /// <summary>上矢印 (↑) キー</summary>
        UpArrow = 200,
        /// <summary>上矢印 (↑) キー</summary>
        Up = 200,
        /// <summary>Prior</summary>
        Prior = 201,
        /// <summary>PageUp</summary>
        PageUp = 201,
        /// <summary>左矢印 (←) キー</summary>
        Left = 203,
        /// <summary>左矢印 (←) キー</summary>
        LeftArrow = 203,
        /// <summary>右矢印 (→) キー</summary>
        Right = 205,
        /// <summary>右矢印 (→) キー</summary>
        RightArrow = 205,
        /// <summary>End</summary>
        End = 207,
        /// <summary>下矢印 (↓) キー</summary>
        DownArrow = 208,
        /// <summary>下矢印 (↓) キー</summary>
        Down = 208,
        /// <summary>Next キー</summary>
        Next = 209,
        /// <summary>PageDown キー</summary>
        PageDown = 209,
        /// <summary>Insert キー</summary>
        Insert = 210,
        /// <summary>Delete キー</summary>
        Delete = 211,
        /// <summary>LeftWindows キー</summary>
        LeftWindows = 219,
        /// <summary>RightWindows キー</summary>
        RightWindows = 220,
        /// <summary>Apps キー</summary>
        Apps = 221,
        /// <summary>Power キー</summary>
        Power = 222,
        /// <summary>Sleep キー</summary>
        Sleep = 223,
        /// <summary>Wake キー</summary>
        Wake = 227,
        /// <summary>WebSearch キー</summary>
        WebSearch = 229,
        /// <summary>WebFavorites キー</summary>
        WebFavorites = 230,
        /// <summary>WebRefresh キー</summary>
        WebRefresh = 231,
        /// <summary>WebStop キー</summary>
        WebStop = 232,
        /// <summary>WebForward キー</summary>
        WebForward = 233,
        /// <summary>WebBack キー</summary>
        WebBack = 234,
        /// <summary>MyComputer キー</summary>
        MyComputer = 235,
        /// <summary>Mail キー</summary>
        Mail = 236,
        /// <summary>MediaSelect キー</summary>
        MediaSelect = 237,
    }
}
