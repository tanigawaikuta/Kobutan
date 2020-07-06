using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PikaLib.Input
{
    /// <summary>
    /// アナログスティックの軸名称。
    /// </summary>
    public enum JoystickAxis
    {
        /// <summary>アナログスティック無し。</summary>
        AXIS_NONE,
        /// <summary>アナログスティック X。</summary>
        AXIS_X,
        /// <summary>アナログスティック Y。</summary>
        AXIS_Y,
        /// <summary>アナログスティック Z。</summary>
        AXIS_Z,
        /// <summary>アナログスティック RX。</summary>
        AXIS_RX,
        /// <summary>アナログスティック RY。</summary>
        AXIS_RY,
        /// <summary>アナログスティック RZ。</summary>
        AXIS_RZ,
        /// <summary>アナログスティック AX。</summary>
        AXIS_AX,
        /// <summary>アナログスティック AY。</summary>
        AXIS_AY,
        /// <summary>アナログスティック AZ。</summary>
        AXIS_AZ,
        /// <summary>アナログスティック ARX。</summary>
        AXIS_ARX,
        /// <summary>アナログスティック ARY。</summary>
        AXIS_ARY,
        /// <summary>アナログスティック ARZ。</summary>
        AXIS_ARZ,
        /// <summary>アナログスティック FX。</summary>
        AXIS_FX,
        /// <summary>アナログスティック FY。</summary>
        AXIS_FY,
        /// <summary>アナログスティック FZ。</summary>
        AXIS_FZ,
        /// <summary>アナログスティック FRX。</summary>
        AXIS_FRX,
        /// <summary>アナログスティック FRY。</summary>
        AXIS_FRY,
        /// <summary>アナログスティック FRZ。</summary>
        AXIS_FRZ,
        /// <summary>アナログスティック VX。</summary>
        AXIS_VX,
        /// <summary>アナログスティック VY。</summary>
        AXIS_VY,
        /// <summary>アナログスティック VZ。</summary>
        AXIS_VZ,
        /// <summary>アナログスティック VRX。</summary>
        AXIS_VRX,
        /// <summary>アナログスティック VRY。</summary>
        AXIS_VRY,
        /// <summary>アナログスティック VRZ。</summary>
        AXIS_VRZ
    }

    /// <summary>
    /// PoVハットの状態。
    /// </summary>
    [Flags]
    public enum JoystickPOV
    {
        /// <summary>押されていない状態。</summary>
        POV_NONE = 0x00,
        /// <summary>上。</summary>
        POV_UP = 0x01,
        /// <summary>右上。</summary>
        POV_RIGHT_UP = 0x03,
        /// <summary>右。</summary>
        POV_RIGHT = 0x02,
        /// <summary>右下。</summary>
        POV_RIGHT_DOWN = 0x06,
        /// <summary>下。</summary>
        POV_DOWN = 0x04,
        /// <summary>左下。</summary>
        POV_LEFT_DOWN = 0x0C,
        /// <summary>左。</summary>
        POV_LEFT = 0x08,
        /// <summary>左上。</summary>
        POV_LEFT_UP = 0x09,
        /// <summary>全ボタン。</summary>
        POV_ALL = 0x0f
    }
}
