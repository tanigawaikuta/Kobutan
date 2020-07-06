using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Commander.Script
{
    /// <summary>
    /// 各コマンダのスクリプトから継承されるクラス
    /// </summary>
    public abstract class CommanderBase
    {
        #region プロパティ
        /// <summary>
        /// オブジェクトベース
        /// </summary>
        protected ObjectBase ObjectBase { get; set; }

        #endregion

        #region コンストラクタ
        /// <summary>
        /// 各コマンダのスクリプトから継承されるクラス
        /// </summary>
        /// <param name="objectBase">オブジェクトベース</param>
        public CommanderBase(ObjectBase objectBase)
        {
            ObjectBase = objectBase;
        }

        #endregion

        #region 抽象メソッド
        /// <summary>アクティベート時の処理</summary>
        public abstract void OnActivated();
        /// <summary>ディアクティベート時の処理</summary>
        public abstract void OnDeactivating();
        /// <summary>接続時の処理</summary>
        public abstract void OnConnected();
        /// <summary>切断時の処理</summary>
        public abstract void OnDisconnecting();
        /// <summary>送信タイミングになった時の処理</summary>
        public abstract void OnDataSending();
        /// <summary>データが受信された時の処理</summary>
        public abstract void OnDataReceived();

        #endregion
    }
}
