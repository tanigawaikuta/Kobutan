using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace Communication
{
    /// <summary>
    /// 送信スレッド
    /// </summary>
    internal class SendThread
    {
        #region メンバ変数
        /// <summary>
        /// スレッド
        /// </summary>
        private Thread m_Thread;

        /// <summary>
        /// スレッドが有効かどうかの真偽値
        /// </summary>
        private bool m_ThreadEnable = false;

        /// <summary>
        /// ストップウォッチ
        /// </summary>
        private Stopwatch m_Stopwatch = new Stopwatch();

        /// <summary>
        /// 前回の時間
        /// </summary>
        private long m_LastTime = 0;

        /// <summary>
        /// スレッドのアクション
        /// </summary>
        private Action m_Action;

        /// <summary>
        /// すでに破棄済みかどうかを表すフラグ。
        /// </summary>
        private bool m_Disposed = false;

        #endregion

        #region プロパティ
        /// <summary>
        /// 送信スレッドの送信周期(ミリ秒単位)
        /// </summary>
        public long SendCycle { get; set; }

        #endregion

        #region コンストラクタ
        /// <summary>
        /// 送信スレッド
        /// </summary>
        /// <param name="action"></param>
        /// <param name="sendCycle">送信サイクル</param>
        public SendThread(Action action, long sendCycle)
        {
            m_Action = action;
            SendCycle = sendCycle;
        }

        #endregion

        #region 公開メソッド
        /// <summary>
        /// スタート
        /// </summary>
        public void Start()
        {
            if (!m_ThreadEnable)
            {
                m_Thread = new Thread(new ThreadStart(ThreadAction));
                m_Thread.IsBackground = true;
                m_Thread.Priority = ThreadPriority.Normal;
                m_ThreadEnable = true;
                m_Thread.Start();
                m_Stopwatch.Start();
            }
        }

        /// <summary>
        /// ストップ
        /// </summary>
        public void Stop()
        {
            if (m_ThreadEnable)
            {
                m_Stopwatch.Stop();
                m_Stopwatch.Reset();
                m_Thread.Abort();
                m_ThreadEnable = false;
                m_Thread = null;
            }
        }

        #endregion

        #region イベントハンドラ
        private void ThreadAction()
        {
            while (m_ThreadEnable)
            {
                long offset = m_Stopwatch.ElapsedMilliseconds - m_LastTime;
                // オーバーフロー対策
                if (offset < 0)
                {
                    offset = long.MaxValue + offset;
                    return;
                }

                if (offset >= SendCycle)
                {
                    m_Action();
                    m_LastTime = m_Stopwatch.ElapsedMilliseconds;
                }
            }
        }

        #endregion
    }
}
