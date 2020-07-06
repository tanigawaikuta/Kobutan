using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Reflection;
using System.CodeDom.Compiler;
using Commander.Script;
using Communication;

namespace Commander
{
    /// <summary>
    /// コマンダインスタンス
    /// </summary>
    public class CommanderInstance
    {
        #region メンバ変数
        /// <summary>
        /// オブジェクトベース
        /// </summary>
        private ObjectBase m_ObjectBase;

        /// <summary>
        /// シリアルポートマネージャ
        /// </summary>
        private SerialPortManager m_SerialPortManager;

        /// <summary>
        /// スクリーン
        /// </summary>
        private Dictionary<string, UserControl> m_Screens = new Dictionary<string, UserControl>();

        /// <summary>
        /// スクリプトによって生成されたインスタンス
        /// </summary>
        private CommanderBase m_Commander;

        #endregion

        #region プロパティ
        /// <summary>
        /// 名前
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 接続中かどうか
        /// </summary>
        public bool IsConnect { get { return m_SerialPortManager.IsConnect; } }

        /// <summary>
        /// 送信スレッドのフラグ
        /// </summary>
        public bool SendThreadFlg { get; set; }

        /// <summary>
        /// 送信周期
        /// </summary>
        public uint SendCycle
        {
            get { return m_SerialPortManager.SendCycle; }
            set { m_SerialPortManager.SendCycle = value; }
        }

        #endregion

        #region コンストラクタ
        /// <summary>
        /// コマンダファイルからコマンダインスタンスを生成する
        /// </summary>
        /// <param name="file">コマンダファイル</param>
        /// <param name="objectBase"></param>
        /// <param name="serialPortManager"></param>
        public CommanderInstance(CommanderFile file, ObjectBase objectBase, SerialPortManager serialPortManager)
        {
            // 引数の受け渡し
            m_ObjectBase = objectBase;
            m_SerialPortManager = serialPortManager;
            // 初期化
            Initialize(file);
        }

        #endregion

        #region 公開メソッド
        /// <summary>
        /// 接続
        /// </summary>
        public void Connect()
        {
            m_SerialPortManager.Connect();
            OnConnected();
            if (SendThreadFlg)
            {
                m_SerialPortManager.StartSendThread();
            }
        }

        /// <summary>
        /// 切断
        /// </summary>
        public void Disconnect()
        {
            OnDisconnecting();
            m_SerialPortManager.Disconnect();
        }

        #endregion

        #region 委譲メソッド
        /// <summary>
        /// アクティベート時の処理
        /// </summary>
        public void OnActivated()
        {
            m_Commander.OnActivated();
        }

        /// <summary>
        /// ディアクティベート後の処理
        /// </summary>
        public void OnDeactivating()
        {
            m_Commander.OnDeactivating();
        }

        /// <summary>
        /// 接続時の処理
        /// </summary>
        public void OnConnected()
        {
            m_Commander.OnConnected();
        }

        /// <summary>
        /// 切断時の処理
        /// </summary>
        public void OnDisconnecting()
        {
            m_Commander.OnDisconnecting();
        }

        /// <summary>
        /// データが受信された時の処理
        /// </summary>
        public void OnDataReceived()
        {
            m_Commander.OnDataReceived();
        }

        /// <summary>
        /// 送信タイミングになった時の処理
        /// </summary>
        public void OnDataSending()
        {
            m_Commander.OnDataSending();
        }

        #endregion

        #region 非公開メソッド
        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="file">コマンダファイル</param>
        private void Initialize(CommanderFile file)
        {
            // スクリプトのロード
            LoadScript(file);
            // 通信イベントの追加
            InitializeCommunication(file);
            // 画面のロード
            LoadScreen(file);
        }

        /// <summary>
        /// スクリプトのロード
        /// </summary>
        /// <param name="file">コマンダファイル</param>
        private void LoadScript(CommanderFile file)
        {
            // スクリプトで定義したインスタンスを取得
            CompilerResults results = file.Script.Compile();
            Type type = results.CompiledAssembly.GetType(file.Script.ClassName);
            ConstructorInfo constructorInfo = type.GetConstructor(new Type[] { typeof(ObjectBase) });
            m_Commander = (CommanderBase)constructorInfo.Invoke(new object[] { m_ObjectBase });
        }

        /// <summary>
        /// 通信の初期化
        /// </summary>
        /// <param name="file">コマンダファイル</param>
        private void InitializeCommunication(CommanderFile file)
        {
            // 通信イベントの追加
            m_SerialPortManager.DataReceived += new SerialDataReceivedEventHandler((sender, e) =>
            {
                OnDataReceived();
            });
            m_SerialPortManager.DataSending += new EventHandler((sender, e) =>
            {
                OnDataSending();
            });
            // 送信スレッド関連
            SendThreadFlg = file.Setting.Communication.SendThreadEnable;
            m_SerialPortManager.SendCycle = file.Setting.Communication.SendCycle;
        }

        /// <summary>
        /// 画面のロード
        /// </summary>
        /// <param name="file">コマンダファイル</param>
        private void LoadScreen(CommanderFile file)
        {
        }

        #endregion
    }
}
