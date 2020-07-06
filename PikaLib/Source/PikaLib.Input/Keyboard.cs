using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.DirectX.DirectInput;

namespace PikaLib.Input
{
    /// <summary>
    /// キーボード。
    /// </summary>
    public class Keyboard : InputDevice
    {
        #region メンバ変数
        /// <summary>
        /// キーボードの状態。
        /// </summary>
        protected KeyboardState m_KeyboardState;
        
        /// <summary>
        /// すでに破棄済みかどうかを表すフラグ。
        /// </summary>
        private bool m_Disposed = false;

        #endregion

        #region インデクサ
        /// <summary>
        /// 指定されたキーが押されているか調べる。 
        /// </summary>
        /// <param name="key">キーの種類。</param>
        /// <returns>指定されたキーが押されているかどうかの真偽値。</returns>
        public bool this[Key key]
        {
            get
            {
                // 例外処理
                if (m_Disposed)
                    throw new ObjectDisposedException(ObjectName);

                return m_KeyboardState[(Microsoft.DirectX.DirectInput.Key)key];
            }
        }

        #endregion

        #region プロパティ
        /// <summary>
        /// オブジェクト名
        /// </summary>
        public override string ObjectName { get { return "Keyboard"; } }

        #endregion

        #region コンストラクタ
        /// <summary>
        /// DirectInputのデバイスを使って、
        /// PikaLib.Input.Keyboard クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="device">DirectInputのデバイス</param>
        public Keyboard(Device device)
            : base(device)
        {
        }

        #endregion

        #region オーバーライド
        /// <summary>
        /// 最新状態を適用します。
        /// </summary>
        protected override void ApplyNewState()
        {
            // 最新状態の適用
            m_KeyboardState = m_Device.GetCurrentKeyboardState();
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
