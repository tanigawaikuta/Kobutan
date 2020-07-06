using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Kobutan
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool createdNew;
            //Mutexクラスの作成
            //"MyName"の部分を適当な文字列に変える
            System.Threading.Mutex mutex =
                new System.Threading.Mutex(true, "Kobutan", out createdNew);
            if (createdNew == false)
            {
                //ミューテックスの初期所有権が付与されなかったときは
                //すでに起動していると判断して終了
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

            //ミューテックスを解放する
            mutex.ReleaseMutex();

        }
    }
}
