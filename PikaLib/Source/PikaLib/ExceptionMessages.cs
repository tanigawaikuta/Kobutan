using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PikaLib
{
    /// <summary>
    /// 例外メッセージ。
    /// </summary>
    public static class ExceptionMessages
    {
        /// <summary>
        /// ArgumentException 時のメッセージ その1
        /// </summary>
        public static readonly string ArgumentExceptionMessage1 = @"不正なパラメータが渡されました。";

        /// <summary>
        /// NotInitializedException 時のメッセージ その1
        /// </summary>
        public static readonly string NotInitializedExceptionMessage1 = @"初期化されていません。";
    }
}
