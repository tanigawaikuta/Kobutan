using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace PikaLib.File
{
    /// <summary>
    /// シリアライズ化対応のXML。
    /// XMLに対する操作はこのクラスを継承し、
    /// 読み込み・保存を行いたいメンバを追加することで可能となります。
    /// </summary>
    /// <remarks>
    /// このクラスを継承するクラスは必ずpublic にして、[Serializable]属性を付けなければなりません。
    /// また、XMLに保存したいメンバはpublic にしておく必要があります。
    /// 追加するメンバはシリアライズ可能なデータである必要があります。
    /// 例えば、System.Drawing.Color は直接シリアライズには対応していないので、
    /// 文字列に変換し、読み込む際は文字列から復元する必要があります。
    /// </remarks>
    /// <example> C#における使用例
    /// <code>
    /// // 必ずpublic にして、[Serializable]属性を付ける
    /// [Serializable]
    /// public class Config : PikaLib.File.SerializableXML
    /// {
    ///     // 対象となるメンバ
    ///     public string StringData;
    ///     public int IntData;
    ///     public byte[] ByteDatas = new byte[] {0, 1, 2, 3};
    ///     // 対象とならないメンバ。[XmlIgnoreAttribute]を付ける
    ///     [XmlIgnoreAttribute]
    ///     private int PrivateData;
    ///     
    ///     // いくつかの項目をまとめる (座標の例)
    ///     public CPos Pos;
    ///     public struct CPos
    ///     {
    ///         public int x;
    ///         public int y;
    ///     }
    ///     
    ///     // デフォルト設定の適用
    ///     public override void ApplyDefault() { デフォルト値の代入処理 }
    /// }
    /// 
    /// class Example
    /// {
    ///     private Config m_Config;
    /// 
    ///     public LoadConfig()
    ///     {
    ///         m_Config = (Config)PikaLib.File.SerializableXML.ReadXMLFile("Config.xml", typeof(Config));
    ///     }
    ///     public SaveConfig()
    ///     {
    ///         m_Config.StringData = 新しい値;
    ///         m_Config.IntData = 新しい値;
    ///         …
    ///         m_Config.Save();
    ///     }
    /// }
    /// </code>
    /// </example>
    [Serializable]
    public abstract class SerializableXML
    {
        #region メンバ変数
        /// <summary>使用するテキスト エンコーディング。</summary>
        [XmlIgnoreAttribute]
        private Encoding m_Encoding = Encoding.UTF8;

        /// <summary>要素にインデントを設定するかどうかを示す値。</summary>
        [XmlIgnoreAttribute]
        private bool m_Indent = true;

        /// <summary>インデント処理を行うときに使用する文字列。</summary>
        [XmlIgnoreAttribute]
        private string m_IndentChars = "  ";

        #endregion

        #region プロパティ
        /// <summary>
        /// ファイルパスを取得または設定します。
        /// Save() メソッド呼び出し時に保存先として使用されます。
        /// </summary>
        [XmlIgnoreAttribute]
        public string FilePath { get; set; }

        /// <summary>
        /// 使用するテキスト エンコーディングを取得または設定します。
        /// </summary>
        [XmlIgnoreAttribute]
        public Encoding Encoding { get { return m_Encoding; } set { m_Encoding = value; } }

        /// <summary>
        /// 要素にインデントを設定するかどうかを示す値を取得または設定します。
        /// </summary>
        [XmlIgnoreAttribute]
        public bool Indent { get { return m_Indent; } set { m_Indent = value; } }

        /// <summary>
        /// インデント処理を行うときに使用する文字列を取得または設定します。
        /// この設定は、Indentが true に設定されている場合に使用されます。
        /// </summary>
        [XmlIgnoreAttribute]
        public string IndentChars { get { return m_IndentChars; } set { m_IndentChars = value; } }

        #endregion

        #region コンストラクタ
        /// <summary>
        /// PikaLib.File.SerializableXML クラスの新しいインスタンスを初期化します。
        /// </summary>
        public SerializableXML()
        {
        }

        #endregion

        #region 公開メソッド
        /// <summary>
        /// FilePathプロパティを用いて、WriteXMLFile()メソッドを実行し、
        /// 現在のメンバをXMLファイルに保存します。
        /// </summary>
        /// <exception cref="System.ArgumentException">不正なパラメータが渡された際に発生します。</exception>
        /// <exception cref="System.ArgumentNullException">nullがパラメータとして渡された際に発生します。</exception>
        /// <exception cref="System.NotSupportedException">ファイル以外のデバイスを参照している(NTFS 以外の環境の "con:"、"com1:"、"lpt1:" など)際に発生します。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">割り当てられていないドライブであるなど、指定されたパスが無効の際に発生します。</exception>
        /// <exception cref="System.Security.SecurityException">呼び出し元に、必要なアクセス許可がない際に発生します。</exception>
        /// <exception cref="System.UnauthorizedAccessException">ファイルまたはディレクトリが読み取り専用に設定されているなどでアクセスが許可されなかった際に発生します。</exception>
        /// <exception cref="System.IO.PathTooLongException">パスやファイル名が長すぎる際に発生します。</exception>
        /// <exception cref="System.InvalidOperationException">シリアル化に失敗した際に発生します。</exception>
        public void Save()
        {
            // XMLファイルに書き込み
            SerializableXML.WriteXMLFile(this.FilePath, this);
        }

        /// <summary>
        /// 現在のオブジェクトのシリアル化により得られたストリームを取得します。
        /// </summary>
        /// <returns>シリアル化により得られたストリーム。</returns>
        /// <exception cref="System.InvalidOperationException">シリアル化に失敗した際に発生します。</exception>
        public Stream ToStream()
        {
            // メモリストリームの生成
            Stream stream = new MemoryStream();
            // シリアル化
            XmlSerializer serializer = new XmlSerializer(this.GetType());   // XmlSerializerオブジェクトを作成
            serializer.Serialize(stream, this);                             // シリアル化し、メモリストリームに保存する
            stream.Position = 0;                                            // 位置を最初に戻す
            // 結果を返す
            return stream;
        }

        #endregion

        #region オーバーライド
        /// <summary>
        /// XMLファイルに変換された際の文字列を取得します。
        /// </summary>
        /// <returns>XMLファイルに変換された際の文字列。</returns>
        /// <exception cref="System.InvalidOperationException">シリアル化に失敗した際に発生します。</exception>
        /// <exception cref="System.Text.DecoderFallbackException">フォールバックにより発生します。</exception>
        public override string ToString()
        {
            // 結果格納用
            string result;
            // シリアル化後のストリームから文字列を生成
            using (Stream stream = ToStream())
            {
                byte[] buf = new byte[stream.Length];
                stream.Read(buf, 0, (int)stream.Length);
                result = Encoding.UTF8.GetString(buf);
            }
            return result;
        }

        #endregion

        #region 静的メソッド
        /// <summary>
        /// 渡されたインスタンスの内容を指定されたXMLファイルに書き込みます。
        /// </summary>
        /// <param name="filePath">書き込み先ファイルのパス。</param>
        /// <param name="instance">書き込むインスタンス。</param>
        /// <exception cref="System.ArgumentException">不正なパラメータが渡された際に発生します。</exception>
        /// <exception cref="System.ArgumentNullException">nullがパラメータとして渡された際に発生します。</exception>
        /// <exception cref="System.NotSupportedException">ファイル以外のデバイスを参照している(NTFS 以外の環境の "con:"、"com1:"、"lpt1:" など)際に発生します。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">割り当てられていないドライブであるなど、指定されたパスが無効の際に発生します。</exception>
        /// <exception cref="System.Security.SecurityException">呼び出し元に、必要なアクセス許可がない際に発生します。</exception>
        /// <exception cref="System.UnauthorizedAccessException">ファイルまたはディレクトリが読み取り専用に設定されているなどでアクセスが許可されなかった際に発生します。</exception>
        /// <exception cref="System.IO.PathTooLongException">パスやファイル名が長すぎる際に発生します。</exception>
        /// <exception cref="System.InvalidOperationException">シリアル化に失敗した際に発生します。</exception>
        public static void WriteXMLFile(string filePath, SerializableXML instance)
        {
            // 例外処理
            if (filePath == null)
                throw new ArgumentNullException("filePath");
            if (!(filePath is string))
                throw new ArgumentException(ExceptionMessages.ArgumentExceptionMessage1, "filePath");
            if (instance == null)
                throw new ArgumentNullException("instance");
            if (!(instance is SerializableXML))
                throw new ArgumentException(ExceptionMessages.ArgumentExceptionMessage1, "instance");

            try
            {
                // ファイルを開き、XMLファイルに保存
                using (FileStream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    WriteXMLFile(stream, instance);
                }
            }
            catch (ArgumentException ex)
            {
                // 不正な引数
                throw new ArgumentException(ExceptionMessages.ArgumentExceptionMessage1, "filePath", ex);
            }
        }

        /// <summary>
        /// 渡されたインスタンスの内容を指定されたXMLファイルに書き込みます。
        /// </summary>
        /// <param name="stream">書き込み先のストリーム。</param>
        /// <param name="instance">書き込むインスタンス。</param>
        /// <exception cref="System.ArgumentException">不正なパラメータが渡された際に発生します。</exception>
        /// <exception cref="System.ArgumentNullException">nullがパラメータとして渡された際に発生します。</exception>
        /// <exception cref="System.InvalidOperationException">シリアル化に失敗した際に発生します。</exception>
        /// <exception cref="System.Security.SecurityException">呼び出し元に必要なアクセス許可がない際に発生します。</exception>
        public static void WriteXMLFile(Stream stream, SerializableXML instance)
        {
            // 例外処理
            if (stream == null)
                throw new ArgumentNullException("stream");
            if (!(stream is Stream))
                throw new ArgumentException(ExceptionMessages.ArgumentExceptionMessage1, "stream");
            if (instance == null)
                throw new ArgumentNullException("instance");
            if (!(instance is SerializableXML))
                throw new ArgumentException(ExceptionMessages.ArgumentExceptionMessage1, "instance");

            try
            {
                // 設定オブジェクトを作成
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Encoding = instance.Encoding;
                settings.Indent = instance.Indent;
                settings.IndentChars = instance.IndentChars;
                // XmlWriterを作成
                using (XmlWriter writer = XmlWriter.Create(stream, settings))
                {
                    // シリアル化し、XMLファイルに保存する
                    XmlSerializer serializer = new XmlSerializer(instance.GetType());
                    serializer.Serialize(writer, instance);
                }
            }
            catch (ArgumentException ex)
            {
                // 不正な引数
                if (ex.ParamName == "stream")
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
        /// 指定されたXMLファイルを読み込みます。
        /// </summary>
        /// <param name="filePath">読み込み先のファイルパス。</param>
        /// <param name="type">読み込むインスタンスの型。</param>
        /// <param name="enableDefaultFlg">デフォルト有効フラグ (trueの場合は読み込み失敗時にデフォルト設定を返します)。</param>
        /// <returns>読み込みにより生成されたインスタンス。</returns>
        /// <exception cref="System.ArgumentException">不正なパラメータが渡された際に発生します。</exception>
        /// <exception cref="System.ArgumentNullException">nullがパラメータとして渡された際に発生します。</exception>
        /// <exception cref="System.NotSupportedException">ファイル以外のデバイスを参照している(NTFS 以外の環境の "con:"、"com1:"、"lpt1:" など)際に発生します。</exception>
        /// <exception cref="System.IO.FileNotFoundException">指定されたファイルがなかった際に発生します。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">割り当てられていないドライブであるなど、指定されたパスが無効の際に発生します。</exception>
        /// <exception cref="System.Security.SecurityException">呼び出し元に、必要なアクセス許可がない際に発生します。</exception>
        /// <exception cref="System.IO.PathTooLongException">パスやファイル名が長すぎる際に発生します。</exception>
        /// <exception cref="System.InvalidOperationException">シリアル化に失敗した際に発生します。</exception>
        public static SerializableXML ReadXMLFile(string filePath, Type type, bool enableDefaultFlg = true)
        {
            try
            {
                // ファイルを開き、内容を読み込む
                SerializableXML instance = null;
                try
                {
                    // 例外処理
                    if (filePath == null)
                        throw new ArgumentNullException("filePath");
                    if (!(filePath is string))
                        throw new ArgumentException(ExceptionMessages.ArgumentExceptionMessage1, "filePath");

                    // ファイルストリームを作成
                    using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        instance = ReadXMLFile(stream, type, filePath, enableDefaultFlg);
                    }
                }
                catch (Exception)
                {
                    // デフォルト有効フラグが無効なら、再スロー
                    if (!enableDefaultFlg) throw;
                    // 失敗した場合、デフォルトの内容を適用
                    instance = (SerializableXML)Activator.CreateInstance(type);
                    instance.ApplyDefault();
                }
                // ファイルパスの設定
                instance.FilePath = filePath;

                // 結果を返す
                return instance;
            }
            catch (ArgumentException ex)
            {
                // 不正な引数
                if (ex.ParamName == "type")
                    throw new ArgumentException(ExceptionMessages.ArgumentExceptionMessage1, "type", ex);
                else
                    throw new ArgumentException(ExceptionMessages.ArgumentExceptionMessage1, "filePath", ex);
            }
            catch (TypeLoadException ex)
            {
                // 型読み込みエラー
                throw new ArgumentException(ExceptionMessages.ArgumentExceptionMessage1, "type", ex);
            }
        }

        /// <summary>
        /// 指定されたXMLファイルを読み込みます。
        /// </summary>
        /// <param name="stream">読み込み先のストリーム。</param>
        /// <param name="type">読み込むインスタンスの型。</param>
        /// <param name="filePath">ファイルパス。Save() メソッドなどのために使われます。</param>
        /// <param name="enableDefaultFlg">デフォルト有効フラグ (trueの場合は読み込み失敗時にデフォルト設定を返します)。</param>
        /// <returns>読み込みにより生成されたインスタンス。</returns>
        /// <exception cref="System.ArgumentException">不正なパラメータが渡された際に発生します。</exception>
        /// <exception cref="System.ArgumentNullException">nullがパラメータとして渡された際に発生します。</exception>
        /// <exception cref="System.InvalidOperationException">シリアル化に失敗した際に発生します。</exception>
        /// <exception cref="System.Security.SecurityException">呼び出し元に必要なアクセス許可がない際に発生します。</exception>
        public static SerializableXML ReadXMLFile(Stream stream, Type type, string filePath = "xmlfile.xml", bool enableDefaultFlg = true)
        {
            try
            {
                // ファイルを開き、内容を読み込む
                SerializableXML instance = null;
                try
                {
                    // 例外処理
                    if (stream == null)
                        throw new ArgumentNullException("stream");
                    if (!(stream is Stream))
                        throw new ArgumentException(ExceptionMessages.ArgumentExceptionMessage1, "stream");
                    if (type == null)
                        throw new ArgumentNullException("type");
                    if (!(type is Type))
                        throw new ArgumentException(ExceptionMessages.ArgumentExceptionMessage1, "type");

                    // XmlSerializerオブジェクトを作成
                    XmlSerializer serializer = new XmlSerializer(type);
                    // XMLファイルから読み込み、逆シリアル化する
                    instance = (SerializableXML)serializer.Deserialize(stream);
                }
                catch (Exception)
                {
                    // デフォルト有効フラグが無効なら、再スロー
                    if (!enableDefaultFlg) throw;
                    // 失敗した場合、デフォルトの内容を適用
                    instance = (SerializableXML)Activator.CreateInstance(type);
                    instance.ApplyDefault();
                }
                // ファイル名の設定
                instance.FilePath = filePath;

                // 結果を返す
                return instance;
            }
            catch (ArgumentException ex)
            {
                // 不正な引数
                if (ex.ParamName == "type")
                    throw new ArgumentException(ExceptionMessages.ArgumentExceptionMessage1, "type", ex);
                else
                    throw new ArgumentException(ExceptionMessages.ArgumentExceptionMessage1, "stream", ex);
            }
            catch (TypeLoadException ex)
            {
                // 型読み込みエラー
                throw new ArgumentException(ExceptionMessages.ArgumentExceptionMessage1, "type", ex);
            }
        }

        #endregion

        #region 抽象メソッド
        /// <summary>
        /// デフォルトの内容を適用します。
        /// </summary>
        /// <remarks>
        /// このメソッドは継承先でオーバーライドする必要があります。
        /// 追加するべき処理は、各メンバのデフォルトの値を代入する処理です。
        /// </remarks>
        public abstract void ApplyDefault();

        #endregion
    }
}
