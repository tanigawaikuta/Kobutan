using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PikaLib.Input
{
    /// <summary>
    /// 入力範囲。
    /// </summary>
    [Serializable]
    public struct InputRange
    {
        #region メンバ変数
        /// <summary>入力範囲の最大値。</summary>
        private int m_Max;
        /// <summary>入力範囲の最小値。</summary>
        private int m_Min;

        #endregion

        #region プロパティ
        /// <summary>入力範囲の最大値を取得または設定します。</summary>
        public int Max { get { return m_Max; } set { m_Max = value; } }
        /// <summary>入力範囲の最小値を取得または設定します。</summary>
        public int Min { get { return m_Min; } set { m_Min = value; } }

        #endregion

        #region コンストラクタ
        /// <summary>
        /// 入力範囲の最小値、最大値を使用して、
        /// PikaLib.Input.InputRange クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="minimumRange">入力範囲の最小値。</param>
        /// <param name="maximumRange">入力範囲の最大値。</param>
        public InputRange(int minimumRange, int maximumRange)
        {
            m_Min = minimumRange;
            m_Max = maximumRange;
        }

        #endregion
    }

    /// <summary>
    /// 他のインスタンス、およびシステムとの間でどのように対話するかを決定するフラグ。
    /// </summary>
    [Flags]
    public enum CooperativeLevelFlags
    {
        /// <summary>他のアプリケーションにデバイスへのアクセス権が無くなります。</summary>
        Exclusive = 1,
        /// <summary>他のアプリケーションもデバイスへアクセス可能です。</summary>
        NonExclusive = 2,
        /// <summary>アクティブ時限定で値の取得が可能です。</summary>
        Foreground = 4,
        /// <summary>非アクティブ時でも値の所得が可能です。</summary>
        Background = 8,
        /// <summary>キー無効化。</summary>
        NoWindowsKey = 16,
    }
}
