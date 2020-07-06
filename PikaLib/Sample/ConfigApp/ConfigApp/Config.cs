using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConfigApp
{
    /// <summary>
    /// コンフィグクラス
    /// </summary>
    /// <remarks>
    /// publicなメンバを追加することで保存する項目を増やしていく
    /// また、このクラス自体もpublicにしておく必要がある
    /// [Serializable]属性も付けておこう
    /// </remarks>
    public class Config : PikaLib.File.SerializableXML
    {
        #region 設定 : Screen1
        /// <summary>Screen1の設定</summary>
        public CScreen1 Screen1;
        public struct CScreen1
        {
            /// <summary>Screen1_1の設定</summary>
            public CScreen1_1 Screen1_1;
            public struct CScreen1_1
            {
                public bool CheckBox1;
                public bool CheckBox2;
                public bool CheckBox3;
                public bool CheckBox4;
                public bool CheckBox5;
                public bool CheckBox6;
                public bool CheckBox7;
                public bool CheckBox8;
                public int ComboBoxIndex;
                public string Text1;
                public string Text2;
                public string[] ListTexts;
            }

            /// <summary>Screen1_2の設定</summary>
            public CScreen1_2 Screen1_2;
            public struct CScreen1_2
            {
                public DateTime DateTime;
                public string FilePath;
                public string Color;
                public string Font;
                public int TrackBarNumber;
                public int RadioButtonNumber;
                public bool CheckListBoxItem0;
                public bool CheckListBoxItem1;
                public bool CheckListBoxItem2;
                public bool CheckListBoxItem3;
            }
        }

        #endregion

        #region 設定 : Screen2
        /// <summary>Screen2の設定</summary>
        public CScreen2 Screen2;
        public struct CScreen2
        {
            public CListItem[] ListItems;
            public struct CListItem
            {
                public int Nomber;
                public string Text;
                public bool Flg;
                public CListItem(int num, string text, bool flg)
                {
                    Nomber = num;
                    Text = text;
                    Flg = flg;
                }
                public override string ToString()
                {
                    return (Nomber + " : " + Text + " [" + Flg + "]");
                }
            }
        }

        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンフィグクラス
        /// </summary>
        public Config()
        {
        }

        #endregion

        #region デフォルト設定
        /// <summary>
        /// デフォルト設定の適用
        /// </summary>
        public override void ApplyDefault()
        {
            //==================
            // Screen1の設定
            //==================
            // Screen1_1の設定
            Screen1.Screen1_1.CheckBox1 = true;
            Screen1.Screen1_1.CheckBox2 = false;
            Screen1.Screen1_1.CheckBox3 = true;
            Screen1.Screen1_1.CheckBox4 = false;
            Screen1.Screen1_1.CheckBox5 = true;
            Screen1.Screen1_1.CheckBox6 = true;
            Screen1.Screen1_1.CheckBox7 = false;
            Screen1.Screen1_1.CheckBox8 = false;
            Screen1.Screen1_1.ComboBoxIndex = 0;
            Screen1.Screen1_1.ListTexts = new string[]{"abc", "def", "ghi"};
            Screen1.Screen1_1.Text1 = "text1";
            Screen1.Screen1_1.Text2 = "text2";
            // Screen1_2の設定
            Screen1.Screen1_2.DateTime = DateTime.Today;
            Screen1.Screen1_2.FilePath = @"C:\Users\Ikuta\MyProgram\Projects\PikaLib\readme.txt";
            Screen1.Screen1_2.Color = @"Blue";
            Screen1.Screen1_2.Font = @"ＭＳ 明朝, 11.25pt, style=Italic, Underline";
            Screen1.Screen1_2.TrackBarNumber = 0;
            Screen1.Screen1_2.RadioButtonNumber = 1;
            Screen1.Screen1_2.CheckListBoxItem0 = true;
            Screen1.Screen1_2.CheckListBoxItem1 = true;
            Screen1.Screen1_2.CheckListBoxItem2 = false;
            Screen1.Screen1_2.CheckListBoxItem3 = false;
            //==================
            // Screen2の設定
            //==================
            Screen2.ListItems = new CScreen2.CListItem[] 
            {
                new CScreen2.CListItem(5, "test", true),
                new CScreen2.CListItem(1, "てすと", false),
                new CScreen2.CListItem(9, "テスト", true),
                new CScreen2.CListItem(0, "試験", false),
                new CScreen2.CListItem(99, "试验", true),
                new CScreen2.CListItem(21, "테스트", false),
                new CScreen2.CListItem(64, "Épreuve", true),
                new CScreen2.CListItem(86, "Die Prüfung", false),
                new CScreen2.CListItem(1024, "Prova", true),
                new CScreen2.CListItem(777, "Prueba", false),
                new CScreen2.CListItem(2, "Teste", true),
                new CScreen2.CListItem(256, "Испытание", false)
            };
        }

        #endregion
    }
}
