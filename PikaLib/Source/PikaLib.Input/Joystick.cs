using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.DirectX.DirectInput;

namespace PikaLib.Input
{
    /// <summary>
    /// ジョイスティック。
    /// </summary>
    public class Joystick : InputDevice
    {
        #region メンバ変数
        /// <summary>
        /// ジョイスティックの状態。
        /// </summary>
        protected JoystickState m_JoystickState;

        /// <summary>
        /// すでに破棄済みかどうかを表すフラグ。
        /// </summary>
        private bool m_Disposed = false;

        #endregion

        #region プロパティ
        //========================
        // デバイスに関する情報
        //========================
        /// <summary>
        /// オブジェクト名
        /// </summary>
        public override string ObjectName { get { return "Joystick"; } }
        
        /// <summary>
        /// 軸の数を取得します。
        /// </summary>
        public int NumberAxes
        {
            get
            {
                // 例外処理
                if (m_Disposed)
                    throw new ObjectDisposedException(ObjectName);
                return m_Device.Caps.NumberAxes;
            }
        }

        /// <summary>ボタンの数を取得します。</summary>
        public int NumberButtons
        {
            get
            {
                // 例外処理
                if (m_Disposed)
                    throw new ObjectDisposedException(ObjectName);
                return m_Device.Caps.NumberButtons;
            }
        }

        /// <summary>
        /// PoVハットの数を取得します。
        /// </summary>
        public int NumberPointOfViews
        {
            get
            {
                // 例外処理
                if (m_Disposed)
                    throw new ObjectDisposedException(ObjectName);
                return m_Device.Caps.NumberPointOfViews;
            }
        }

        /// <summary>
        /// アナログスティックの入力範囲を取得または設定します。
        /// </summary>
        public InputRange InputRange
        {
            get
            {
                // 例外処理
                if (m_Disposed)
                    throw new ObjectDisposedException(ObjectName);

                Microsoft.DirectX.DirectInput.InputRange ir = new Microsoft.DirectX.DirectInput.InputRange();
                foreach (DeviceObjectInstance oi in m_Device.Objects)
                {
                    if ((oi.ObjectId & (int)Microsoft.DirectX.DirectInput.DeviceObjectTypeFlags.Axis) != 0)
                    {
                        ir = m_Device.Properties.GetRange(ParameterHow.ById, oi.ObjectId);
                        break;
                    }
                }
                return new InputRange(ir.Min, ir.Max);
            }

            set
            {
                // 例外処理
                if (m_Disposed)
                    throw new ObjectDisposedException(ObjectName);

                foreach (DeviceObjectInstance oi in m_Device.Objects)
                {
                    if ((oi.ObjectId & (int)Microsoft.DirectX.DirectInput.DeviceObjectTypeFlags.Axis) != 0)
                    {
                        m_Device.Properties.SetRange(ParameterHow.ById,
                            oi.ObjectId,
                            new Microsoft.DirectX.DirectInput.InputRange(value.Min, value.Max));
                    }
                }
            }
        }

        //========================
        // 十字キー, スティック
        //========================
        /// <summary>PoVハットを取得します。</summary>
        public JoystickPOV POV { get { return GetJoystickPOV(0); } }
        /// <summary>アナログスティック X を取得します。</summary>
        public int X { get { return GetAnalogStick(JoystickAxis.AXIS_X); } }
        /// <summary>アナログスティック Y を取得します。</summary>
        public int Y { get { return GetAnalogStick(JoystickAxis.AXIS_Y); } }
        /// <summary>アナログスティック Z を取得します。</summary>
        public int Z { get { return GetAnalogStick(JoystickAxis.AXIS_Z); } }
        /// <summary>アナログスティック RX を取得します。</summary>
        public int RX { get { return GetAnalogStick(JoystickAxis.AXIS_RX); } }
        /// <summary>アナログスティック RY を取得します。</summary>
        public int RY { get { return GetAnalogStick(JoystickAxis.AXIS_RY); } }
        /// <summary>アナログスティック RZ を取得します。</summary>
        public int RZ { get { return GetAnalogStick(JoystickAxis.AXIS_RZ); } }
        /// <summary>アナログスティック AX を取得します。</summary>
        public int AX { get { return GetAnalogStick(JoystickAxis.AXIS_AX); } }
        /// <summary>アナログスティック AY を取得します。</summary>
        public int AY { get { return GetAnalogStick(JoystickAxis.AXIS_AY); } }
        /// <summary>アナログスティック AZ を取得します。</summary>
        public int AZ { get { return GetAnalogStick(JoystickAxis.AXIS_AZ); } }
        /// <summary>アナログスティック ARX を取得します。</summary>
        public int ARX { get { return GetAnalogStick(JoystickAxis.AXIS_ARX); } }
        /// <summary>アナログスティック ARY を取得します。</summary>
        public int ARY { get { return GetAnalogStick(JoystickAxis.AXIS_ARY); } }
        /// <summary>アナログスティック ARZ を取得します。</summary>
        public int ARZ { get { return GetAnalogStick(JoystickAxis.AXIS_ARZ); } }
        /// <summary>アナログスティック FX を取得します。</summary>
        public int FX { get { return GetAnalogStick(JoystickAxis.AXIS_FX); } }
        /// <summary>アナログスティック FY を取得します。</summary>
        public int FY { get { return GetAnalogStick(JoystickAxis.AXIS_FY); } }
        /// <summary>アナログスティック FZ を取得します。</summary>
        public int FZ { get { return GetAnalogStick(JoystickAxis.AXIS_FZ); } }
        /// <summary>アナログスティック FRX を取得します。</summary>
        public int FRX { get { return GetAnalogStick(JoystickAxis.AXIS_FRX); } }
        /// <summary>アナログスティック FRY を取得します。</summary>
        public int FRY { get { return GetAnalogStick(JoystickAxis.AXIS_FRY); } }
        /// <summary>アナログスティック FRZ を取得します。</summary>
        public int FRZ { get { return GetAnalogStick(JoystickAxis.AXIS_FRZ); } }
        /// <summary>アナログスティック VX を取得します。</summary>
        public int VX { get { return GetAnalogStick(JoystickAxis.AXIS_VX); } }
        /// <summary>アナログスティック VY を取得します。</summary>
        public int VY { get { return GetAnalogStick(JoystickAxis.AXIS_VY); } }
        /// <summary>アナログスティック VZ を取得します。</summary>
        public int VZ { get { return GetAnalogStick(JoystickAxis.AXIS_VZ); } }
        /// <summary>アナログスティック VRX を取得します。</summary>
        public int VRX { get { return GetAnalogStick(JoystickAxis.AXIS_VRX); } }
        /// <summary>アナログスティック VRY を取得します。</summary>
        public int VRY { get { return GetAnalogStick(JoystickAxis.AXIS_VRY); } }
        /// <summary>アナログスティック VRZ を取得します。</summary>
        public int VRZ { get { return GetAnalogStick(JoystickAxis.AXIS_VRZ); } }

        #endregion

        #region コンストラクタ
        /// <summary>
        /// DirectInputのデバイスを使って、
        /// PikaLib.Input.Joystick クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="device">DirectInputのデバイス。</param>
        public Joystick(Device device)
            : base(device)
        {
        }

        #endregion

        #region 公開メソッド
        /// <summary>
        /// PoVハットの状態を取得します。
        /// </summary>
        /// <param name="povID">取得するPoVハットのID。</param>
        /// <returns>ハットスイッチの状態。</returns>
        /// <exception cref="System.ObjectDisposedException">すでに破棄されているのに呼び出された際に発生します。</exception>
        public JoystickPOV GetJoystickPOV(int povID)
        {
            // 例外処理
            if (m_Disposed)
                throw new ObjectDisposedException(ObjectName);

            // 範囲外ならNONEを返す
            if ((povID >= NumberPointOfViews) || (povID < 0))
                return JoystickPOV.POV_NONE;

            int povValue = m_JoystickState.GetPointOfView()[povID];
            // 値から返す結果を決定する
            switch (povValue)
            {
                case 0:
                    return JoystickPOV.POV_UP;
                case 4500:
                    return JoystickPOV.POV_RIGHT_UP;
                case 9000:
                    return JoystickPOV.POV_RIGHT;
                case 13500:
                    return JoystickPOV.POV_RIGHT_DOWN;
                case 18000:
                    return JoystickPOV.POV_DOWN;
                case 22500:
                    return JoystickPOV.POV_LEFT_DOWN;
                case 27000:
                    return JoystickPOV.POV_LEFT;
                case 31500:
                    return JoystickPOV.POV_LEFT_UP;
                default:
                    return JoystickPOV.POV_NONE;
            }
        }

        /// <summary>
        /// アナログスティックの状態を取得します。
        /// </summary>
        /// <param name="axis">取得したい軸の種類。</param>
        /// <returns>アナログスティックの状態。</returns>
        /// <exception cref="System.ObjectDisposedException">すでに破棄されているのに呼び出された際に発生します。</exception>
        public int GetAnalogStick(JoystickAxis axis)
        {
            // 例外処理
            if (m_Disposed)
                throw new ObjectDisposedException(ObjectName);

            // 引数で指定された軸の結果を返す
            int axisValue = 0;
            switch (axis)
            {
                case JoystickAxis.AXIS_X:
                    axisValue = m_JoystickState.X;
                    break;
                case JoystickAxis.AXIS_Y:
                    axisValue = m_JoystickState.Y;
                    break;
                case JoystickAxis.AXIS_Z:
                    axisValue = m_JoystickState.Z;
                    break;
                case JoystickAxis.AXIS_RX:
                    axisValue = m_JoystickState.Rx;
                    break;
                case JoystickAxis.AXIS_RY:
                    axisValue = m_JoystickState.Ry;
                    break;
                case JoystickAxis.AXIS_RZ:
                    axisValue = m_JoystickState.Rz;
                    break;
                case JoystickAxis.AXIS_AX:
                    axisValue = m_JoystickState.AX;
                    break;
                case JoystickAxis.AXIS_AY:
                    axisValue = m_JoystickState.AY;
                    break;
                case JoystickAxis.AXIS_AZ:
                    axisValue = m_JoystickState.AZ;
                    break;
                case JoystickAxis.AXIS_ARX:
                    axisValue = m_JoystickState.ARx;
                    break;
                case JoystickAxis.AXIS_ARY:
                    axisValue = m_JoystickState.ARy;
                    break;
                case JoystickAxis.AXIS_ARZ:
                    axisValue = m_JoystickState.ARz;
                    break;
                case JoystickAxis.AXIS_FX:
                    axisValue = m_JoystickState.FX;
                    break;
                case JoystickAxis.AXIS_FY:
                    axisValue = m_JoystickState.FY;
                    break;
                case JoystickAxis.AXIS_FZ:
                    axisValue = m_JoystickState.FZ;
                    break;
                case JoystickAxis.AXIS_FRX:
                    axisValue = m_JoystickState.FRx;
                    break;
                case JoystickAxis.AXIS_FRY:
                    axisValue = m_JoystickState.FRy;
                    break;
                case JoystickAxis.AXIS_FRZ:
                    axisValue = m_JoystickState.FRz;
                    break;
                case JoystickAxis.AXIS_VX:
                    axisValue = m_JoystickState.VX;
                    break;
                case JoystickAxis.AXIS_VY:
                    axisValue = m_JoystickState.VY;
                    break;
                case JoystickAxis.AXIS_VZ:
                    axisValue = m_JoystickState.VZ;
                    break;
                case JoystickAxis.AXIS_VRX:
                    axisValue = m_JoystickState.VRx;
                    break;
                case JoystickAxis.AXIS_VRY:
                    axisValue = m_JoystickState.VRy;
                    break;
                case JoystickAxis.AXIS_VRZ:
                    axisValue = m_JoystickState.VRz;
                    break;
                default:
                    axisValue = 0;
                    break;
            }
            // 結果を返す
            return axisValue;
        }

        /// <summary>
        /// 指定されたボタンが押されているかを判定します。
        /// </summary>
        /// <param name="buttonID">調べるボタンのID。</param>
        /// <returns>押されているかどうかの真偽値。</returns>
        /// <exception cref="System.ObjectDisposedException">すでに破棄されているのに呼び出された際に発生します。</exception>
        public bool IsButtonPush(int buttonID)
        {
            // 例外処理
            if (m_Disposed)
                throw new ObjectDisposedException(ObjectName);

            // 範囲外ならfalseを返す
            if ((buttonID < 0) || (buttonID > 32))
                return false;

            // 結果を返す
            return m_JoystickState.GetButtons()[buttonID].Equals(128);
        }

        #endregion

        #region オーバーライド
        /// <summary>
        /// 最新状態を適用します。
        /// </summary>
        protected override void ApplyNewState()
        {
            // 最新状態の適用
            m_JoystickState = m_Device.CurrentJoystickState;
        }

        /// <summary>
        /// 使用中のリソースを解放します。
        /// </summary>
        /// <param name="disposing">マネージリソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            // 既に破棄されていれば何もしない
            if (m_Disposed)
                return;

            // リソースの解放
            if (disposing)
            {
                // マネージリソースの解放
            }
            // アンマネージリソースの解放

            // 親クラスのリソースを解放
            base.Dispose(disposing);

            // 破棄済みフラグを設定
            m_Disposed = true;
        }

        #endregion
    }
}
