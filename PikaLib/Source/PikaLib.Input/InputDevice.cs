using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.DirectX.DirectInput;

namespace PikaLib.Input
{
    /// <summary>
    /// 入力デバイス。
    /// </summary>
    public abstract class InputDevice : IDisposable
    {
        #region メンバ変数
        /// <summary>DirectInputのデバイス。</summary>
        protected Device m_Device;
        /// <summary>すでに破棄済みかどうかを表すフラグ。</summary>
        private bool m_Disposed = false;

        #endregion

        #region プロパティ
        /// <summary>
        /// オブジェクト名
        /// </summary>
        public virtual string ObjectName { get { return "InputDevice"; } }

        /// <summary>
        /// 製品名を取得します。
        /// </summary>
        public string ProductName
        {
            get
            {
                // 例外処理
                if (m_Disposed)
                    throw new ObjectDisposedException(ObjectName);
                return m_Device.DeviceInformation.ProductName;
            }
        }
        
        /// <summary>
        /// 製品 GUID を取得します。
        /// </summary>
        public Guid ProductGuid
        {
            get
            {
                // 例外処理
                if (m_Disposed)
                    throw new ObjectDisposedException(ObjectName);
                return m_Device.DeviceInformation.ProductGuid;
            }
        }
        
        /// <summary>
        /// インスタンス名を取得します。
        /// </summary>
        public string InstanceName
        {
            get
            {
                // 例外処理
                if (m_Disposed)
                    throw new ObjectDisposedException(ObjectName);
                return m_Device.DeviceInformation.InstanceName;
            }
        }
        
        /// <summary>
        /// インスタンス GUID を取得します。
        /// </summary>
        public Guid InstanceGuid
        {
            get
            {
                // 例外処理
                if (m_Disposed)
                    throw new ObjectDisposedException(ObjectName);
                return m_Device.DeviceInformation.InstanceGuid;
            }
        }

        #endregion

        #region コンストラクタ
        /// <summary>
        /// DirectInputのデバイスを使って、
        /// PikaLib.Input.InputDevice クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="device">DirectInputのデバイス。</param>
        /// <exception cref="System.ArgumentException">不正なパラメータが渡された際に発生します。</exception>
        /// <exception cref="System.ArgumentNullException">nullがパラメータとして渡された際に発生します。</exception>
        public InputDevice(Device device)
        {
            // 例外処理
            if (device == null)
                throw new ArgumentNullException("device");
            if (!(device is Device))
                throw new ArgumentException(ExceptionMessages.ArgumentExceptionMessage1, "device");

            // 引数の受け渡し
            m_Device = device;
        }

        #endregion

        #region 公開メソッド
        /// <summary>
        /// アクセス権を取得します。
        /// </summary>
        /// <exception cref="PikaLib.Input.InputException">DirectInput において例外が投げられた際に発生します。</exception>
        /// <exception cref="System.ObjectDisposedException">すでに破棄されているのに呼び出された際に発生します。</exception>
        public void Acquire()
        {
            // 例外処理
            if (m_Disposed)
                throw new ObjectDisposedException(ObjectName);

            try
            {
                // アクセス権を取得
                m_Device.Acquire();
            }
            catch (Microsoft.DirectX.DirectInput.InputException ex)
            {
                throw new PikaLib.Input.InputException(ex.Message, ex);
            }
        }

        /// <summary>
        /// アクセス権を解放します。
        /// </summary>
        /// <exception cref="PikaLib.Input.InputException">DirectInput において例外が投げられた際に発生します。</exception>
        /// <exception cref="System.ObjectDisposedException">すでに破棄されているのに呼び出された際に発生します。</exception>
        public void Unacquire()
        {
            // 例外処理
            if (m_Disposed)
                throw new ObjectDisposedException(ObjectName);

            try
            {
                // アクセス権を解放
                m_Device.Unacquire();
            }
            catch (Microsoft.DirectX.DirectInput.InputException ex)
            {
                throw new PikaLib.Input.InputException(ex.Message, ex);
            }
        }

        /// <summary>
        /// 状態を更新します。
        /// </summary>
        /// <exception cref="PikaLib.Input.InputException">DirectInput において例外が投げられた際に発生します。</exception>
        /// <exception cref="System.ObjectDisposedException">すでに破棄されているのに呼び出された際に発生します。</exception>
        public void UpdateState()
        {
            // 例外処理
            if (m_Disposed)
                throw new ObjectDisposedException(ObjectName);

            // 最新情報を取得
            try
            {
                // デバイスから最新情報を掘り出す
                m_Device.Poll();
                // ここから派生クラスの追加処理
                // 最新状態の適用
                ApplyNewState();
            }
            catch (Microsoft.DirectX.DirectInput.NotAcquiredException)
            {
                // ここに来た時はAcquireできていないので試してみる
                try
                {
                    m_Device.Acquire();
                    m_Device.Poll();
                    // ここから派生クラスの追加処理
                    // 最新状態の適用
                    ApplyNewState();
                }
                catch (Microsoft.DirectX.DirectInput.InputException ex)
                {
                    throw new PikaLib.Input.InputException(ex.Message, ex);
                }
            }
            catch (Microsoft.DirectX.DirectInput.InputException ex)
            {
                throw new PikaLib.Input.InputException(ex.Message, ex);
            }
        }

        #endregion

        #region 抽象メソッド
        /// <summary>
        /// 最新状態を適用します。
        /// </summary>
        protected abstract void ApplyNewState();

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
                m_Device.Dispose();
            }
            // アンマネージリソースの解放

            // 破棄済みフラグを設定
            m_Disposed = true;
        }

        #endregion
    }
}
