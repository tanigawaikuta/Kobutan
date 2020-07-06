using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Communication
{
    //==========================================
    // プロトコルの構成要素
    //   そのうちシリアライズ化に対応させる予定
    //==========================================

    /// <summary>
    /// 構成アイテム
    /// </summary>
    internal abstract class StructureItem
    {
        public StructureItem()
        {
        }

        public abstract void WriteStream(MemoryStream stream);
        public abstract int GetByteSize();
    }

    /// <summary>
    /// パッケージ
    /// </summary>
    internal class Package : StructureItem
    {
        private StructureItem[] m_Array;
        public StructureItem this[int index]
        {
            get { return m_Array[index]; }
            set { m_Array[index] = value; }
        }

        public Package()
        {
        }
        public Package(int size)
        {
            m_Array = new StructureItem[size];
        }

        public override void WriteStream(MemoryStream stream)
        {
            foreach (StructureItem item in m_Array)
            {
                item.WriteStream(stream);
            }
        }
        public override int GetByteSize()
        {
            int sum = 0;
            foreach (StructureItem item in m_Array)
            {
                sum += item.GetByteSize();
            }
            return sum;
        }
    }

    /// <summary>
    /// コマンドまたはフィードバックのパッケージ
    /// </summary>
    internal class CommandOrFeedbackPackage : StructureItem
    {
        private byte[] m_Data = new byte[1024];
        private int m_Index;
        public byte this[int index]
        {
            get { return m_Data[index]; }
            set { m_Data[index] = value; }
        }

        public CommandOrFeedbackPackage()
        {
        }

        public void Add(CommandOrFeedback item)
        {
        }

        public void Clear()
        {
            m_Index = 0;
        }

        public override void WriteStream(MemoryStream stream)
        {
        }
        public override int GetByteSize()
        {
            return 0;
        }
    }

    internal class CommandOrFeedback : Package
    {
        public CommandOrFeedback(int size)
            : base(size)
        {
        }
    }

    internal class Argument : StructureItem
    {
        public override void WriteStream(MemoryStream stream)
        {
            throw new NotImplementedException();
        }
        public override int GetByteSize()
        {
            throw new NotImplementedException();
        }
    }

    internal class FixedNumber : StructureItem
    {
        private byte m_Data;
        public FixedNumber(byte data)
        {
            m_Data = data;
        }

        public override void WriteStream(MemoryStream stream)
        {
            stream.WriteByte(m_Data);
        }
        public override int GetByteSize()
        {
            return 1;
        }
    }

    internal class BytesLength : StructureItem
    {
        public override void WriteStream(MemoryStream stream)
        {
            throw new NotImplementedException();
        }
        public override int GetByteSize()
        {
            throw new NotImplementedException();
        }
    }

    internal class Checksum : StructureItem
    {
        public override void WriteStream(MemoryStream stream)
        {
            throw new NotImplementedException();
        }
        public override int GetByteSize()
        {
            throw new NotImplementedException();
        }
    }
}
