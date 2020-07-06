using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Commander.Script
{
    /// <summary>
    /// スクリプトの例外
    /// </summary>
    public class ScriptException : Exception
    {
    }

    /// <summary>
    /// スクリプトの構文エラーの例外
    /// </summary>
    public class ScriptSyntaxErrorException : ScriptException
    {
    }
}
