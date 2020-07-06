using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PikaLib.Input
{
    /// <summary>
    /// PikaLib.Input 上の例外
    /// </summary>
    public class InputException : Microsoft.DirectX.DirectInput.InputException
    {
        #region コンストラクタ
        /// <summary>
        /// PikaLib.Input.InputException クラスの新しいインスタンスを初期化します。
        /// </summary>
        public InputException()
            : base() { }

        /// <summary>
        /// 指定したエラーメッセージを使用して、
        /// PikaLib.Input.InputException クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="message">例外の原因を説明するエラーメッセージ。</param>
        public InputException(string message)
            : base(message) { }

        /// <summary>
        /// 指定したエラーメッセージと、この例外の原因である内部例外への参照を使用して、
        /// PikaLib.Input.InputException クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="message">例外の原因を説明するエラーメッセージ。</param>
        /// <param name="innerException">現在の例外の原因である例外。内部例外が指定されていない場合はnullを返す。</param>
        public InputException(string message, Exception innerException)
            : base(message, innerException) { }

        #endregion
    }
}
