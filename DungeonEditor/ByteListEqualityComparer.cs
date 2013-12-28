/*Starstructor, the Starbound Toolet
Copyright (C) 2013-2014  Chris Stamford
Contact: cstamford@gmail.com

This program is free software; you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation; either version 2 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License along
with this program; if not, write to the Free Software Foundation, Inc.,
51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
*/

using System.Collections.Generic;
using System.Runtime.InteropServices;

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
        private static extern int memcmp(byte[] b1, byte[] b2, long count);

        // fast byte comparison using pinvoke
        private static bool CompareByteArray(byte[] byte1, byte[] byte2)
        {
            return byte1.Length == byte2.Length && memcmp(byte1, byte2, byte1.Length) == 0;
        }
    }
}