using System;

namespace PikaLib
{
    //========================================
    // このファイルにはPikaLib中で
    // 共通の例外クラスを実装する
    //========================================

    /// <summary>
    /// 初期化が必要なオブジェクトにおいて、初期化せずに使用された場合にスローされる例外。
    /// </summary>
    public class NotInitializedException : Exception
    {
        #region コンストラクタ
        /// <summary>
        /// PikaLib.NotInitializedException クラスの新しいインスタンスを初期化します。
        /// </summary>
        public NotInitializedException()
            : base() { }

        /// <summary>
        /// 指定したエラーメッセージを使用して、
        /// PikaLib.NotInitializedException クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="message">例外の原因を説明するエラーメッセージ。</param>
        public NotInitializedException(string message)
            : base(message) { }

        /// <summary>
        /// 指定したエラーメッセージと、この例外の原因である内部例外への参照を使用して、
        /// PikaLib.NotInitializedException クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="message">例外の原因を説明するエラーメッセージ。</param>
        /// <param name="innerException">現在の例外の原因である例外。内部例外が指定されていない場合はnullを返す。</param>
        public NotInitializedException(string message, Exception innerException)
            : base(message, innerException) { }

        #endregion
    }
}
