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

using System;
using System.IO;

namespace DungeonEditor
{
    public class Logger
    {
        private readonly StreamWriter m_file;

        public Logger(string path)
        {
            m_file = new StreamWriter(path, true) {AutoFlush = true};
        }

        ~Logger()
        {
            m_file.Close();
        }

        public void Write(string text)
        {
            if (m_file == null || text == null)
                return;

            m_file.WriteLine("[" + DateTime.Now.ToString("HH:mm:ss fff") + "] " + text);
        }
    }
}