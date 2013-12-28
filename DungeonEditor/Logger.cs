using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonEditor
{
    public class Logger
    {
        private string m_path;
        StreamWriter m_file;

        public Logger(string path)
        {
            m_path = path;
            m_file = new StreamWriter(m_path, true);
            m_file.AutoFlush = true;
        }

        ~Logger()
        {
            m_file.Close();
        }

        public void Write(string text)
        {
            if (m_file == null)
                return;

            m_file.WriteLine("[" + DateTime.Now.ToString("HH:mm:ss tt") + "] " + text);
        }
    }
}
