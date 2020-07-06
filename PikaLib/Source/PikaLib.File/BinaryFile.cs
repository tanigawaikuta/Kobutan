using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace PikaLib.File
{
    /// <summary>
    /// バイナリファイル。
    /// </summary>
    public static class BinaryFile
    {
        #region 静的メソッド
        /// <summary>
        /// 渡されたインスタンスの内容を指定されたバイナリファイルに書き込みます。
        /// </summary>
        /// <param name="filePath">書き込み先のファイルパス。</param>
        /// <param name="instance">書き込むインスタンス。</param>
        /// <exception cref="System.ArgumentException">不正なパラメータが渡された際に発生します。</exception>
        /// <exception cref="System.ArgumentNullException">nullがパラメータとして渡された際に発生します。</exception>
        /// <exception cref="System.NotSupportedException">ファイル以外のデバイスを参照している(NTFS 以外の環境の "con:"、"com1:"、"lpt1:" など)際に発生します。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">割り当てられていないドライブであるなど、指定されたパスが無効の際に発生します。</exception>
        /// <exception cref="System.Security.SecurityException">呼び出し元に、必要なアクセス許可がない際に発生します。</exception>
        /// <exception cref="System.UnauthorizedAccessException">ファイルまたはディレクトリが読み取り専用に設定されているなどでアクセスが許可されなかった際に発生します。</exception>
        /// <exception cref="System.IO.PathTooLongException">パスやファイル名が長すぎる際に発生します。</exception>
        /// <exception cref="System.Runtime.Serialization.SerializationException">シリアル化に失敗した際に発生します。</exception>
        public static void WriteBinaryFile(string filePath, object instance)
        {
            // 例外処理
            if (filePath == null)
                throw new ArgumentNullException("filePath");
            if (!(filePath is string))
                throw new ArgumentException(ExceptionMessages.ArgumentExceptionMessage1, "filePath");
            if (instance == null)
                throw new ArgumentNullException("instance");

            try
            {
                // ファイルを開き、バイナリファイルに保存
                using (FileStream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    WriteBinaryFile(stream, instance);
                }
            }
            catch (System.ArgumentException ex)
            {
                // 不正な引数
                throw new ArgumentException(ExceptionMessages.ArgumentExceptionMessage1, "filePath", ex);
            }
        }

        /// <summary>
        /// 渡されたインスタンスの内容を指定されたバイナリファイルに書き込みます。
        /// </summary>
        /// <param name="stream">書き込み先のストリーム。</param>
        /// <param name="instance">書き込むインスタンス。</param>
        /// <exception cref="System.ArgumentException">不正なパラメータが渡された際に発生します。</exception>
        /// <exception cref="System.ArgumentNullException">nullがパラメータとして渡された際に発生します。</exception>
        /// <exception cref="System.Runtime.Serialization.SerializationException">シリアル化に失敗した際に発生します。</exception>
        /// <exception cref="System.Security.SecurityException">呼び出し元に必要なアクセス許可がない際に発生します。</exception>
        public static void WriteBinaryFile(Stream stream, object instance)
        {
            // 例外処理
            if (stream == null)
                throw new ArgumentNullException("stream");
            if (!(stream is Stream))
                throw new ArgumentException(ExceptionMessages.ArgumentExceptionMessage1, "stream");
            if (instance == null)
                throw new ArgumentNullException("instance");

            try
            {
                // バイナリフォーマット
                BinaryFormatter bf = new BinaryFormatter();
                // シリアル化して書き込む
                bf.Serialize(stream, instance);
            }
            catch (ArgumentException ex)
            {
                // 不正な引数
                if (ex.ParamName == "serializationStream")
                {
                    throw new ArgumentException(ExceptionMessages.ArgumentExceptionMessage1, "stream", ex);
                }
                else
                {
                    throw new ArgumentException(ExceptionMessages.ArgumentExceptionMessage1, "instance", ex);
                }
            }
        }

        /// <summary>
        /// 指定されたバイナリファイルを読み込みます。
        /// </summary>
        /// <param name="filePath">読み込み先のファイルパス。</param>
        /// <returns>読み込まれたインスタンス。</returns>
        /// <exception cref="System.ArgumentException">不正なパラメータが渡された際に発生します。</exception>
        /// <exception cref="System.ArgumentNullException">nullがパラメータとして渡された際に発生します。</exception>
        /// <exception cref="System.NotSupportedException">ファイル以外のデバイスを参照している(NTFS 以外の環境の "con:"、"com1:"、"lpt1:" など)際に発生します。</exception>
        /// <exception cref="System.IO.FileNotFoundException">指定されたファイルがなかった際に発生します。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">割り当てられていないドライブであるなど、指定されたパスが無効の際に発生します。</exception>
        /// <exception cref="System.Security.SecurityException">呼び出し元に、必要なアクセス許可がない際に発生します。</exception>
        /// <exception cref="System.IO.PathTooLongException">パスやファイル名が長すぎる際に発生します。</exception>
        /// <exception cref="System.Runtime.Serialization.SerializationException">シリアル化に失敗した際に発生します。</exception>
        public static object ReadBinaryFile(string filePath)
        {
            // 例外処理
            if (filePath == null)
                throw new ArgumentNullException("filePath");
            if (!(filePath is string))
                throw new ArgumentException(ExceptionMessages.ArgumentExceptionMessage1, "filePath");

            try
            {
                // ファイルを開き、内容を読み込む
                object data = null;
                using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    data = ReadBinaryFile(stream);
                }
                // 結果を返す
                return data;
            }
            catch (ArgumentException ex)
            {
                // 不正な引数
                throw new ArgumentException(ExceptionMessages.ArgumentExceptionMessage1, "filePath", ex);
            }
        }

        /// <summary>
        /// 指定されたバイナリファイルを読み込みます。
        /// </summary>
        /// <param name="stream">読み込み先のストリーム。</param>
        /// <returns>読み込まれたインスタンス。</returns>
        /// <exception cref="System.ArgumentException">不正なパラメータが渡された際に発生します。</exception>
        /// <exception cref="System.ArgumentNullException">nullがパラメータとして渡された際に発生します。</exception>
        /// <exception cref="System.Runtime.Serialization.SerializationException">シリアル化に失敗した際に発生します。</exception>
        /// <exception cref="System.Security.SecurityException">呼び出し元に必要なアクセス許可がない際に発生します。</exception>
        public static object ReadBinaryFile(Stream stream)
        {
            // 例外処理
            if (stream == null)
                throw new ArgumentNullException("stream");
            if (!(stream is Stream))
                throw new ArgumentException(ExceptionMessages.ArgumentExceptionMessage1, "stream");

            try
            {
                // バイナリフォーマット
                BinaryFormatter bf = new BinaryFormatter();
                //読み込んで逆シリアル化する
                return bf.Deserialize(stream);
            }
            catch (ArgumentException ex)
            {
                // 不正な引数
                throw new ArgumentException(ExceptionMessages.ArgumentExceptionMessage1, "stream", ex);
            }
        }

        #endregion
    }
}
