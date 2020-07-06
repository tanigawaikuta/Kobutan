using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Communication;

namespace Commander
{
    /// <summary>
    /// コマンダ上で使われるオブジェクトを集める基地
    /// </summary>
    public class ObjectBase
    {
        #region メンバ変数
        /// <summary>
        /// オブジェクト辞書
        /// </summary>
        private Dictionary<string, dynamic> m_ObjectDictionary = new Dictionary<string, dynamic>();

        #endregion

        #region プロパティ
        /// <summary>
        /// 通信マネージャ
        /// </summary>
        public CommunicationManager CommandManager { get; protected set; }

        #endregion

        #region コンストラクタ
        /// <summary>
        /// コマンダ上で使われるオブジェクトを集める基地
        /// </summary>
        /// <param name="communicationManager">通信マネージャ</param>
        public ObjectBase(CommunicationManager communicationManager)
        {
            // パラメータの受け渡し
            CommandManager = communicationManager;

            // 辞書登録
            AddObject("CommunicationManager", CommandManager);
        }

        #endregion

        #region 公開メソッド
        /// <summary>
        /// オブジェクトの取得
        /// </summary>
        /// <param name="objectName">取得したいオブジェクト名</param>
        /// <returns>指定されたオブジェクト</returns>
        public dynamic GetObject(string objectName)
        {
            return m_ObjectDictionary[objectName];
        }

        /// <summary>
        /// オブジェクトの追加
        /// </summary>
        /// <param name="objectName">追加するオブジェクト名</param>
        /// <param name="obj">追加するオブジェクト</param>
        public void AddObject(string objectName, dynamic obj)
        {
            m_ObjectDictionary[objectName] = obj;
        }

        #endregion
    }
}
