using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using PikaLib.File;

namespace Communication
{
    /// <summary>
    /// プロトコル仕様
    /// </summary>
    public class ProtocolSpecification : SerializableXML
    {
        #region 各種情報
        /// <summary>各種情報</summary>
        public CInformation Information;
        /// <summary>各種情報</summary>
        public struct CInformation
        {
            /// <summary>名前</summary>
            public string Name;
            /// <summary>バージョン</summary>
            public string Version;
            /// <summary>説明</summary>
            public string Description;
        }

        #endregion

        #region シリアルポートの設定
        /// <summary>シリアルポートの設定</summary>
        public CSerialPortSetting SerialPortSetting;
        /// <summary>シリアルポートの設定</summary>
        public struct CSerialPortSetting
        {
            /// <summary>ボーレート</summary>
            public int BaudRate;
            /// <summary>パリティビット</summary>
            public Parity Parity;
            /// <summary>通信単位</summary>
            public int DataBits;
            /// <summary>ストップビット</summary>
            public StopBits StopBits;
        }

        #endregion

        #region プロトコル
        /// <summary>プロトコル</summary>
        public CProtocol Protocol;
        /// <summary>プロトコル</summary>
        public struct CProtocol
        {
            /// <summary>構造</summary>
            public StructureItem Structure;
            /// <summary>用意されているコマンド</summary>
            public StructureItem[] Commands;
            /// <summary>用意されているフィードバック</summary>
            public StructureItem[] Feedbacks;

            /// <summary>構造を構成する要素</summary>
            public struct StructureItem
            {
                /// <summary>名前</summary>
                public string Name;
                /// <summary>種類</summary>
                public StructureItemKind Kind;
                /// <summary>データ</summary>
                public byte Data1;
                /// <summary>データ</summary>
                public byte Data2;
                /// <summary>データ</summary>
                public byte Data3;
                /// <summary>子要素</summary>
                public StructureItem[] Children;
            }
            /// <summary>構造を構成する要素の種類</summary>
            public enum StructureItemKind
            {
                /// <summary>パッケージ</summary>
                Package,
                /// <summary>コマンドまたはフィードバックのパッケージ</summary>
                CommandOrFeedbackPackage,
                /// <summary>コマンドまたはフィードバック</summary>
                CommandOrFeedback,
                /// <summary>引数</summary>
                Argument,
                /// <summary>定数</summary>
                FixedNumber,
                /// <summary>バイトの長さ</summary>
                BytesLength,
                /// <summary>チェックサム</summary>
                Checksum,
            }
        }

        #endregion

        #region コンストラクタ
        /// <summary>
        /// プロトコル仕様
        /// </summary>
        public ProtocolSpecification()
        {
        }

        #endregion

        #region デフォルト設定
        /// <summary>
        /// デフォルト設定の適用
        /// </summary>
        public override void ApplyDefault()
        {
            /*
            // 各種情報
            Information.Name = "NewProtocolSpecification";
            Information.Version = "1.0";
            Information.Description = "";
            // シリアルポートの設定
            SerialPortSetting.BaudRate = 115200;
            SerialPortSetting.Parity = Parity.None;
            SerialPortSetting.DataBits = 8;
            SerialPortSetting.StopBits = StopBits.One;
            // プロトコル
             */

            // 各種情報
            Information.Name = "Kobuki";
            Information.Version = "1.0";
            Information.Description = @"Kobukiとの通信のためのプロトコル。";
            // シリアルポートの設定
            SerialPortSetting.BaudRate = 115200;
            SerialPortSetting.Parity = Parity.None;
            SerialPortSetting.DataBits = 8;
            SerialPortSetting.StopBits = StopBits.One;
            // プロトコル
            Protocol.Structure.Name = "Structure";
            Protocol.Structure.Kind = CProtocol.StructureItemKind.Package;
            Protocol.Structure.Data1 = 5;     // 要素数
            Protocol.Structure.Children = new CProtocol.StructureItem[]
            {
                new CProtocol.StructureItem
                {
                    Name = "Header0" ,
                    Kind = CProtocol.StructureItemKind.FixedNumber,
                    Data1 = 0xAA,         // 定数
                    Children = null,
                },
                new CProtocol.StructureItem
                {
                    Name = "Header1" ,
                    Kind = CProtocol.StructureItemKind.FixedNumber,
                    Data1 = 0x55,         // 定数
                    Children = null,
                },
                new CProtocol.StructureItem
                {
                    Name = "Length" ,
                    Kind = CProtocol.StructureItemKind.BytesLength,
                    Data1 = 1,      // これ自体のバイトサイズ(リトルエンディアン, ビッグは先頭ビットを1)
                    Data2 = 3,      // 開始位置
                    Data3 = 3,      // 終了位置
                    Children = null,
                },
                new CProtocol.StructureItem
                {
                    Name = "Payload" ,
                    Kind = CProtocol.StructureItemKind.CommandOrFeedbackPackage,
                    Data1 = 0x01,         // ID
                    Children = null,
                },
                new CProtocol.StructureItem
                {
                    Name = "Checksum" ,
                    Kind = CProtocol.StructureItemKind.BytesLength,
                    Data1 = 0x21,      // 方式(加算,減算,Xor), これ自体のバイトサイズ
                    Data2 = 2,      // 開始位置
                    Data3 = 3,      // 終了位置
                    Children = null,
                },
            };
            Protocol.Commands = new CProtocol.StructureItem[]
            {
                new CProtocol.StructureItem
                {
                    Name = "Base Control" ,
                    Kind = CProtocol.StructureItemKind.CommandOrFeedback,
                    Data1 = 0x01,           // ID
                    Data2 = 0x04,           // 要素数
                    Children = new CProtocol.StructureItem[]
                    {
                        new CProtocol.StructureItem
                        {
                            Name = "Identifier",
                            Kind = CProtocol.StructureItemKind.FixedNumber,
                            Data1 = 0x01,         // 定数
                            Children = null,
                        },
                        new CProtocol.StructureItem
                        {
                            Name = "Size",
                            Kind = CProtocol.StructureItemKind.FixedNumber,
                            Data1 = 4,         // 定数
                            Children = null,
                        },
                        new CProtocol.StructureItem
                        {
                            Name = "Speed",
                            Kind = CProtocol.StructureItemKind.Argument,
                            Data1 = 0x02,         // (上位ビット:符号無し, リトルエンディアン 下位ビット:サイズ)
                            Children = null,
                        },
                        new CProtocol.StructureItem
                        {
                            Name = "Radius",
                            Kind = CProtocol.StructureItemKind.Argument,
                            Data1 = 0x02,         // (上位ビット:符号無し, リトルエンディアン 下位ビット:サイズ)
                            Children = null,
                        },
                    },
                },
            };
        }

        #endregion
    }
}
