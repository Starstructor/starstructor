using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DungeonEditor
{
    public class ByteListEqualityComparer : IEqualityComparer<List<byte>>
    {
        public bool Equals(List<byte> listOne, List<byte> listTwo)
        {
            return CompareByteArray(listOne.ToArray(), listTwo.ToArray());
        }

        // simple xor for each element
        public int GetHashCode(List<byte> list)
        {
            int hash = 0;

            foreach (byte value in list)
            {
                hash ^= value;
            }

            return hash;
        }

        // TODO try to rework this to work with Mono
        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern int memcmp(byte[] b1, byte[] b2, long count);

        // fast byte comparison using pinvoke
        static bool CompareByteArray(byte[] byte1, byte[] byte2)
        {
            return byte1.Length == byte2.Length && memcmp(byte1, byte2, byte1.Length) == 0;
        }
    }
}
