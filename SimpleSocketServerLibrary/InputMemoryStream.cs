using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSocketServerLibrary
{
    public class InputMemoryStream
    {
        public byte[] buffer { get; private set; }
        public int head { get; private set; }
        private int capacity;
        public int RemainingDataSize { get { return capacity - head; } }

        public InputMemoryStream(byte[] buffer)
        {
            this.buffer = buffer;
            head = 0;
            capacity = buffer.Length;
        }

        #region Read
        public void Read<T>(out T data) where T : struct
        {
            if (typeof(T) == typeof(bool))
            {
                data = (T)(object)BitConverter.ToBoolean(buffer, head);
                head += sizeof(bool);
            }
            else if (typeof(T) == typeof(char))
            {
                data = (T)(object)BitConverter.ToChar(buffer, head);
                head += sizeof(char);
            }
            else if (typeof(T) == typeof(byte))
            {
                data = (T)(object)buffer[head];
                head += sizeof(byte);
            }
            else if (typeof(T) == typeof(sbyte))
            {
                data = (T)(object)buffer[head];
                head += sizeof(sbyte);
            }
            else if (typeof(T) == typeof(short))
            {
                data = (T)(object)BitConverter.ToInt16(buffer, head);
                head += sizeof(short);
            }
            else if (typeof(T) == typeof(ushort))
            {
                data = (T)(object)BitConverter.ToUInt16(buffer, head);
                head += sizeof(ushort);
            }
            else if (typeof(T) == typeof(int))
            {
                data = (T)(object)BitConverter.ToInt32(buffer, head);
                head += sizeof(int);
            }
            else if (typeof(T) == typeof(uint))
            {
                data = (T)(object)BitConverter.ToUInt32(buffer, head);
                head += sizeof(uint);
            }
            else if (typeof(T) == typeof(long))
            {
                data = (T)(object)BitConverter.ToInt64(buffer, head);
                head += sizeof(long);
            }
            else if (typeof(T) == typeof(ulong))
            {
                data = (T)(object)BitConverter.ToUInt64(buffer, head);
                head += sizeof(ulong);
            }
            else if (typeof(T) == typeof(float))
            {
                data = (T)(object)BitConverter.ToSingle(buffer, head);
                head += sizeof(float);
            }
            else if (typeof(T) == typeof(double))
            {
                data = (T)(object)BitConverter.ToDouble(buffer, head);
                head += sizeof(double);
            }
            else
                throw new ArgumentException("OutputMemoryStream.Write parameter can be only primitive type except decimal");
        }
        public void Read(out string data)
        {
            Read(out int length);
            char[] arr = new char[length];
            for (int i = 0; i < length; i++)
                Read(out arr[i]);
            data = new string(arr);
        }
        #endregion
    }
}
