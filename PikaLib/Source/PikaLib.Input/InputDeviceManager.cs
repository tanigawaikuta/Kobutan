using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.DirectX.DirectInput;

namespace PikaLib.Input
{
    /// <summary>
    /// 入力デバイスマネージャ。
    /// </summary>
    public class InputDeviceManager : IDisposable
    {
        #region メンバ変数
        /// <summary>ジョイスティック。</summary>
        private List<Joystick> m_Joysticks;
        /// <summary>すでに破棄済みかどうかを表すフラグ。</summary>
        private bool m_Disposed = false;

        #endregion

        #region プロパティ
        /// <summary>ジョイスティックの配列を取得します。</summary>
        public Joystick[] Joysticks { get { return m_Joysticks.ToArray(); } }
        /// <summary>ジョイスティックの数を取得します。</summary>
        public int NumberJoysticks { get { return m_Joysticks.Count; } }
        /// <summary>キーボードを取得します。</summary>
        public Keyboard Keyboard { get; private set; }

        #endregion

        #region コンストラクタ
        /// <summary>
        /// PikaLib.Input.InputDeviceManager クラスの新しいインスタンスを初期化します。
        /// </summary>
        public InputDeviceManager()
        {
        }

        #endregion

        #region 公開メソッド
        /// <summary>
        /// ジョイスティック, キーボード, マウスを初期化します。
        /// </summary>
        /// <exception cref="PikaLib.Input.InputException">DirectInput において例外が投げられた際に発生します。</exception>
        /// <exception cref="System.ObjectDisposedException">すでに破棄されているのに呼び出された際に発生します。</exception>
        public void InitializeAllInputDevices()
        {
            try
            {
                // ジョイスティックの初期化
                InitializeJoysticks();
                // キーボードの初期化
                InitializeKeyboards();
            }
            catch (Exception)
            {
                // 呼び出し前の状態に戻した後、再スロー
                DisposeJoystics();
                DisposeKeybord();
                throw;
            }
        }

        /// <summary>
        /// ジョイスティックを初期化します。
        /// </summary>
        /// <exception cref="PikaLib.Input.InputException">DirectInput において例外が投げられた際に発生します。</exception>
        /// <exception cref="System.ObjectDisposedException">すでに破棄されているのに呼び出された際に発生します。</exception>
        public void InitializeJoysticks()
        {
            InitializeJoysticks((System.IntPtr)null,
                CooperativeLevelFlags.NonExclusive
                | CooperativeLevelFlags.NoWindowsKey
                | CooperativeLevelFlags.Background,
                new InputRange(-1000, 1000));
        }

        /// <summary>
        /// ジョイスティックを初期化します。
        /// </summary>
        /// <param name="hwnd">ウィンドウハンドル (BackgroundではnullでOK)。</param>
        /// <param name="flags">他のインスタンス、およびシステムとの間でどのように対話するかを決定するフラグ。</param>
        /// <exception cref="PikaLib.Input.InputException">DirectInput において例外が投げられた際に発生します。</exception>
        /// <exception cref="System.ObjectDisposedException">すでに破棄されているのに呼び出された際に発生します。</exception>
        public void InitializeJoysticks(IntPtr hwnd, CooperativeLevelFlags flags)
        {
            InitializeJoysticks(hwnd, flags, new InputRange(-1000, 1000));
        }

        /// <summary>
        /// ジョイスティックを初期化します。
        /// </summary>
        /// <param name="inputRange">入力範囲。</param>
        /// <exception cref="PikaLib.Input.InputException">DirectInput において例外が投げられた際に発生します。</exception>
        /// <exception cref="System.ObjectDisposedException">すでに破棄されているのに呼び出された際に発生します。</exception>
        public void InitializeJoysticks(InputRange inputRange)
        {
            InitializeJoysticks((System.IntPtr)null,
                CooperativeLevelFlags.NonExclusive
                | CooperativeLevelFlags.NoWindowsKey
                | CooperativeLevelFlags.Background,
                inputRange);
        }

        /// <summary>
        /// ジョイスティックを初期化します。
        /// </summary>
        /// <param name="hwnd">ウィンドウハンドル (BackgroundではnullでOK)。</param>
        /// <param name="flags">他のインスタンス、およびシステムとの間でどのように対話するかを決定するフラグ。</param>
        /// <param name="inputRange">入力範囲。</param>
        /// <exception cref="PikaLib.Input.InputException">DirectInput において例外が投げられた際に発生します。</exception>
        /// <exception cref="System.ObjectDisposedException">すでに破棄されているのに呼び出された際に発生します。</exception>
        public void InitializeJoysticks(IntPtr hwnd, CooperativeLevelFlags flags, InputRange inputRange)
        {
            // 例外処理
            if (m_Disposed)
                throw new ObjectDisposedException("InputDevice");

            try
            {
                // ジョイスティックを格納するためのリストを生成
                m_Joysticks = new List<Joystick>();
                // コントローラのリストを取得
                DeviceList controllers = Manager.GetDevices(DeviceClass.GameControl, EnumDevicesFlags.AllDevices);
                // 取得したコントローラリストの要素からJoystickを生成し1つずつ登録
                foreach (DeviceInstance instance in controllers)
                {
                    // デバイスの生成
                    Device device = CreateDevice(instance.InstanceGuid, hwnd, flags, inputRange);
                    // とりあえずデバイスを動かす
                    try { device.Acquire(); }
                    catch (Microsoft.DirectX.DirectXException) { }
                    // Joystickを生成し、Joystickリストに追加
                    m_Joysticks.Add(new Joystick(device));
                }
            }
            catch (Microsoft.DirectX.DirectInput.InputException ex)
            {
                // DirectInputでの例外
                DisposeJoystics();
                throw new PikaLib.Input.InputException(ex.Message, ex);
            }
            catch (System.Exception)
            {
                // その他例外
                DisposeJoystics();
                throw;
            }
        }

        /// <summary>
        /// キーボードを初期化します。
        /// </summary>
        /// <exception cref="PikaLib.Input.InputException">DirectInput において例外が投げられた際に発生します。</exception>
        /// <exception cref="System.ObjectDisposedException">すでに破棄されているのに呼び出された際に発生します。</exception>
        public void InitializeKeyboards()
        {
            // 例外処理
            if (m_Disposed)
                throw new ObjectDisposedException("InputDevice");

            try
            {
                Device device = new Device(SystemGuid.Keyboard);
                try { device.Acquire(); }
                catch (Microsoft.DirectX.DirectXException) { }
                Keyboard = new Keyboard(device);
            }
            catch (Microsoft.DirectX.DirectInput.InputException ex)
            {
                // DirectInputでの例外
                DisposeKeybord();
                throw new PikaLib.Input.InputException(ex.Message, ex);
            }
            catch (System.Exception)
            {
                // その他例外
                DisposeKeybord();
                throw;
            }
        }

        /// <summary>
        /// キーボードを初期化します。
        /// </summary>
        /// <param name="hwnd">ウィンドウハンドル (BackgroundではnullでOK)。</param>
        /// <param name="flags">他のインスタンス、およびシステムとの間でどのように対話するかを決定するフラグ。</param>
        /// <exception cref="PikaLib.Input.InputException">DirectInput において例外が投げられた際に発生します。</exception>
        /// <exception cref="System.ObjectDisposedException">すでに破棄されているのに呼び出された際に発生します。</exception>
        public void InitializeKeyboards(IntPtr hwnd, CooperativeLevelFlags flags)
        {
            // 例外処理
            if (m_Disposed)
                throw new ObjectDisposedException("InputDevice");

            try
            {
                Device device = CreateDevice(SystemGuid.Keyboard, hwnd, flags, new InputRange(-1000, 1000));
                try { device.Acquire(); }
                catch (Microsoft.DirectX.DirectXException) { }
                Keyboard = new Keyboard(device);
            }
            catch (Microsoft.DirectX.DirectInput.InputException ex)
            {
                // DirectInputでの例外
                DisposeKeybord();
                throw new PikaLib.Input.InputException(ex.Message, ex);
            }
            catch (System.Exception)
            {
                // その他例外
                DisposeKeybord();
                throw;
            }
        }

        /// <summary>
        /// 全てのデバイスの状態を更新します。
        /// </summary>
        /// <exception cref="PikaLib.NotInitializedException">初期化前に呼び出された際に発生します。</exception>
        /// <exception cref="System.ObjectDisposedException">すでに破棄されているのに呼び出された際に発生します。</exception>
        public void UpdateAllDeviceState()
        {
            // 例外処理
            if (m_Disposed)
                throw new ObjectDisposedException("InputDevice");
            if (m_Joysticks == null)
                throw new NotInitializedException(ExceptionMessages.NotInitializedExceptionMessage1 + "\r\n" + @"初期化されていないオブジェクト: Joystick");
            if (Keyboard == null)
                throw new NotInitializedException(ExceptionMessages.NotInitializedExceptionMessage1 + "\r\n" + @"初期化されていないオブジェクト: Keyboard");

            // ジョイスティックの状態を更新
            UpdateJoysticksState();
            // キーボードの状態を更新
            try { Keyboard.UpdateState(); }
            catch (Exception) { }
        }

        /// <summary>
        /// ジョイスティックの状態を更新します。
        /// </summary>
        /// <exception cref="PikaLib.NotInitializedException">初期化前に呼び出された際に発生します。</exception>
        /// <exception cref="System.ObjectDisposedException">すでに破棄されているのに呼び出された際に発生します。</exception>
        public void UpdateJoysticksState()
        {
            // 例外処理
            if (m_Disposed)
                throw new ObjectDisposedException("InputDevice");
            if (m_Joysticks == null)
                throw new NotInitializedException(ExceptionMessages.NotInitializedExceptionMessage1 + "\r\n" + @"初期化されていないオブジェクト: Joystick");

            foreach (Joystick j in m_Joysticks)
            {
                try { j.UpdateState(); }
                catch (Exception) { }
            }
        }

        #endregion

        #region 非公開メソッド
        /// <summary>
        /// DirectInputのデバイスを作成します。
        /// </summary>
        /// <param name="instanceGuid">インスタンス GUID。</param>
        /// <param name="hwnd">ウィンドウハンドル (BackgroundではnullでOK)。</param>
        /// <param name="flags">他のインスタンス、およびシステムとの間でどのように対話するかを決定するフラグ。</param>
        /// <param name="inputRange">入力範囲。</param>
        /// <returns>DirectInputのデバイス。</returns>
        private Device CreateDevice(Guid instanceGuid, IntPtr hwnd, CooperativeLevelFlags flags, InputRange inputRange)
        {
            // デバイスの生成
            Device device = new Device(instanceGuid);
            // 各種フラグの設定
            device.SetCooperativeLevel(hwnd, (Microsoft.DirectX.DirectInput.CooperativeLevelFlags)flags);
            // アナログスティックなどのAxis要素を持つDeviceObjectInstanceの出力レンジを設定
            foreach (DeviceObjectInstance doi in device.Objects)
            {
                if ((doi.ObjectId & (int)DeviceObjectTypeFlags.Axis) != 0)
                {
                    device.Properties.SetRange(
                        ParameterHow.ById,
                        doi.ObjectId,
                        new Microsoft.DirectX.DirectInput.InputRange(inputRange.Min, inputRange.Max));
                }
            }
            // Axisの絶対位置モードを設定
            device.Properties.AxisModeAbsolute = true;

            // 生成したデバイスを返す
            return device;
        }

        /// <summary>
        /// 現在のジョイスティックを全て処分します。
        /// </summary>
        private void DisposeJoystics()
        {
            foreach (Joystick j in m_Joysticks)
            {
                j.Dispose();
            }
            m_Joysticks.Clear();
            m_Joysticks = null;
        }

        /// <summary>
        /// キーボードを処分します。
        /// </summary>
        private void DisposeKeybord()
        {
            if (Keyboard != null)
            {
                Keyboard.Dispose();
                Keyboard = null;
            }
        }

        #endregion

        #region IDisposableメンバの実装
        /// <summary>
        /// 使用中のリソースを解放します。
        /// </summary>
        public void Dispose()
        {
            //マネージリソースおよびアンマネージリソースの解放
            this.Dispose(true);
            //ガベコレから、このオブジェクトのデストラクタを対象外とする
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 使用中のリソースを解放します。
        /// </summary>
        /// <param name="disposing">マネージリソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected virtual void Dispose(bool disposing)
        {
            // 既に破棄されていれば何もしない
            if (m_Disposed)
                return;

            // リソースの解放
            if (disposing)
            {
                // マネージリソースの解放
                DisposeJoystics();
                DisposeKeybord();
            }
            // アンマネージリソースの解放

            // 破棄済みフラグを設定
            m_Disposed = true;
        }

        #endregion
    }
}
