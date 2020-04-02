using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SimpleSocketServerLibrary
{
    class InputMemoryBitStream
    {
        public BitArray buffer { get; private set; }
        public int bitHead { get; private set; }
        private int bitCapacity;

        public InputMemoryBitStream(BitArray buffer)
        {
            this.buffer = buffer;
            bitHead = 0;
            bitCapacity = buffer.Length;
        }

        #region ReadBits
        public void ReadBits<T>(out T data, int length) where T : struct
        {
            BitArray dataBits = new BitArray(length);
            for (int i = 0; i < length; i++)
                dataBits[i] = buffer[bitHead + i];
            byte[] dataBytes = new byte[length / 8 + ((length & 0x7) > 0 ? 1 : 0)];
            dataBits.CopyTo(dataBytes, 0);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(dataBytes);
            bitHead += length;

            T[] arr = new T[1];
            dataBytes.CopyTo(arr, 0);
            data = arr[0];
        }
        public void ReadBits(out string data)
        {
            ReadBits(out int length, sizeof(int) * 8);
            var arr = new char[length];
            for (int i = 0; i < length; i++)
                ReadBits(out arr[i], sizeof(char) * 8);
            data = new string(arr);
        }
        #endregion
    }
}
